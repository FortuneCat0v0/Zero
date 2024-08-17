using System.Collections.Generic;
using System.Diagnostics;

namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class WatcherComponent: Entity, IAwake
    {
        public readonly Dictionary<int, Process> Processes = new Dictionary<int, Process>();
    }
}