using System.Collections.Generic;
using Box2DSharp.Dynamics;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class CollisionWorldComponent : Entity, IAwake, IFixedUpdate, IDestroy
    {
        public Box2DSharp.Dynamics.World World;

        public List<Body> BodyToDestroy = new();

        public int VelocityIteration = 8;
        public int PositionIteration = 3;
    }
}