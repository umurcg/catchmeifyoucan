using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rocket additionally make damage around explosion position. 
/// </summary>

public class RocketBulletController : BulletController {

    [SerializeField] RocketArea area;





    protected override void OnTriggerEnter(Collider other)
    {
        //If hit object is owner or area then return
        if (other.gameObject == owner || area.gameObject==other.gameObject) return;

        //If hit object has DestroyableObject script than call damage function of it
        DestroyableObject destObj = other.gameObject.GetComponent<DestroyableObject>();
        if (destObj != null) destObj.Damage(damageAmount);

        Debug.Log(other.name + "is hit so destroying it self");

        //Implement area damage functionality
        List<DestroyableObject> destObjs = area.getDestroyableObjects();

        foreach (DestroyableObject obj in destObjs)
        {
            //If object is hit object than pass because you have already damaged that object
            if (destObj != null && obj == destObj) continue;

            obj.Damage(calculateDamage(obj.transform.position));
        }


        //When hit something other than owner explode
        Explode();
    }



    //Calculates damage according to distance of explotion
    float calculateDamage(Vector3 pos)
    {
        float distance = Vector3.Distance(transform.position, pos);

        //RAtio of distance and radius
        float ratio = distance / area.redius;

        //If distance == radius => damage will be 0
        //else if distance==0 => damage will be damageAmount

        return (1 - ratio) * damageAmount;

    }
    


}
