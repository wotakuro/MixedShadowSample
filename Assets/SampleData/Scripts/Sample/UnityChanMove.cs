using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanMove : MonoBehaviour {
    private Animator anim;
       
	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
	}

    public bool IsMoving
    {
        get;private set;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal") , 0.0f , Input.GetAxis("Vertical") );
        Vector3 camForward = Camera.main.transform.forward;
        camForward.y = 0.0f;
        Quaternion q = Quaternion.LookRotation(camForward);
        input = q * input;

        float speed = input.sqrMagnitude;
        anim.SetFloat("Speed",speed * 0.5f);
        IsMoving = (speed > 0.01f);


        if (IsMoving)
        {
            transform.LookAt(transform.position + input);
            transform.position += input * Time.deltaTime * 7.0f;
        }
    }
}
