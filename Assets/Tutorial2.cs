using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial2 : MonoBehaviour {
    #region PrivateProperties
    [SerializeField]
    int maxNumbers;
    int currentNumbers = 0;
    [SerializeField]
    GameObject toDisable, toEnable;
    [SerializeField] PlayerMove move;
    bool flailingLastFrame, flailingThisFrame;
    #endregion

    #region PublicVariables

    #endregion

    #region UnityFunctions
    void Start () {
		
	}
	void Update () {
        flailingThisFrame = move.Flailing;
        if (flailingThisFrame != flailingLastFrame && flailingThisFrame == false)
        {
            currentNumbers++;
        }
        if (currentNumbers == maxNumbers)
        {
            toEnable.SetActive(true);
            toDisable.SetActive(false);
            this.enabled = false;

        }
        flailingLastFrame = flailingThisFrame;
    }
	#endregion

	#region CustomFunctions
		
	#endregion
}
