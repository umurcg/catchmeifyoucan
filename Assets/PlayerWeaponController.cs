using System.Collections;   
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Can change weapon with keyboard
/// </summary>

public class PlayerWeaponController : MonoBehaviour {

    [SerializeField] Weapon[] weapons;
    [SerializeField] PlayerShootController psc;
    Weapon currentWeapon;

	// Use this for initialization
	void Start () {

        if(psc==null)
        {
            Debug.Log("Assign player shoot controller");
            enabled = false;
        }

        switchWeapon(weapons[0]);

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            switchWeapon(weapons[0]);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            switchWeapon(weapons[1]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            switchWeapon(weapons[2]);
        }

    }


    void switchWeapon(Weapon weaponToSwitch)
    {
        //Disable current weapon if it is not null
        if(currentWeapon!=null)
             currentWeapon.gameObject.SetActive(false);

        //Activate new weapon and assign it as current wapon
        currentWeapon = weaponToSwitch;
        currentWeapon.gameObject.SetActive(true);

        //Assign current weapon to player shoot controler
        psc.setWeapon(currentWeapon);



    }

}
