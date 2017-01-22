using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    #region PrivateProperties
    [SerializeField]
    Transform player;
    [SerializeField]
    bool locked;
    [SerializeField] float smootheSpeed, playerOffset;
    [SerializeField]
    Vector2[] arenas;
    [SerializeField]
    int currentArena;
    [SerializeField]
    float min, max;

    public bool Locked
    {
        get
        {
            return locked;
        }

        set
        {
            locked = value;
        }
    }

    public int CurrentArena
    {
        get
        {
            return currentArena;
        }

        set
        {
            currentArena = value;
        }
    }
    #endregion

    #region PublicVariables

    #endregion

    #region UnityFunctions
    void Start () {
		
	}
	void FixedUpdate () {
        Vector3 targetPosition = Vector3.zero;
		if (!Locked) {
            targetPosition = new Vector3(player.position.x + playerOffset, transform.position.y, transform.position.z);
        }
        else
        {
            targetPosition = new Vector3(arenas[CurrentArena].x, arenas[CurrentArena].y, transform.position.z);
        }
        if (targetPosition.x < min)
            targetPosition = new Vector2(min, targetPosition.y);
        if (targetPosition.x > max)
            targetPosition = new Vector2(max, targetPosition.y);
        targetPosition = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smootheSpeed * Time.deltaTime);
        
    }
	#endregion

	#region CustomFunctions
		
	#endregion
}
