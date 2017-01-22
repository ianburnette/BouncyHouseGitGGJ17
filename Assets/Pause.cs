using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    #region PrivateProperties
    [SerializeField]
    GameObject pauseScreen;
	#endregion

	#region PublicVariables
		
	#endregion

	#region UnityFunctions
	void Start () {
		
	}
	void Update () {
		if (Input.GetButtonDown("Pause"))
        {
            Time.timeScale = 1 - Time.timeScale;
            if (Time.timeScale < 1)
                pauseScreen.SetActive(true);
            else
                pauseScreen.SetActive(false);
        }
	}
	#endregion

	#region CustomFunctions
		
	#endregion
}
