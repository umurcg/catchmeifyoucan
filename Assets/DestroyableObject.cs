using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///This script controls health of destroyable objects 
/// </summary>

public class DestroyableObject : MonoBehaviour {

    [SerializeField]
    protected float initialHealth = 100;
    float health;

    public float getHealth() { return health; }

    private void Start()
    {
        health = initialHealth;
    }

    public virtual void Damage(float amount)
    {
        //If health is below or equal zero don't do anything
        if (health <= 0) return;

        health -= amount;

        Debug.Log(gameObject.name + " took damage " + amount+ "current health is "+ health);

        if (health <=0) Die();


    }

    


    protected virtual void Die()
    {
        Debug.Log(gameObject.name + " I am dead");
        Destroy(gameObject);
        
    }



}
