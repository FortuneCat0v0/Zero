using System.Collections.Generic;
using Box2DSharp.Dynamics;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class CollisionWorldComponent : Entity, IAwake, IFixedUpdate, IDestroy
    {
        public Box2DSharp.Dynamics.World World;

        public List<Body> BodyToDestroy = new();

        public int VelocityIteration = 10;
        public int PositionIteration = 10;
    }
}