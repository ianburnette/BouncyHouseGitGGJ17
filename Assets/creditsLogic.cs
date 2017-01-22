using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditsLogic : MonoBehaviour {
	#region PrivateProperties
		
	#endregion

	#region PublicVariables
		
	#endregion

	#region UnityFunctions
	void Start () {
		
	}
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            MySceneManager.sceneMan.LoadLevel(6);
        }
    }

	#endregion

	#region CustomFunctions
		
	#endregion
}
