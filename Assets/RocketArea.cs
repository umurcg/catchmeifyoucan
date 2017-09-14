using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Collects all damagable objects that enters collider.
/// It is used for area damage when rocket bullet explodes
/// </summary>
[RequireComponent(typeof(SphereCollider))]
public class RocketArea : MonoBehaviour {

    List<DestroyableObject> destroyableObjects;
    [HideInInspector] public float redius;

    SphereCollider sc;


	// Use this for initialization
	void Start () {
        destroyableObjects = new List<DestroyableObject>();

        sc = GetComponent<SphereCollider>();
        redius = sc.radius* transform.localScale.x;

	}

    private void OnTriggerEnter(Collider other)
    {
        DestroyableObject destObj = other.GetComponent<DestroyableObject>();
        if(destObj!=null)
            destroyableObjects.Add(destObj);

    }



    private void OnTriggerExit(Collider other)
    {
        DestroyableObject destObj = other.GetComponent<DestroyableObject>();
        if (destObj != null&& destroyableObjects.Contains(destObj))
            destroyableObjects.Remove(destObj);

    }

    public List<DestroyableObject> getDestroyableObjects()
    {
        return destroyableObjects;
    }

}
