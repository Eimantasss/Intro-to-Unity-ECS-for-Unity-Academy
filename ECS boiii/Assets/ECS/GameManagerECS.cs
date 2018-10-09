using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace AcademyHomework.ECS
{
    public class GameManagerECS : MonoBehaviour
    {

        public static GameManagerECS GM;

        //int SpawnerCounter;
        [Tooltip("Don't use more than 75 000. YOU HAVE BEEN WARNED!")]
        public int SpawnHowMany;

        public GameObject StotelePrefab;
        public GameObject BadguyPrefab;

        //For checking when to bounce off of the edges
        public GameObject TopLeftBound;
        public GameObject BotRightBound;

        EntityManager manager;

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
            manager = World.Active.GetOrCreateManager<EntityManager>();
            //SpawnStoteles();
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
            NativeArray<Entity> badguys = new NativeArray<Entity>(amount, Allocator.Temp);
            manager.Instantiate(BadguyPrefab, badguys);

            for (int i = 0; i < amount; i++)
            {
                float randX = UnityEngine.Random.Range(TopLeftBound.transform.position.x + 5, BotRightBound.transform.position.x - 5);
                float randY = UnityEngine.Random.Range(TopLeftBound.transform.position.y - 5, BotRightBound.transform.position.y + 5);

                float Vspeed = UnityEngine.Random.Range(-2.0f, 2.0f);
                float Hspeed = UnityEngine.Random.Range(-2.0f, 2.0f);

                manager.SetComponentData(badguys[i], new Position { Value = new float3(randX, randY, -0.1f) });
                manager.SetComponentData(badguys[i], new Rotation { Value = new quaternion(0, 0, 0, 0) });
                manager.SetComponentData(badguys[i], new MovementSpeed { Hspeed = Hspeed, Vspeed = Vspeed });
            }
            badguys.Dispose();
        }
    }
}
