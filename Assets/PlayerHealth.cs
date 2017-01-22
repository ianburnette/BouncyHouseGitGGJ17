using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    #region PrivateProperties
    [SerializeField]bool player;
    [SerializeField] Slider vomometer;
    [SerializeField] float damageScale;
    [SerializeField] float currentvom;
    [SerializeField] GameObject vom;
    [SerializeField]
    PlayerMove moveScript;
	#endregion

	#region PublicVariables
		
	#endregion

	#region UnityFunctions
	void Start () {
        moveScript = GetComponent<PlayerMove>();
	}
	void Update () {
        UpdateMeter();
        CheckForFailure();
	}
	#endregion

	#region CustomFunctions
	public void AddToMeter(float amt)
    {
        print("adding damage " + amt * damageScale);
        //float famt = amt * 1.0f;
        //print("adding " + amt);
        currentvom += amt * damageScale;
    }
    void UpdateMeter()
    {
        vomometer.value = currentvom;
    }
    void CheckForFailure()
    {
        if (currentvom >= 1f)
        {
            if (player)
                Fail();
            else
                BeatOpponent();
            moveScript.Source.loop = true;
            moveScript.Source.clip = moveScript.Barf;
            moveScript.Source.volume = moveScript.Vol;
            moveScript.Source.Play();
                //PlayOneShot(moveScript.Barf, moveScript.Vol);
        }
    }
    void Fail()
    {
        print("Fail");
        vom.SetActive(true);
        MySceneManager.sceneMan.LoadLevel(5);
        //UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
    void BeatOpponent()
    {
        print("win from " + transform.name);
        vom.SetActive(true);
        Logic.publicLogic.DisableBarriers(GetComponent<opponentAI>().OpponentNumber);
       // GetComponent<Collider2D>().enabled = false;
        GetComponent<PlayerMove>().enabled = false;
        GetComponent<opponentAI>().enabled = false;

        this.enabled = false;
        Invoke("Drop", 10f);
        Invoke("DestroySelf", 12f);
    }
    void Drop()
    {
        GetComponent<Collider2D>().enabled = false;
    }
    void DestroySelf()
    {
        Destroy(gameObject);
    }
    public void HitFromAbove()
    {

    }
	#endregion
}

