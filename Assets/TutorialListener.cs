using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialListener : MonoBehaviour {
    #region PrivateProperties
    [SerializeField]
    GameObject[] prompts;
    Rigidbody2D rb;
    [SerializeField]
    int maxNumbers;
    int currentNumbers = 0;
    [SerializeField]
    GameObject toDisable, toEnable;
    [SerializeField]
    bool[] doneThisOne;
	#endregion

	#region PublicVariables
		
	#endregion

	#region UnityFunctions
	void Start () {
        doneThisOne = new bool[6];
	}
	void Update () {
        
		if (Mathf.Abs(Input.GetAxis("Horizontal")) > .3f && !doneThisOne[0])
        {
            rb = prompts[0].GetComponent<Rigidbody2D>();
            rb.isKinematic = false;
            currentNumbers++;
            doneThisOne[0] = true;
          //  rb.AddForce((Random.value * Vector2.up) * (Random.value * Vector2.right), 
        }
        if (Input.GetButtonDown("Jump") && !doneThisOne[1])
        {
            rb = prompts[1].GetComponent<Rigidbody2D>();
            rb.isKinematic = false;
            currentNumbers++;
            doneThisOne[1] = true;
        }
        if (Input.GetButtonDown("Fire1") && !doneThisOne[2])
        {
            rb = prompts[2].GetComponent<Rigidbody2D>();
            rb.isKinematic = false;
            currentNumbers++;
            doneThisOne[2] = true;
        }
        if (Input.GetButtonDown("Fire2") && !doneThisOne[3])
        {
            rb = prompts[3].GetComponent<Rigidbody2D>();
            rb.isKinematic = false;
            currentNumbers++;
            doneThisOne[3] = true;
        }
        if (Input.GetButtonDown("Fire3") && !doneThisOne[4])
        {
            rb = prompts[4].GetComponent<Rigidbody2D>();
            rb.isKinematic = false;
            currentNumbers++;
            doneThisOne[4] = true;
        }
        if ((Input.GetAxis("Vertical") < -.1f) && Input.GetButtonDown("Fire2") && !doneThisOne[5])
        {
            rb = prompts[5].GetComponent<Rigidbody2D>();
            rb.isKinematic = false;
            currentNumbers++;
            doneThisOne[5] = true;
        }
        if (currentNumbers == maxNumbers)
        {
            toEnable.SetActive(true);
            toDisable.SetActive(false);
            this.enabled = false;
        }

    }
	#endregion

	#region CustomFunctions
		
	#endregion
}
