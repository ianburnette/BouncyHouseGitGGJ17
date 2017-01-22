using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBounce : MonoBehaviour {
    #region PrivateProperties
    [SerializeField] WaterLine waterScript;
    [SerializeField] int defaultForce;
    public static GetBounce staticBounce;
	#endregion

	#region PublicVariables
		
	#endregion

	#region UnityFunctions
	void Start () {
        staticBounce = this;
	}
	void Update () {
		
	}
	#endregion

	#region CustomFunctions
	public void SplashHere(Vector3 position)
    {
        print("bounce");
        int closestPart = 0;
      //  waterScript.Splash(closestPart, defaultForce);
    }	
	#endregion
}
