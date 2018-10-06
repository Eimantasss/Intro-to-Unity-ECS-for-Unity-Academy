using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed;
    Vector3 position;

    static GameObject TopBound;
    float TopBoundPos = TopBound.transform.position.x;

    // Use this for initialization
    void Start ()
    {
        //Vector3 position = transform.position;
        //transform.Rotate(Vector3.forward, Random.Range(0.0f, 359.0f));
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 position = transform.position;
        position += transform.up * speed * Time.deltaTime;
        transform.position = position;

        if (position.x < TopBoundPos)
            speed = speed * -1;
	}
}
