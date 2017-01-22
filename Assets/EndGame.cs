using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {
	#region PrivateProperties
		
	#endregion

	#region PublicVariables
		
	#endregion

	#region UnityFunctions
	void Start () {
		
	}
	void Update () {
		
	}
    void OnTriggerEnter2d(Collider col)
    {
        if (col.transform.tag == "player")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
    }
	#endregion

	#region CustomFunctions
		
	#endregion
}
