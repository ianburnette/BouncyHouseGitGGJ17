﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Persist : MonoBehaviour {
	#region PrivateProperties
				
	#endregion

	#region PublicVariables
		
	#endregion

	#region UnityFunctions
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    void OnEnable()
    {
     //   //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
     //   SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
     //   SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log("Level Loaded");
        //Debug.Log(scene.buildIndex + " number");
        //Debug.Log(scene.name);
        //Debug.Log(mode);
    }
	#endregion

	#region CustomFunctions

       
	#endregion
}
