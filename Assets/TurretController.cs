using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls turret rotation and shooting
/// </summary>

public class TurretController : MonoBehaviour {

    [SerializeField] GameObject player;
    [SerializeField] float rotationSpeed = 3f;
    Weapon weapon;

	// Use this for initialization
	void Start () {
        weapon = GetComponentInChildren<Weapon>();
	}
	
	// Update is called once per frame
	void Update () {

        rotateTowardsPlayer();

        if (!weapon.isRefilling())
        {
            //Raycast to understand wether or not player is aimed
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, 1000))
            {
                if(hit.transform.gameObject==player) weapon.Shoot();
            }
                
        }

    }

    void rotateTowardsPlayer()
    {
        Quaternion aimRot = Quaternion.LookRotation(player.transform.position-transform.position, transform.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, aimRot, rotationSpeed*Time.deltaTime);

    }

 

}
