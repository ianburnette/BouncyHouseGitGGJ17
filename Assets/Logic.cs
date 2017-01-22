using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic : MonoBehaviour {
    #region PrivateProperties
    public static Logic publicLogic;
    [SerializeField]
    GameObject[] firstOpponentBarriers, secondOpponentBarriers, thirdOpponentBarriers;
    [SerializeField]
    GameObject firstOpponentTrigger, secondOpponentTrigger, thirdOpponentTrigger, firstOpponent, secondOpponent, thirdOpponent;
    [SerializeField]
    GameObject firstOpponentIndicator, secondOpponentIndicator, thirdOpponentIndicator, winIndicator;
    [SerializeField]
    CameraMove cam;
	#endregion

	#region PublicVariables
		
	#endregion

	#region UnityFunctions
	void Start () {
        publicLogic = this;
        foreach (GameObject bar in firstOpponentBarriers)
            bar.SetActive(false);
        foreach (GameObject bar in secondOpponentBarriers)
            bar.SetActive(false);
        foreach (GameObject bar in thirdOpponentBarriers)
            bar.SetActive(false);
    }
	void Update () {
		
	}
	#endregion

	#region CustomFunctions
	public void CreateBarriers (int opponent)
    {
        switch (opponent)
        {
            case 0:
                foreach (GameObject bar in firstOpponentBarriers)
                    bar.SetActive(true);
                firstOpponent.SetActive(true);
                cam.Locked = true;
                cam.CurrentArena = 0;
                break;
            case 1:
                foreach (GameObject bar in secondOpponentBarriers)
                    bar.SetActive(true);
                secondOpponent.SetActive(true);
                cam.Locked = true;
                cam.CurrentArena = 1;
                break;
            case 2:
                foreach (GameObject bar in thirdOpponentBarriers)
                    bar.SetActive(true);
                thirdOpponent.SetActive(true);
                cam.Locked = true;
                cam.CurrentArena = 2;
                break;
            case 3:
                cam.Locked = true;
                cam.CurrentArena = 3;
                break;
            case 4:
                cam.Locked = true;
                cam.CurrentArena = 4;
                break;
        }
      
    }
    public void DisableBarriers (int opponent)
    {
        print("disable barriers from " + opponent);
        switch (opponent)
        {
            case 0:
                firstOpponentBarriers[1].SetActive(false);
                secondOpponentIndicator.SetActive(true);

                break;
            case 1:
                secondOpponentBarriers[1].SetActive(false);
                thirdOpponentIndicator.SetActive(true);
                break;
            case 2:
                print("in win loop");
                thirdOpponentBarriers[1].SetActive(false);
                winIndicator.SetActive(true);
                break;
        }
        cam.Locked = false;
    } 
	#endregion
}
