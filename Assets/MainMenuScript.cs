using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {
    #region PrivateProperties
    [SerializeField]
    CanvasGroup myCanvas;
	#endregion

	#region PublicVariables
		
	#endregion

	#region UnityFunctions
	void Start () {
		
	}
	void Update () {
        print("in update");
        if (Input.GetButtonDown("Jump"))
        {
            MySceneManager.sceneMan.LoadLevel(1);
        }
        if (Input.GetButtonDown("Fire3"))
        {
            MySceneManager.sceneMan.LoadLevel(4);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            MySceneManager.sceneMan.LoadLevel(7);
        }
    }
	#endregion

	#region CustomFunctions
	public void StartGame()
    {
        
    }

    public void Quit()
    {

    }

    public void Credits()
    {

    }
    public void Load(int lev)
    {
        StartCoroutine("FadeMyCanvas");
        MySceneManager.sceneMan.LoadLevel(lev);
    }
    IEnumerator FadeMyCanvas ()
    {
        while (myCanvas.alpha>0)
        {
            myCanvas.alpha -= MySceneManager.sceneMan.FadeSpeed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }
	#endregion
}
