using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AcademyHomework
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager GM;

        int SpawnerCounter;
        public GameObject BadguyPrefab;

        //For checking when to bounce off of the edges
        public GameObject TopLeftBound;
        public GameObject BotRightBound;

        //Make sure there is only one manager
        private void Awake()
        {
            if (GM == null)
                GM = this;
            else if (GM != this)
                Destroy(gameObject);
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (SpawnerCounter < 10000)
                //Instantiate(BadguyPrefab, new Vector3(Random.Range(1, 2),0 ,0 ), transform.rotation);


            SpawnerCounter++;
        }
    }
}
