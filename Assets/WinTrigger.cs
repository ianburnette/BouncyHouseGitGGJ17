using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour {
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
            MySceneManager.sceneMan.LoadLevel(3);
        }
    }
    #endregion

    #region CustomFunctions

    #endregion
}
