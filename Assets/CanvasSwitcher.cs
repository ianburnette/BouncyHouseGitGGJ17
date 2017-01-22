using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSwitcher : MonoBehaviour {
    #region PrivateProperties
    [SerializeField]
    CanvasGroup[] groups;
    [SerializeField]
    CanvasGroup prompt;
    [SerializeField]
    float[] timeBeforePrompt;
    [SerializeField] float fadeSpeed;
    int currentPanel = 0;
    [SerializeField]
    int sceneToLoad;
	#endregion

	#region PublicVariables
		
	#endregion

	#region UnityFunctions
	void OnEnable () {
        StartCoroutine("ShowPanel", currentPanel);
        //
	}
	void Update () {
		if (Input.GetButtonDown("Fire1") && currentPanel < groups.Length)
        {
            StartCoroutine("ShowPanel", currentPanel);
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
        }
       
	}
	#endregion

	#region CustomFunctions
	
    IEnumerator ShowPanel(int cur)
    {
        prompt.alpha = 0;
        while (groups[currentPanel].alpha < 1)
        {
            groups[currentPanel].alpha += fadeSpeed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        if (currentPanel == 2)
        {
            groups[currentPanel].gameObject.GetComponent<Animator>().enabled = true;
        }
        //Invoke("StartNext", timeBeforePrompt[currentPanel
        prompt.alpha = 1;
        currentPanel++;
        yield return null;
    }
	#endregion
}
