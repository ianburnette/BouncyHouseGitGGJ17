using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cinematics : MonoBehaviour {
    #region PrivateProperties
    [SerializeField] CanvasGroup introslide;
    [SerializeField] float introSlideLength, fadeSpeed;
	#endregion

	#region PublicVariables
		
	#endregion

	#region UnityFunctions
	void Start () {
        Invoke("Fade", introSlideLength);
	}
	void Update () {
		
	}
	#endregion

	#region CustomFunctions
	void Fade()
    {
        introslide.alpha -= fadeSpeed * Time.deltaTime;
    }
	#endregion
}
