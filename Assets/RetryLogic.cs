using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryLogic : MonoBehaviour {
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
            MySceneManager.sceneMan.LoadLevel(2);
        }else if (Input.GetButtonDown("Jump"))
        {
            MySceneManager.sceneMan.LoadLevel(0);
        }
	}
	#endregion

	#region CustomFunctions
		
	#endregion
}
