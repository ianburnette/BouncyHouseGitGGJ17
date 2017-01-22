using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCreation : MonoBehaviour {
    #region PrivateProperties
    [SerializeField]
    GameObject segment;
    [SerializeField]
    Rigidbody2D firstAnchor, secondAnchor;
    [SerializeField]
    float distanceApart, frequency, settleTime;
    [SerializeField] int numberToCreate;
    [SerializeField] Transform lastSegmentTrans, currentSegmentTrans;
	#endregion

	#region PublicVariables
		
	#endregion

	#region UnityFunctions
	void Start () {
        lastSegmentTrans = transform;
        CreateGround();
        Invoke("Settle", settleTime);
	}
	void Update () {
		
	}
	#endregion

	#region CustomFunctions
    void Settle()
    {
        foreach (Transform trans in transform.parent)
        {
            trans.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
    }
	void CreateGround()
    {
        for (int i = 0; i < numberToCreate; i++) {
            GameObject newGroundSegment = GameObject.Instantiate(segment);
            currentSegmentTrans = newGroundSegment.transform;
            currentSegmentTrans.parent = transform.parent;
            currentSegmentTrans.position = lastSegmentTrans.position + (Vector3.right * distanceApart);
            newGroundSegment.GetComponent<SpringJoint2D>().connectedBody = lastSegmentTrans.GetComponent<Rigidbody2D>();
            newGroundSegment.GetComponent<SpringJoint2D>().distance = distanceApart;
           newGroundSegment.GetComponent<SpringJoint2D>().frequency = frequency;
            lastSegmentTrans = currentSegmentTrans;
            if (i == numberToCreate - 1)
            {
                SpringJoint2D[] joints = lastSegmentTrans.GetComponents<SpringJoint2D>();
                joints[1].enabled = true;
                joints[1].connectedBody = secondAnchor.GetComponent<Rigidbody2D>();
                joints[1].frequency = frequency;
            }
        }
    }
	#endregion
}
