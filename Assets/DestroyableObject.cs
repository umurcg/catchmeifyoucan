using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///This script controls health of destroyable objects 
/// </summary>

public class DestroyableObject : MonoBehaviour {

    [SerializeField]
    protected float initialHealth = 100;
    protected float health;

    //UI
    [SerializeField] GameObject pointBarPrefab;
    [SerializeField] GameObject canvas; 
    protected PointBarScript pointBar;
    

    public float getHealth() { return health; }

    protected virtual void Start()
    {
        health = initialHealth;

        if (pointBarPrefab != null)
        {

            //Instantiate point bat
            EnemyPointBar enemyBar = (Instantiate(pointBarPrefab, canvas.transform) as GameObject).GetComponent<EnemyPointBar>();
            enemyBar.owner = gameObject;
            pointBar = enemyBar;
            pointBar.setPoint(health);

        }

    }

    public virtual void Damage(float amount)
    {
        //If health is below or equal zero don't do anything
        if (health <= 0) return;

        health -= amount;

        //Debug.Log(gameObject.name + " took damage " + amount+ "current health is "+ health);

        //If ui script is attached then update point of bar
        if(pointBar) pointBar.setPoint(health);

        if (health <=0) Die();


    }

    


    protected virtual void Die()
    {
        Debug.Log(gameObject.name + " I am dead");
        Destroy(gameObject);
        
    }



}
