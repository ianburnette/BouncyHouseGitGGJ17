using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opponentAI : MonoBehaviour {
    #region PrivateProperties
    [SerializeField]
    float chanceToJumpOnGround, chanceToChangeDirection, chanceToStop, moveChangeTime, combatChangeTime, idealDistance, recoverTime;
    [SerializeField]
    float chanceToPunch, chanceToCharge, chanceToPound, chanceToThrow, chanceToGrab;
    [SerializeField]
    float distanceToMelee, maxHeightDifferenceToCharge, minDistanceToRangedAttack;
    [SerializeField]
    int opponentNumber;
    [SerializeField] PlayerMove movementScript;
    [SerializeField] bool movingRight, movingLeft, recovering;
    [SerializeField] Transform player;
    [SerializeField]
    int behindPlayerMask, normalMask;


    #endregion

    #region PublicVariables
    public int OpponentNumber
    {
        get
        {
            return opponentNumber;
        }

        set
        {
            opponentNumber = value;
        }
    }
    #endregion

    #region UnityFunctions
    void Start () {
        InvokeRepeating("MovementStateMachine", 0, moveChangeTime);
        InvokeRepeating("CombatStateMachine", 0, combatChangeTime);
    }
	void Update () {
       
	}
	#endregion

	#region CustomFunctions
	void MovementStateMachine()
    {
        float rand = Random.value;

        if (movementScript.Flailing && !recovering)
        {
            print("recovering");
            recovering = true;
            Invoke("Recover", recoverTime);
         
        }
        if (rand < chanceToJumpOnGround)
            movementScript.VirtualJump = true;
        if (transform.position.x < player.position.x)
        {
            transform.gameObject.layer = behindPlayerMask;
            movingRight = true;
            movingLeft = false;
            movementScript.VirtualHinput = 1f;
        }
        else
        {
            transform.gameObject.layer = normalMask;
        }
         if ((!movingRight && !movingLeft) && transform.position.x >= player.position.x)
        {
            if (rand < chanceToChangeDirection)
            {
                float dist = Vector2.Distance(transform.position, player.position);
                if (dist < idealDistance)
                {
                    movingRight = true;
                    movingLeft = false;
                    movementScript.VirtualHinput = 1f;
                }else if (dist > idealDistance)
                {
                    movingLeft = true;
                    movingRight = false;
                    movementScript.VirtualHinput = -1f;
                }
            }
        }
        else if (rand < chanceToStop)
        {
            movingRight = movingLeft = false;
            movementScript.VirtualHinput = 0f;
        }
      
    }
    void CombatStateMachine()
    {
        if (!movementScript.Attacking)
        {

            float dist = Vector2.Distance(player.position, transform.position);
            float rand = Random.value;
            float heightDif = Mathf.Abs(transform.position.y - player.position.y);
            if (dist < distanceToMelee)
            {
                print("in melee distance");
                if (heightDif > maxHeightDifferenceToCharge && rand < chanceToPound)
                    movementScript.VirtualPound = true;
                else if (heightDif <= maxHeightDifferenceToCharge && rand < chanceToPunch)
                {
                    print("happened to punch");
                    movementScript.VirtualPunch = true;
                }
            }
            else if (dist < minDistanceToRangedAttack && heightDif < maxHeightDifferenceToCharge)
            {
                print("at a similar height and beyond min distance for ranged");
                if (Random.value < .5f)
                {
                    if (rand < chanceToCharge)
                        movementScript.VirtualCharge = true;
                }
                else
                {
                    if (rand < chanceToThrow)
                        movementScript.VirtualThrow = true;
                }

            }
            else if (dist >= minDistanceToRangedAttack)
            {
                print("I can pound now");
                if (rand < chanceToPound)
                    movementScript.VirtualPound = true;
            }
        }
        else
        {
            movementScript.VirtualPunch = false;
            movementScript.VirtualThrow = false; ;
            movementScript.VirtualCharge = false; ;
            movementScript.VirtualPound = false; ;
        }
    }
    void Recover()
    {
        print("using recover function");
        recovering = false;
        movementScript.GetRecoverInput();
    }
	#endregion
}
