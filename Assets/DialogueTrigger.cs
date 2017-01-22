using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {
	#region PrivateProperties
		[SerializeField] int thisDialogue;
    [SerializeField]
  
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
            DialogueSets.publicDialogue.PlayDialogue(thisDialogue);
            GetComponent<BoxCollider2D>().enabled = false;
            this.enabled = false;
        }
    }
    #endregion

    #region CustomFunctions

    #endregion
}
