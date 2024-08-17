using System.Collections.Generic;

namespace ET.Server
{
	[ComponentOf(typeof(Scene))]
	public class PlayerComponent : Entity, IAwake, IDestroy
	{
		public Dictionary<long, EntityRef<Player>> dictionary = new Dictionary<long, EntityRef<Player>>();
	}
}