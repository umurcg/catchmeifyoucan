using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Rotates owner object towards its movement dir
/// </summary>
public class RotateTowardsMovementDir : MonoBehaviour {

    Vector3 prevPos;
    [SerializeField] float tolerance=0.0001f;
    [SerializeField] float rotSpeed = 2f;
	// Use this for initialization
	void Start () {
        prevPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(transform.position, prevPos);

       

        if (distance > tolerance)
        {
            Quaternion aimRot = Quaternion.LookRotation(transform.position - prevPos,transform.up);
            transform.rotation=Quaternion.Lerp(transform.rotation, aimRot, Time.deltaTime * rotSpeed);
        }

        prevPos = transform.position;
	}
}
