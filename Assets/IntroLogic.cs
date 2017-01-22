using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroLogic : MonoBehaviour {
    #region PrivateProperties
    [SerializeField]
    Vector3[] positions;
    [SerializeField]
    int index;
    [SerializeField]
    float speed, timePerPanel;

	#endregion

	#region PublicVariables
		
	#endregion

	#region UnityFunctions
	void Start () {
        StartCoroutine("Progress");
	}
	void Update () {
        transform.position = Vector3.Lerp(transform.position, positions[index], speed * Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
        {
            MySceneManager.sceneMan.LoadLevel(2);
        }
    }
	#endregion

	#region CustomFunctions
		IEnumerator Progress()
    {


        for (int i = 1; i<positions.Length; i++)
        {
            yield return new WaitForSeconds(timePerPanel);
            index = i;
        }
        MySceneManager.sceneMan.LoadLevel(2);
        yield return null;
    }
	#endregion
}
