using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed;
    Vector3 position;

    // Use this for initialization
    void Start ()
    {
        //Vector3 position = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 position = transform.position;
        position += -transform.up * speed * Time.deltaTime;
        transform.position = position;
	}
}
