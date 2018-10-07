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
        speed = Random.Range(-2.0f, 2.0f);
        hspeed = Random.Range(-2.0f, 2.0f);
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        position += transform.up * speed * Time.deltaTime;
        position += transform.right * hspeed * Time.deltaTime;
        transform.position = position;

        //ckeching when to bounce off the edges
        if(position.x > GameManager.GM.TopLeftBound.transform.position.x + 5 || 
           position.x < GameManager.GM.BotRightBound.transform.position.x - 5 ||
           position.y > GameManager.GM.TopLeftBound.transform.position.y - 5 || 
           position.y < GameManager.GM.BotRightBound.transform.position.y + 5)
            CollisionDetection(position);
    }

    void CollisionDetection(Vector3 position)
    {
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
