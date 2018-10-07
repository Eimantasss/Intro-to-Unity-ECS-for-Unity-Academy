using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AcademyHomework;

public class Movement : MonoBehaviour
{

    public float speed;
    public float hspeed;
    Vector3 position;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 position = transform.position;
        position += transform.up * speed * Time.deltaTime;
        position += transform.right * hspeed * Time.deltaTime;
        transform.position = position;

        //ckeching when to bounce off
        if (position.y > GameManager.GM.TopLeftBound.transform.position.y)
            speed = speed * -1;
         else if (position.y < GameManager.GM.BotRightBound.transform.position.y)
            speed = speed * -1;
        else if (position.x < GameManager.GM.TopLeftBound.transform.position.x)
            hspeed = hspeed * -1;
        else if (position.x > GameManager.GM.BotRightBound.transform.position.x)
            hspeed = hspeed * -1;
    }
}
