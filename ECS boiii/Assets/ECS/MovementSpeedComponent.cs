using System;
using System.Collections.Generic;
using Unity.Entities;

namespace AcademyHomework.ECS
{
    //[Serializable]
    public struct MovementSpeed : IComponentData
    {
        public float Vvalue;
        public float Hvalue;
    }
    public class MovementSpeedComponent : ComponentDataWrapper<MovementSpeed> { }
}
