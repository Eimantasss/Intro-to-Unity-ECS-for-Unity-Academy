using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed;
    public float hspeed;
    Vector3 position;

    //For checking when to bounce off of the edges
    public GameObject TopBound;
    public GameObject BotBound;
    public GameObject LeftBound;
    public GameObject RightBound;
    float TopBoundPos;
    float BotBoundPos;
    float LeftBoundPos;
    float RightBoundPos;

    // Use this for initialization
    void Start ()
    {
        //Vector3 position = transform.position;
        //transform.Rotate(Vector3.forward, Random.Range(0.0f, 359.0f));
        TopBoundPos = TopBound.transform.position.y;
        BotBoundPos = BotBound.transform.position.y;
        LeftBoundPos = LeftBound.transform.position.x;
        RightBoundPos = RightBound.transform.position.x;
    }
	
	// Update is called once per frame
	void Update ()
    {

        Vector3 position = transform.position;
        position += transform.up * speed * Time.deltaTime;
        position += transform.right * hspeed * Time.deltaTime;
        transform.position = position;


        if (position.y > TopBoundPos)
            speed = speed * -1;
        else if (position.y < BotBoundPos)
            speed = speed * -1;
        else if (position.x < LeftBoundPos)
            hspeed = hspeed * -1;
        else if (position.x > RightBoundPos)
            hspeed = hspeed * -1;
    }
}
