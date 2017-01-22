using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct dialogueChunk
{

    public string name;
    public string dialogue;
    public GameObject toSetActiveAfter;
}

public class DialogueSets : MonoBehaviour {


    #region PrivateProperties
    public static DialogueSets publicDialogue;
    [SerializeField]
    CameraMove cam;
    [SerializeField]
    GameObject dialogueCanvas;
    [SerializeField]
    Text charName, dialogueText;
    [SerializeField] dialogueChunk[] firstChunks, friendChunks, brotherChunks, birthdayboyChunks;
    [SerializeField]
    float textTime;
    [SerializeField]
    Behaviour[] toDisableInDialogue;
	#endregion

	#region PublicVariables
		
	#endregion

	#region UnityFunctions
	void Start () {
        publicDialogue = this;

    }
	void Update () {
		
	}
	#endregion

	#region CustomFunctions
	public	void PlayDialogue(int which)
    {
        print("playing");
        foreach (Behaviour behav in toDisableInDialogue)
        {
            if (behav != null)
                behav.enabled = false;
        }
        dialogueCanvas.SetActive(true);
        StartCoroutine("PlayText", which);
    }
    IEnumerator PlayText(int which)
    {
        print("starting with " + which);
        dialogueChunk[] currentChunk = firstChunks;
        if (which == 0)
            currentChunk = firstChunks;
        if (which == 1)
            currentChunk = friendChunks;
        if (which == 2)
            currentChunk = brotherChunks;
        if (which == 3)
            currentChunk = birthdayboyChunks;

        for (int i = 0; i < currentChunk.Length; i++)
        {
            dialogueText.text = "";
            string myName = currentChunk[i].name;
            string textToSay = currentChunk[i].dialogue;
            charName.text = myName;
            for (int j = 0; j<textToSay.Length; j++)
            {
                dialogueText.text += textToSay[j];
                yield return new WaitForSeconds(textTime);
            }

            while (!Input.GetButtonDown("Fire1"))
                yield return null;
            yield return new WaitForFixedUpdate();

           // while (!Input.GetButtonDown("Fire1"))
           // {
           //     print("in while");
           ////     yield return new WaitForEndOfFrame();
           // }
        }
      
        if (currentChunk[0].toSetActiveAfter != null)
            currentChunk[0].toSetActiveAfter.SetActive(true);
        foreach (Behaviour behav in toDisableInDialogue)
        {
            if (behav != null)
                behav.enabled = true;

        }
        dialogueCanvas.SetActive(false);
        cam.Locked = true;
        yield return null;
    }
	#endregion
}
