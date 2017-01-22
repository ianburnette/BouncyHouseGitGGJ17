using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallTrigger : MonoBehaviour {
	#region PrivateProperties
		
	#endregion

	#region PublicVariables
		
	#endregion

	#region UnityFunctions
	void Start () {
		
	}
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "player")
        {
            col.transform.GetComponent<PlayerMove>().TestFall();
            this.enabled = false;
        }
    }
    #endregion

    #region CustomFunctions

    #endregion
}
