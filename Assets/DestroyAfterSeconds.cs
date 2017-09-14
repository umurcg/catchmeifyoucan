using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour {

    [SerializeField] float timeToDestroy = 5f;
    Timer timer;

	// Use this for initialization
	void Start () {
        timer = new Timer(timeToDestroy);
		
	}
	
	// Update is called once per frame
	void Update () {

        if (timer.ticTac(Time.deltaTime)) Destroy(gameObject);
	}
}
