using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCamera : MonoBehaviour {
    #region PrivateProperties
    [SerializeField] CameraMove cam;
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
            cam.Locked = false;
            this.enabled = false;
            Destroy(gameObject);
        }
    }
    #endregion

    #region CustomFunctions

    #endregion
}
