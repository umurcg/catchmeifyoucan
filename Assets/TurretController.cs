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

        if (!weapon.isRefilling()) weapon.Shoot(); 

    }

    void rotateTowardsPlayer()
    {
        Quaternion aimRot = Quaternion.LookRotation(player.transform.position-transform.position, transform.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, aimRot, rotationSpeed*Time.deltaTime);

    }

 

}
