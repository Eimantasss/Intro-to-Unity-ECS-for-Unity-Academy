using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AcademyHomework
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager GM;

        //int SpawnerCounter;
        [Tooltip("Don't use more than 75 000. YOU HAVE BEEN WARNED!")]
        public int SpawnHowMany;

        public GameObject StotelePrefab;
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

            SpawnStoteles();
            SpawnEnemies (SpawnHowMany);

        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void SpawnStoteles()
        {
            float[] coordsp = { -50.0f, 0.0f, 50.0f, -50.0f, 0.0f, 50.0f};
            float y = 20.0f;
            for (int i = 0; i < 6; i++)
            {
                Instantiate(StotelePrefab, new Vector3(coordsp[i], y, -0.1f), transform.rotation);
                y *= -1;
            }
        }

        void SpawnEnemies (int amount)
        {

            for (int i = 0; i <= amount; i++)
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
