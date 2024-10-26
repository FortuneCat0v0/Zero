namespace ET.Server
{
	[MessageLocationHandler(SceneType.Map)]
	public class C2M_TransferMapHandler : MessageLocationHandler<Unit, C2M_TransferMap, M2C_TransferMap>
	{
		protected override async ETTask Run(Unit chatUnit, C2M_TransferMap request, M2C_TransferMap response)
		{
			await ETTask.CompletedTask;

			string currentMap = chatUnit.Scene().Name;
			string toMap = null;
			if (currentMap == "Map1")
			{
				toMap = "Map2";
			}
			else
			{
				toMap = "Map1";
			}

			StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(chatUnit.Fiber().Zone, toMap);
			
			TransferHelper.TransferAtFrameFinish(chatUnit, startSceneConfig.ActorId, toMap).Coroutine();
		}
	}
}