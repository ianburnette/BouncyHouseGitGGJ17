using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentTrigger : MonoBehaviour {
    #region PrivateProperties
    [SerializeField]
    int opponentNumber;
    [SerializeField]
    GameObject toDestroy;
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
            if (toDestroy != null)
            {
                Destroy(toDestroy);
            }
            Logic.publicLogic.CreateBarriers(opponentNumber);
            //Destroy(gameObject);
            this.enabled = false;
        }
    }
	#endregion

	#region CustomFunctions
		
	#endregion
}
