using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBulletController : BulletController {

    /// <summary>
    /// Shotgon bullet damage decreases with the distance it takes
    /// </summary>

    //Store this for calculating new damage
    float initialDamge;
    
	// Use this for initialization
	void Start () {
        initialDamge = damageAmount;
	}

    protected override void Update()
    {
        base.Update();
        if (shooted) calculateDamage();
        

        
    }

    //Damage of shotgun decreases with taken distance.
    //Formula: y=1-x^3s
    void calculateDamage()
    {
        
        
        //Distance to intial position
        float distanceTaken = Vector3.Distance(transform.position,initialPosition);

        //if no distance is taken then damage is full, if distance taken equals range then damage is 0
        //if x==0 => y=1, if x==1 => y=0
        float x = (distanceTaken / range);
                
        damageAmount = initialDamge * (1 - Mathf.Pow(x,3));

        //Debug.Log("Shotgun bullet remaining damage is " + damageAmount+" x is "+ x);

        
    }


}
