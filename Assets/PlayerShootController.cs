using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController : MonoBehaviour {

    [SerializeField]
    Weapon currentWeapon;

    public void setWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
    }

	// Use this for initialization
	void Start () {

       
		
	}
	
	// Update is called once per frame
	void Update () {

        //If there is no weapon then return
        if (currentWeapon == null) return;

        if (Input.GetAxis("Fire1")>0) currentWeapon.Shoot();
        

	}


}
