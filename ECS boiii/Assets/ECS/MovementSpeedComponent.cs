using System;
using System.Collections.Generic;
using Unity.Entities;

namespace AcademyHomework.ECS
{
    [Serializable]
    public struct MovementSpeed : IComponentData
    {
        public float Vspeed;
        public float Hspeed;
    }
    public class MovementSpeedComponent : ComponentDataWrapper<MovementSpeed> { }
}
