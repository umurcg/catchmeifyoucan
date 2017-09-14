using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Wall moves between two points
/// </summary>
public class MovinWall : MonoBehaviour {

    [SerializeField] float moveSpeed=3f;
    [SerializeField] GameObject point1, point2;

    bool increasing = true;
    float ratio = 0;

	// Use this for initialization
	void Start () {
        transform.position = point1.transform.position;
	}

    // Update is called once per frame
    void Update() {

        ratio = (increasing) ? ratio + Time.deltaTime * moveSpeed : ratio - Time.deltaTime * moveSpeed;
        transform.position = Vector3.Lerp(point1.transform.position, point2.transform.position,ratio);

        if (ratio > 1)
            increasing = false;
        else if (ratio < 0)
            increasing = true;


	}
}
