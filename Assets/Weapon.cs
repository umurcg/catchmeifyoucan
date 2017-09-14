using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains weapon functionality; force calculations and spawning
/// </summary>

public class Weapon : MonoBehaviour {

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject barrelPosition;
    [SerializeField] float refillTime;

    //Makes an effects like kick back when weapon is fired
    [SerializeField] bool kickBackWeapon=true;
    [SerializeField] float kickBackAngle=30;
    [SerializeField] float rotateSpeed=1;

    

    Timer timer;
    protected bool refilling = false;
    [SerializeField] GameObject owner;


    // Use this for initialization
    void Start()
    {

        if (bulletPrefab.GetComponent<BulletController>() == null)
        {
            //Debug.Log("Bullet should have bullet controller");
            gameObject.SetActive(false);
        }

        timer = new Timer(refillTime);

    }

    private void Update()
    {
        if(refilling && timer.ticTac(Time.deltaTime))
        {
            timer.resetTimet();
            refilling = false;
        }
    }

    public void Shoot()
    {
        //If refilling gun then can't shoot
        if (refilling) return;

        //Instantiate bullet at barrelPosition
        GameObject spawnedBullet = Instantiate(bulletPrefab);
        spawnedBullet.transform.position = barrelPosition.transform.position;

        
        //Bullet direction is barrel position forward direction
        Vector3 direction = barrelPosition.transform.forward;

        //Make bullet look to bullet direction
        spawnedBullet.transform.LookAt(spawnedBullet.transform.position + direction);

        //Apply force towards bullet direction
        Rigidbody rb = spawnedBullet.GetComponent<Rigidbody>();

        BulletController bc = spawnedBullet.GetComponent<BulletController>();
                

        //Set owner
        bc.setOwner(owner);

        bc.shoot();

        if (kickBackWeapon) StartCoroutine(kickBack());

        float forceAmount = bc.getForce();
        rb.AddForce(direction * forceAmount, ForceMode.Impulse);

        refilling = true;
        


    }

    public bool isRefilling() { return refilling; }

    IEnumerator kickBack()
    {
        float ratio = 0;
        Quaternion originalRot = transform.rotation;

        while (ratio < kickBackAngle)
        {
            ratio += Time.deltaTime * rotateSpeed;
            transform.RotateAround(transform.position, transform.right, -1*Time.deltaTime * rotateSpeed);
            yield return null;
        }


        while (ratio > 0)
        {
            ratio -= Time.deltaTime * rotateSpeed;
            transform.RotateAround(transform.position, transform.right, Time.deltaTime * rotateSpeed);
            yield return null;
        }

        transform.rotation = originalRot;
        
        yield break;
    }

}
