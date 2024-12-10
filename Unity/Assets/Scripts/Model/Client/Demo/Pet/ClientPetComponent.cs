using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class ClientPetComponent : Entity, IAwake, IDestroy
    {
        public Dictionary<long, EntityRef<Pet>> Pets = new();
    }
}