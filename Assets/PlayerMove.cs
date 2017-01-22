using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    #region PrivateProperties

    [SerializeField]
    AudioSource source;
    [SerializeField] AudioClip bounce, barf, throwCandy, waveSound;
    [SerializeField] AudioClip[] hits;
    [SerializeField]
    float vol;

    [SerializeField] bool collectInput;

    //virtual input
    [SerializeField] bool virtualJump, virtualPunch, virtualCharge, virtualThrow, virtualPound;
    [SerializeField] float virtualHinput;

    //PHYSICS variables
    [SerializeField] Rigidbody2D rb;
    [SerializeField] bool attacking; 

    //MOVEMENT VARIABLES
    [SerializeField]
    float horizontalMoveSpeed, jumpHeight, maxVelToRecover, spinSpeed;
    float hInput;
    [SerializeField] bool flailing;
    [SerializeField] float attackDirection;

    //JUMP variables
    [SerializeField] bool grounded;
    [SerializeField] float distance, checkOffset;
    [SerializeField] LayerMask groundMask;

    //Animation variables
    [SerializeField] Animator anim;

    //attack variables
    [SerializeField] bool statePunch, stateCharge, statePound;
    [SerializeField] float punchReset, chargeReset, throwReset, poundReset, chargeSpeed, punchSpeed, candySpeed, poundSpeed, verticalThrowVariance;
    [SerializeField] Transform candy, candyLocation;
    PlayerHealth health;
    [SerializeField]
    bool poundingDown;
    [SerializeField]
    Transform wave;
    [SerializeField]
    Vector3 waveOffset;
    [SerializeField] Transform waveEmitter;
    [SerializeField]
    Transform currentWave;


    #endregion

    #region PublicVariables
    public bool Attacking    {get{return attacking;}set{attacking = value;}}
    public bool Grounded{get{return grounded;}set{grounded = value;}}

    public bool VirtualJump
    {
        get
        {
            return virtualJump;
        }

        set
        {
            virtualJump = value;
        }
    }

    public float VirtualHinput
    {
        get
        {
            return virtualHinput;
        }

        set
        {
            virtualHinput = value;
        }
    }

    public bool VirtualPunch
    {
        get
        {
            return virtualPunch;
        }

        set
        {
            virtualPunch = value;
        }
    }

    public bool VirtualCharge
    {
        get
        {
            return virtualCharge;
        }

        set
        {
            virtualCharge = value;
        }
    }

    public bool VirtualThrow
    {
        get
        {
            return virtualThrow;
        }

        set
        {
            virtualThrow = value;
        }
    }

    public bool VirtualPound
    {
        get
        {
            return virtualPound;
        }

        set
        {
            virtualPound = value;
        }
    }

    public bool Flailing
    {
        get
        {
            return flailing;
        }

        set
        {
            flailing = value;
        }
    }

    public AudioClip Bounce
    {
        get
        {
            return bounce;
        }

        set
        {
            bounce = value;
        }
    }

    public AudioSource Source
    {
        get
        {
            return source;
        }

        set
        {
            source = value;
        }
    }

    public AudioClip Barf
    {
        get
        {
            return barf;
        }

        set
        {
            barf = value;
        }
    }

    public float Vol
    {
        get
        {
            return vol;
        }

        set
        {
            vol = value;
        }
    }

    #endregion

    #region UnityFunctions
    void Start () {
        source = GetComponent<AudioSource>();
        health = GetComponent<PlayerHealth>();
	}
	void Update () {
        GetGrounded();
        GetMoveInput();
        if (!flailing)
        {
            GetJumpInput();
            if(!attacking)
                 GetAttackInput();
        }
        else if (collectInput)
        {
            GetRecoverInput();
        }
        GetMetaInput();
        if (hInput != 0)
            Move();
        Animate();
        if (Input.GetButtonDown("Flail"))
        {
            GetHit(1);
        }
        if (currentWave != null)
        {
            currentWave.position = waveEmitter.position;
        }
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if ((collectInput && col.transform.tag == "opponent") || (!collectInput && col.transform.tag == "player"))
        {
            if (statePunch)
                col.transform.GetComponent<PlayerMove>().GetHit(1);
            else if (stateCharge)
                col.transform.GetComponent<PlayerMove>().GetHit(2);
            else if (statePound)
                col.transform.GetComponent<PlayerMove>().GetHit(3);

            statePunch = false;
            statePound = false;
            stateCharge = false;
        }
    }
    #endregion

    #region CustomFunctions
    #region InputFunctions
    void GetGrounded()
    {
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y) + (Vector2.down * checkOffset), Vector2.down * distance, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, distance, groundMask);
     //   print("hit is " + hit.transform);
        if (hit.transform != null && hit.transform.tag == "StaticGround")
        {
            if (poundingDown)
            {
             //   GetBounce.staticBounce.SplashHere(transform.position);
                poundingDown = false;
                //attacking = false;
            }
            Grounded = true;
        }
        else if (hit.transform != null) {
            string targetTag = collectInput ? "opponent" : "player";
            if (hit.transform.tag == targetTag )
            {
                if (poundingDown) {
                    hit.transform.GetComponent<PlayerMove>().HitFromAbove();
                    Jump();
                    attacking = false;
                }
                else
                {
                    Jump();
                }
            }
        }
        else
        {
            Grounded = false;
        }
    }
    void GetMoveInput()
    {
        if (collectInput)
            hInput = Input.GetAxis("Horizontal");
        else
            hInput = virtualHinput;
    }
    void GetJumpInput()
    {
        if (collectInput)
        {
            if (Input.GetButtonDown("Jump") && Grounded)
            {
                Jump();
            }
        }
        else
        {
            if (VirtualJump && Grounded)
            {
                Jump();
                VirtualJump = false;
            }
        }
       
    }
    void GetAttackInput()
    {
        bool punch = false;
        bool charge = false;
        bool throwing = false;
        bool pounding = false;
        if (collectInput)
        {
            if (Input.GetButtonDown("Fire1"))
                punch = true;
            else if (Input.GetButtonDown("Fire2"))
            {
                if (Input.GetAxis("Vertical") >= 0 && pounding == false)
                    charge = true;
                else
                    pounding = true;
            }

            else if (Input.GetButtonDown("Fire3"))
                throwing = true;
        }
        else
        {

        
            punch = VirtualPunch;

            throwing = virtualThrow;
            charge = virtualCharge;
            pounding = virtualPound;
        }
        if (punch && !attacking) 
        {
            anim.SetTrigger("punch");
            Punch();
            attacking = true;
            Invoke("ResetAttack", punchReset);
            punch = false;
            statePunch = true;
        }
        else if (charge && !attacking)
        {
            anim.SetTrigger("charge");
            Charge();
            attacking = true;
            Invoke("ResetAttack", chargeReset);
            charge = false;
            stateCharge = true;
        }else if (throwing && !attacking)
        {
            anim.SetTrigger("throw");
            Throw();
            Invoke("ResetAttack", throwReset);
            attacking = true;
            throwing = false;
        }else if (pounding && !poundingDown && !attacking)
        {
            print("pounding now");
            anim.SetTrigger("pound");
            Pound();
            attacking = true;
            pounding = false;
            poundingDown = true;
            statePound = true;
            Invoke("ResetAttack", poundReset);
        }
    }
    public void ResetAttack()
    {
        if (!poundingDown)
        {
            attacking = false;
            statePunch = false;
            stateCharge = false;
            statePound = false;
        }
        else
        {
            Invoke("ResetAttack", poundReset);
        }
    }
    void GetMetaInput()
    {

    }
    public void GetRecoverInput()
    {
        if (collectInput)
        {
            if (rb.velocity.magnitude < maxVelToRecover && Input.GetButtonDown("Jump"))
            {
                Flailing = false;
                transform.rotation = Quaternion.identity;
                rb.freezeRotation = true;
                anim.SetTrigger("recover");
                if (Grounded)
                    Jump();
            }
        }
        else
        {
            Flailing = false;
            transform.rotation = Quaternion.identity;
            rb.freezeRotation = true;
            anim.SetTrigger("recover");
            if (Grounded)
                Jump();
        }
     
    }
    #endregion
    #region MovementFunctions
    void Jump()
    {
        Source.PlayOneShot(Bounce, Vol);
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        //rb.AddForce(Vector2.up);
        anim.SetBool("jumping", true);
    }
    void Move()
    {
        if (transform.localScale.x < 0 && hInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            attackDirection = 1;
            //candySpeed = -candySpeed;
        }else if (transform.localScale.x > 0 && hInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            attackDirection = -1;
           // candySpeed = -candySpeed;
        }
        rb.AddForce(Vector2.right * hInput * horizontalMoveSpeed);
    }
    void GetHit(float amt)
    {
        if (!flailing)
        {
            Source.PlayOneShot(hits[Random.Range(0,3)], Vol);
            print("taking damage");
            health.AddToMeter(amt);
            if (amt > 1)
            {
                flailing = true;
                anim.SetTrigger("flail");
                rb.freezeRotation = false;
                rb.AddTorque(spinSpeed);
                ResetAttack();
                poundingDown = false;
                virtualPound = false;
            }
        }
    }
    public void TestFall()
    {
        flailing = true;
        anim.SetTrigger("flail");
        rb.freezeRotation = false;
        rb.AddTorque(spinSpeed);
    }
    public void HitFromAbove()
    {
        print("hit from above");
        GetHit(2);
    }
    public void HitByCandy(int amt)
    {
        print("hit by candy");
        GetHit(amt);
    }
    void Punch()
    {
        rb.AddForce(Vector2.right * attackDirection * punchSpeed, ForceMode2D.Impulse);
    }
    void Charge()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.right * attackDirection * chargeSpeed, ForceMode2D.Impulse);
    }
    void Throw()
    {
        Source.PlayOneShot(throwCandy, vol);
        Transform candyInstance = Instantiate(candy);
        candyInstance.GetComponent<CandyScript>().PlayerCandy = collectInput;
        candyInstance.transform.position = candyLocation.position;
        candyInstance.GetComponent<Rigidbody2D>().AddForce((Vector2.right * attackDirection * candySpeed + (Vector2.up * Random.Range(-1f, 1f) * verticalThrowVariance).normalized), ForceMode2D.Impulse);
    }
    void Pound()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.down * poundSpeed, ForceMode2D.Impulse);
    }
    public void EmitWave()
    {
        Source.PlayOneShot(waveSound, vol);
        Transform candyInstance = Instantiate(wave);
        currentWave = candyInstance;
        candyInstance.position = waveEmitter.position;
        // candyInstance.GetComponent<Rigidbody2D>().AddForce((Vector2.right * attackDirection * candySpeed + (Vector2.up * Random.Range(-1f, 1f) * verticalThrowVariance).normalized), ForceMode2D.Impulse);
        candyInstance.GetComponent<CandyScript>().PlayerCandy = collectInput;

      //  currentWave = Instantiate(wave);
        //currentWave.transform.position = waveEmitter.position;
      
        
    }
    #endregion
    #region Animation
    void Animate()
    {
        anim.SetBool("grounded", Grounded);
        anim.SetFloat("vSpeed", rb.velocity.y);
    }
    #endregion
    #endregion
}

