using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class BulletController : MonoBehaviour {

    [SerializeField] protected float range;
    [SerializeField] protected float damageAmount;
    [SerializeField] protected float initialForceAmount;

    [SerializeField] GameObject particles;

    protected GameObject owner;
    protected bool shooted=false;

    //Initial position when bullet is shooted
    protected Vector3 initialPosition;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void Update () {

        //If bullet is shooted check that range is not overshooted, if it is overshooted then explode
        if (shooted && Vector3.Distance(transform.position, initialPosition) > range)
        {
            Debug.Log("Range is crossed so destroying it self");
            Explode();
        }

	}

    public float getRange() { return range; }
    public float getDamageAmount() { return damageAmount; }
    public float getForce() { return initialForceAmount; }

    //Set owner to prevent harming when bullet touches its shooter
    public void setOwner(GameObject owner)
    {
        this.owner = owner;
    }

    public virtual void shoot()
    {
        shooted = true;
        initialPosition = transform.position;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == owner) return;

        //If hit object has DestroyableObject script than call damage function of it
        DestroyableObject destObj = other.gameObject.GetComponent<DestroyableObject>();
        if (destObj != null) destObj.Damage(damageAmount);

        //When hit something other than owner explode
        Explode();

    }

    protected virtual void Explode()
    {
        if (particles != null)
        {
         GameObject spawnedPartc=   Instantiate(particles);
         spawnedPartc.transform.position = transform.position;
        }
        Destroy(gameObject);
    }

}
