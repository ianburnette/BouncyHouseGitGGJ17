using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CandyScript : MonoBehaviour {
    #region PrivateProperties
    [SerializeField]
    float life;
    [SerializeField]
    int dmgAmt;
    [SerializeField] bool playerCandy, actuallyWave;
    [SerializeField]
    Sprite[] sprites;
    

    public bool PlayerCandy
    {
        get
        {
            return playerCandy;
        }

        set
        {
            if (transform.childCount > 0)
            {
                transform.GetChild(0).GetChild(0).GetComponent<CandyScript>().PlayerCandy = value;
                transform.GetChild(1).GetChild(0).GetComponent<CandyScript>().PlayerCandy = value;
            }
            playerCandy = value;
        }
    }
    #endregion

    #region PublicVariables

    #endregion

    #region UnityFunctions

    void OnEnable()
    {
        if (!actuallyWave)
            PickSprite();
        Invoke("Flash", life / 2f);
        Invoke("Die", life);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if ((PlayerCandy && col.transform.tag == "opponent") || !PlayerCandy && col.transform.tag == "player")
        {
            HitPerson(col.transform);
        }
       
    }
    #endregion

    #region CustomFunctions
    void PickSprite()
    {
        if (sprites.Length>0)
            GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length - 1)];
    }
    void Flash()
    {
        GetComponent<Collider2D>().enabled = false;
    }

    void Die()
    {
        Destroy(gameObject);
    }
    void HitPlayer()
    {

    }
    void HitPerson(Transform hit)
    {
        hit.GetComponent<PlayerMove>().HitByCandy(dmgAmt);
    }
	#endregion
}
