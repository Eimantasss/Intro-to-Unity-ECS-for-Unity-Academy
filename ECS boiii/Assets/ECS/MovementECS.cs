using UnityEngine;
using Unity.Jobs;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Mathematics;

namespace AcademyHomework.ECS
{
    public class MovementECS : JobComponentSystem
    {
        [ComputeJobOptimization]
        struct MovementJob : IJobProcessComponentData<Position, Rotation, MovementSpeed>
        {
            public float TopBound;
            public float BotBound;
            public float LeftBound;
            public float RightBound;
            public float deltaTime;

            public void Execute(ref Position position, [ReadOnly] ref Rotation rotation, ref MovementSpeed movementSpeed)
            {
                float3 pos = position.Value;

                pos += deltaTime * movementSpeed.Vspeed * math.forward(rotation.Value);
                pos += deltaTime * movementSpeed.Hspeed * math.forward(rotation.Value);

                //starting checking collisions with bounds when close enough to the bounds
                if (pos.x > RightBound + 5 || pos.x < LeftBound - 5 || pos.y > TopBound - 5 || pos.y < BotBound + 5)
                {
                    //change direction depending on which bound is hit
                    if (pos.y > TopBound)
                        movementSpeed.Vspeed *= -1;
                    else if (pos.y < BotBound)
                        movementSpeed.Vspeed *= -1;
                    else if (pos.x < LeftBound)
                        movementSpeed.Hspeed *= -1;
                    else if (pos.x > RightBound)
                        movementSpeed.Hspeed *= -1;
                }
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            MovementJob moveIt = new MovementJob
            {
                TopBound = GameManagerECS.GM.TopLeftBound.transform.position.y,
                BotBound = GameManagerECS.GM.BotRightBound.transform.position.y,
                LeftBound = GameManagerECS.GM.TopLeftBound.transform.position.x,
                RightBound = GameManagerECS.GM.BotRightBound.transform.position.x,
                deltaTime = Time.deltaTime
            };

            JobHandle moveHandle = moveIt.Schedule(this, 64, inputDeps);

            return moveHandle;
        }
    }
}
