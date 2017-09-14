using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy point bar handles its position on canvas according to owner
/// </summary>
public class EnemyPointBar : PointBarScript {

    public GameObject owner;
    [SerializeField] Vector3 offset = new Vector3(0, 30, 0);
    [SerializeField] float scaleFactor = 3f;
    Camera cam;
    

	// Use this for initialization
	void Start () {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

	}
	
	// Update is called once per frame
	void Update ()
    {

        //Update position of bar
        transform.position = cam.WorldToScreenPoint(owner.transform.position + offset);

        preserveScale();



    }

    //Scale of bar changes relative to owner when player moves while parent of bar is canvas of main cam
    //For preventing that affect set scale according to distance
    private void preserveScale()
    {
        //According to cam distance to owner object set scale of bar
        float distance = Vector3.Distance(owner.transform.position, cam.gameObject.transform.position);

        //Debug.Log("Distance is " + distance);
        float scale = 1 / (1 + distance);

        //Debug.Log("Scale is " + scale);

        transform.localScale = Vector3.one * scale * scaleFactor;
    }
    

}
