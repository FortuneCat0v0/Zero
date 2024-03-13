namespace ET.Server
{
	/// <summary>
	/// 当与Gate的连接断开是因为顶号操作，则KickPlayer
	/// </summary>
	[ComponentOf(typeof(Session))]
	public class SessionPlayerComponent : Entity, IAwake, IDestroy
	{
		public bool IsLoginAgain = false;
		
		private EntityRef<Player> player;

		public Player Player
		{
			get
			{
				return this.player;
			}
			set
			{
				this.player = value;
			}
		}
	}
}