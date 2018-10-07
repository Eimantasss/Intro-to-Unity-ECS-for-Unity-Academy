using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed;
    public float hspeed;
    Vector3 position;

    //For checking when to bounce off of the edges
    public GameObject TopLeftBound;
    public GameObject BotRightBound;

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
        position += transform.right * hspeed * Time.deltaTime;
        transform.position = position;


        if (position.y > TopLeftBound.transform.position.y)
            speed = speed * -1;
        else if (position.y < BotRightBound.transform.position.y)
            speed = speed * -1;
        else if (position.x < TopLeftBound.transform.position.x)
            hspeed = hspeed * -1;
        else if (position.x > BotRightBound.transform.position.x)
            hspeed = hspeed * -1;
    }
}
