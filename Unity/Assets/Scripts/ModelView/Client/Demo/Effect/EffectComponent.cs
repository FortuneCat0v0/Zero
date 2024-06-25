using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class EffectComponent : Entity, IAwake, IDestroy
    {
    }
}