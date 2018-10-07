using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AcademyHomework
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager GM;

        [Tooltip("Don't use more than 75 000. YOU HAVE BEEN WARNED!")]
        public int SpawnHowMany;

        //int SpawnerCounter;
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
            Spawn (SpawnHowMany);
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void Spawn (int amount)
        {

            for (int i = 0; i < amount; i++)
                Instantiate(BadguyPrefab,
                new Vector3(
                    Random.Range(TopLeftBound.transform.position.x + 5, BotRightBound.transform.position.x - 5),
                    Random.Range(TopLeftBound.transform.position.y - 5, BotRightBound.transform.position.y + 5),
                    -0.1f),
                transform.rotation,
                GM.transform);
        }
    }
}
