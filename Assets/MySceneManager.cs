using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour {
    #region PrivateProperties
    public static MySceneManager sceneMan;
    [SerializeField]
    CanvasGroup fader;
    [SerializeField]
    float fadeSpeed, fadeInMod;
    [SerializeField]
    AudioSource source;
    [SerializeField]
    AudioClip normal, end;


    #endregion

    #region PublicVariables
    public float FadeSpeed
    {
        get
        {
            return fadeSpeed;
        }

        set
        {
            fadeSpeed = value;
        }
    }
    #endregion

    #region UnityFunctions
    private void Awake()
    {
        if (sceneMan != null && sceneMan != this)
           Destroy(gameObject); 
        else
            sceneMan = this;
    }
	void Start () {
      
	}
	void Update () {
        print("scene update");
	}
	#endregion

	#region CustomFunctions
	public void LoadLevel(int lev)
    {
        StopAllCoroutines();
        StartCoroutine("FadeOut", lev);
    
    }
    IEnumerator FadeOut(int lev)
    {
       
        while (fader.alpha < 1)
        {
            print("fading in");
            fader.alpha += FadeSpeed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
      
        if (lev == 4)
        {
            source.clip = end;
            source.Play();
        }
        else if (source.clip != normal)
        {
            source.clip = normal;
            source.Play();
        }

        SceneManager.LoadScene(lev);
        //StartCoroutine("FadeIn");
        StartFade();
        yield return null;
    }
    void StartFade()
    {
        StopAllCoroutines();
        StartCoroutine("FadeIn");
    }

    IEnumerator FadeIn()
    {
       
        while (fader.alpha > 0)
        {
            print("fading out");
            fader.alpha -= FadeSpeed * fadeInMod * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    
        yield return null;
    }
	#endregion
}
