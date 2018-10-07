using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AcademyHomework;

public class Movement : MonoBehaviour
{

    public float vspeed;
    public float hspeed;
    Vector3 position;

    public GameObject[] GoodGuys;

    // Use this for initialization
    void Start()
    {
        vspeed = Random.Range(-2.0f, 2.0f);
        hspeed = Random.Range(-2.0f, 2.0f);
        position = transform.position;

        GoodGuys = GameObject.FindGameObjectsWithTag("GoodGuy");
    }

    // Update is called once per frame
    void Update()
    {

        position += transform.up * vspeed * Time.deltaTime;
        position += transform.right * hspeed * Time.deltaTime;
        transform.position = position;

        //check how close to bus stop
        DistanceFromGoodGuy();
        
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
            vspeed *= -1;
        else if (position.y < GameManager.GM.BotRightBound.transform.position.y)
            vspeed *= -1;
        else if (position.x < GameManager.GM.TopLeftBound.transform.position.x)
            hspeed *= -1;
        else if (position.x > GameManager.GM.BotRightBound.transform.position.x)
            hspeed *= -1;
    }

    void DistanceFromGoodGuy()
    {
        //1.5F is an optimal distance when to start checking collisions
        float distance;
        for(int i = 0; i < GoodGuys.Length; i++)
        {
            distance = Mathf.Sqrt(Mathf.Pow(GoodGuys[i].transform.position.x - position.x, 2) + Mathf.Pow(GoodGuys[i].transform.position.y - position.y, 2));
            if (distance < 1.5f)
                AvoidManeuvers(position, GoodGuys[i].transform.position);//start coliding when close enough
        }
    }

    void AvoidManeuvers(Vector3 position, Vector3 AvoidMe)
    {
        if(position.y < AvoidMe.y + 1.5f || position.y > AvoidMe.y - 1.5f) //if badguy is approaching goodguy vertically
            vspeed *= -1;
        if(position.x < AvoidMe.x + 1.5f || position.x > AvoidMe.x - 1.5f) //if badguy is approaching goodguy horizontally
            hspeed *= -1;
    }
}