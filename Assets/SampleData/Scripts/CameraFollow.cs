using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public UnityChanMove followObj;
    private Vector3 offset;
    private Vector3 backupForward;
    private Quaternion backupRot;
    private bool prevMoving;
    private float rotTime = 0.0f;

    // Use this for initialization
    void Start () {
        offset =  transform.position - followObj.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 objForward = followObj.transform.forward;
        objForward.y = 0.0f;

        //
        if (followObj.IsMoving)
        {
            objForward = backupForward;
            rotTime = 0.0f;
            backupRot = transform.rotation;
        }
        else
        {
            backupForward = objForward;
            rotTime = Mathf.Clamp01(rotTime + Time.deltaTime * 2.0f);
        }
        objForward.y = -0.05f;
        this.transform.rotation = Quaternion.Slerp(backupRot,
            Quaternion.LookRotation(objForward) , rotTime);
        this.transform.position = followObj.transform.position + transform.rotation * offset;
        prevMoving = followObj.IsMoving;
    }
}
