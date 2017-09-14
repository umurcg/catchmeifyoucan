using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {

    [SerializeField] GameObject player;
    [SerializeField] GameObject barrel;
    [SerializeField] float barrelRotationSpeed;
    //[SerializeField] GameObject center;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        
        //float angleDif = Vector3.Angle(barrel.transform.forward, player.transform.position - transform.position);
        //if (angleDif > 1f)
        //{

        //    barrel.transform.RotateAround(transform.position, transform.up, Time.deltaTime * barrelRotationSpeed * angleDif);
        //}

        

    }

 

}
