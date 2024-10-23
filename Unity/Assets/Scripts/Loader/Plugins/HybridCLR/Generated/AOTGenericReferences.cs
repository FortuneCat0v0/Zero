using System.Collections.Generic;
public class AOTGenericReferences : UnityEngine.MonoBehaviour
{

	// {{ AOT assemblies
	public static readonly IReadOnlyList<string> PatchedAOTAssemblyList = new List<string>
	{
		"DOTween.dll",
		"MemoryPack.dll",
		"MongoDB.Bson.dll",
		"System.Core.dll",
		"System.Runtime.CompilerServices.Unsafe.dll",
		"System.dll",
		"Unity.Core.dll",
		"Unity.ThirdParty.dll",
		"UnityEngine.CoreModule.dll",
		"YIUIFramework.dll",
		"YooAsset.dll",
		"mscorlib.dll",
	};
	// }}

	// {{ constraint implement type
	// }} 

	// {{ AOT generic types
	// ET.AEvent<object,ET.AfterCreateClientScene>
	// ET.AEvent<object,ET.AfterUnitCreate>
	// ET.AEvent<object,ET.AppStartInitFinish>
	// ET.AEvent<object,ET.ChangeEquipItem>
	// ET.AEvent<object,ET.ChangePosition>
	// ET.AEvent<object,ET.ChangeRotation>
	// ET.AEvent<object,ET.Client.LSSceneChangeStart>
	// ET.AEvent<object,ET.Client.LSSceneInitFinish>
	// ET.AEvent<object,ET.Client.OnPatchDownloadFailed>
	// ET.AEvent<object,ET.Client.OnPatchDownloadOver>
	// ET.AEvent<object,ET.Client.OnPatchDownloadProgress>
	// ET.AEvent<object,ET.Client.PlayEffect>
	// ET.AEvent<object,ET.Client.PlaySound>
	// ET.AEvent<object,ET.Client.RemoveEffect>
	// ET.AEvent<object,ET.Client.ShowErrorTip>
	// ET.AEvent<object,ET.Client.ShowItemTips>
	// ET.AEvent<object,ET.Client.StartHotUpDate>
	// ET.AEvent<object,ET.EnterMapFinish>
	// ET.AEvent<object,ET.EntryEvent1>
	// ET.AEvent<object,ET.EntryEvent3>
	// ET.AEvent<object,ET.HitResult>
	// ET.AEvent<object,ET.LoginFinish>
	// ET.AEvent<object,ET.MoveStart>
	// ET.AEvent<object,ET.MoveStop>
	// ET.AEvent<object,ET.NumericChange>
	// ET.AEvent<object,ET.SceneChangeFinish>
	// ET.AEvent<object,ET.SceneChangeStart>
	// ET.AEvent<object,ET.UnitGetComponent>
	// ET.AInvokeHandler<ET.FiberInit,object>
	// ET.AInvokeHandler<ET.MailBoxInvoker>
	// ET.AInvokeHandler<ET.NetComponentOnRead>
	// ET.AInvokeHandler<ET.TimerCallback>
	// ET.AwakeSystem<object,ET.Client.EffectData>
	// ET.AwakeSystem<object,int,int>
	// ET.AwakeSystem<object,int>
	// ET.AwakeSystem<object,long>
	// ET.AwakeSystem<object,object,int>
	// ET.AwakeSystem<object,object,object>
	// ET.AwakeSystem<object,object>
	// ET.AwakeSystem<object>
	// ET.Client.IYIUIEvent<ET.Client.EventPutTipsView>
	// ET.Client.IYIUIEvent<ET.Client.OnClickChildListEvent>
	// ET.Client.IYIUIEvent<ET.Client.OnClickItemEvent>
	// ET.Client.IYIUIEvent<ET.Client.OnClickParentListEvent>
	// ET.Client.IYIUIEvent<ET.Client.OnGMEventClose>
	// ET.Client.IYIUIOpen<object,object,object>
	// ET.Client.IYIUIOpen<object>
	// ET.Client.YIUIBindSystem<object>
	// ET.Client.YIUICloseTweenSystem<object>
	// ET.Client.YIUIEventSystem<object,ET.Client.EventPutTipsView>
	// ET.Client.YIUIEventSystem<object,ET.Client.OnClickChildListEvent>
	// ET.Client.YIUIEventSystem<object,ET.Client.OnClickItemEvent>
	// ET.Client.YIUIEventSystem<object,ET.Client.OnClickParentListEvent>
	// ET.Client.YIUIEventSystem<object,ET.Client.OnGMEventClose>
	// ET.Client.YIUIInitializeSystem<object>
	// ET.Client.YIUIOpenSystem<object,object,object,object>
	// ET.Client.YIUIOpenSystem<object,object>
	// ET.Client.YIUIOpenSystem<object>
	// ET.Client.YIUIOpenTweenSystem<object>
	// ET.DeserializeSystem<object>
	// ET.DestroySystem<object>
	// ET.DoubleMap<object,long>
	// ET.ETAsyncTaskMethodBuilder<ET.Client.WaitType.Wait_Room2C_Start>
	// ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_CreateMyUnit>
	// ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_SceneChangeFinish>
	// ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_UnitStop>
	// ET.ETAsyncTaskMethodBuilder<ET.EntityRef<object>>
	// ET.ETAsyncTaskMethodBuilder<System.ValueTuple<uint,object>>
	// ET.ETAsyncTaskMethodBuilder<byte>
	// ET.ETAsyncTaskMethodBuilder<int>
	// ET.ETAsyncTaskMethodBuilder<long>
	// ET.ETAsyncTaskMethodBuilder<object>
	// ET.ETAsyncTaskMethodBuilder<uint>
	// ET.ETTask<ET.Client.WaitType.Wait_Room2C_Start>
	// ET.ETTask<ET.Client.Wait_CreateMyUnit>
	// ET.ETTask<ET.Client.Wait_SceneChangeFinish>
	// ET.ETTask<ET.Client.Wait_UnitStop>
	// ET.ETTask<ET.EntityRef<object>>
	// ET.ETTask<System.ValueTuple<uint,object>>
	// ET.ETTask<byte>
	// ET.ETTask<int>
	// ET.ETTask<long>
	// ET.ETTask<object>
	// ET.ETTask<uint>
	// ET.EntityRef<object>
	// ET.GetComponentSysSystem<object>
	// ET.IAwake<ET.Client.EffectData>
	// ET.IAwake<ET.CreateColliderParams>
	// ET.IAwake<int,int>
	// ET.IAwake<int>
	// ET.IAwake<long>
	// ET.IAwake<object,int>
	// ET.IAwake<object,object,object>
	// ET.IAwake<object,object>
	// ET.IAwake<object>
	// ET.IAwakeSystem<ET.Client.EffectData>
	// ET.IAwakeSystem<int,int>
	// ET.IAwakeSystem<int>
	// ET.IAwakeSystem<long>
	// ET.IAwakeSystem<object,int>
	// ET.IAwakeSystem<object,object,object>
	// ET.IAwakeSystem<object,object>
	// ET.IAwakeSystem<object>
	// ET.LateUpdateSystem<object>
	// ET.ListComponent<Unity.Mathematics.float3>
	// ET.Singleton<object>
	// ET.StateMachineWrap<ET.Client.A2C_DisconnectHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.A2NetClient_MessageHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.A2NetClient_RequestHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.AE_PlayEffect.<Execute>d__0>
	// ET.StateMachineWrap<ET.Client.AE_PlaySound.<Execute>d__0>
	// ET.StateMachineWrap<ET.Client.AfterCreateClientScene_LSAddComponent.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.AfterUnitCreate_CreateUnitView.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.AppStartInitFinish_CreateLoginUI.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.AppStartInitFinish_CreateUILSLogin.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.ChangePosition_SyncGameObjectPos.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.ChangeRotation_SyncGameObjectRotation.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.ClientSenderComponentSystem.<Call>d__8>
	// ET.StateMachineWrap<ET.Client.ClientSenderComponentSystem.<ConnectAccountAsync>d__4>
	// ET.StateMachineWrap<ET.Client.ClientSenderComponentSystem.<DisposeAsync>d__3>
	// ET.StateMachineWrap<ET.Client.ClientSenderComponentSystem.<EnterGameAsync>d__5>
	// ET.StateMachineWrap<ET.Client.ClientSenderComponentSystem.<LoginAsync>d__6>
	// ET.StateMachineWrap<ET.Client.ClientSenderComponentSystem.<RemoveFiberAsync>d__2>
	// ET.StateMachineWrap<ET.Client.CommonPanelComponentSystem.<YIUIOpen>d__2>
	// ET.StateMachineWrap<ET.Client.EnterMapHelper.<EnterMapAsync>d__0>
	// ET.StateMachineWrap<ET.Client.EnterMapHelper.<Match>d__1>
	// ET.StateMachineWrap<ET.Client.EntryEvent3_InitClient.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.EntryEvent3_InitClient.<StartHotUpdate>d__1>
	// ET.StateMachineWrap<ET.Client.FiberInit_NetClient.<Handle>d__0>
	// ET.StateMachineWrap<ET.Client.FlyTipComponentSystem.<OnAwake>d__3>
	// ET.StateMachineWrap<ET.Client.G2C_ReconnectHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.GMCommandComponentSystem.<Run>d__5>
	// ET.StateMachineWrap<ET.Client.GMCommandItemComponentSystem.<WaitRefresh>d__6>
	// ET.StateMachineWrap<ET.Client.GMPanelComponentSystem.<YIUIOpen>d__5>
	// ET.StateMachineWrap<ET.Client.GMViewComponentSystem.<YIUIEvent>d__2>
	// ET.StateMachineWrap<ET.Client.GMViewComponentSystem.<YIUIOpen>d__3>
	// ET.StateMachineWrap<ET.Client.GM_OpenReddotPanel.<Run>d__1>
	// ET.StateMachineWrap<ET.Client.GM_Test.<Run>d__1>
	// ET.StateMachineWrap<ET.Client.GM_TipsTest1.<Run>d__1>
	// ET.StateMachineWrap<ET.Client.GM_TipsTest2.<Run>d__1>
	// ET.StateMachineWrap<ET.Client.GM_TipsTest3.<Run>d__1>
	// ET.StateMachineWrap<ET.Client.GM_TipsTest4.<Run>d__1>
	// ET.StateMachineWrap<ET.Client.GM_TipsTest5.<Run>d__1>
	// ET.StateMachineWrap<ET.Client.GameObjectPoolHelper.<GetGameObjectAsync>d__5>
	// ET.StateMachineWrap<ET.Client.GameObjectPoolHelper.<GetObjectFromPoolAsync>d__2>
	// ET.StateMachineWrap<ET.Client.HitResult_View.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.HotUpdatePanelComponentSystem.<YIUIOpen>d__2>
	// ET.StateMachineWrap<ET.Client.HttpClientHelper.<Get>d__0>
	// ET.StateMachineWrap<ET.Client.JoystickViewComponentSystem.<YIUIOpen>d__2>
	// ET.StateMachineWrap<ET.Client.LSSceneChangeHelper.<SceneChangeTo>d__0>
	// ET.StateMachineWrap<ET.Client.LSSceneChangeHelper.<SceneChangeToReconnect>d__2>
	// ET.StateMachineWrap<ET.Client.LSSceneChangeHelper.<SceneChangeToReplay>d__1>
	// ET.StateMachineWrap<ET.Client.LSSceneChangeStart_AddComponent.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.LSSceneInitFinish_Finish.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.LSUnitViewComponentSystem.<InitAsync>d__2>
	// ET.StateMachineWrap<ET.Client.LobbyPanelComponentSystem.<OnEventEnterAction>d__3>
	// ET.StateMachineWrap<ET.Client.LobbyPanelComponentSystem.<YIUIOpen>d__2>
	// ET.StateMachineWrap<ET.Client.LoginFinish_CreateLobbyUI.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.LoginFinish_CreateUILSLobby.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.LoginFinish_RemoveLoginUI.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.LoginFinish_RemoveUILSLogin.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.LoginHelper.<CreateRole>d__3>
	// ET.StateMachineWrap<ET.Client.LoginHelper.<DeleteRole>d__4>
	// ET.StateMachineWrap<ET.Client.LoginHelper.<EnterGame>d__6>
	// ET.StateMachineWrap<ET.Client.LoginHelper.<GetRealmKey>d__5>
	// ET.StateMachineWrap<ET.Client.LoginHelper.<GetRoles>d__2>
	// ET.StateMachineWrap<ET.Client.LoginHelper.<GetServerInfos>d__1>
	// ET.StateMachineWrap<ET.Client.LoginHelper.<Login>d__7>
	// ET.StateMachineWrap<ET.Client.LoginHelper.<LoginAccount>d__0>
	// ET.StateMachineWrap<ET.Client.LoginPanelComponentSystem.<OnEventLoginAction>d__8>
	// ET.StateMachineWrap<ET.Client.LoginPanelComponentSystem.<OnLogin>d__11>
	// ET.StateMachineWrap<ET.Client.LoginPanelComponentSystem.<OnTapTapBtn>d__9>
	// ET.StateMachineWrap<ET.Client.LoginPanelComponentSystem.<YIUIOpen>d__5>
	// ET.StateMachineWrap<ET.Client.M2C_AllItemsHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_CreateMyUnitHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_CreateUnitsHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_HitResultHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_ItemUpdateOpHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_NoticeUnitNumericHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_PathfindingResultHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_RemoveUnitsHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_SkillUpdateOpHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_SpellSkillHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_StartSceneChangeHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.M2C_StopHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.Main2NetClient_ConnectAccountHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.Main2NetClient_EnterGameHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.Main2NetClient_LoginHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.MainPanelComponentSystem.<YIUIOpen>d__2>
	// ET.StateMachineWrap<ET.Client.MaskWordComponentSystem.<InitMaskWord>d__1>
	// ET.StateMachineWrap<ET.Client.MaskWordComponentSystem.<InitMaskWordText>d__2>
	// ET.StateMachineWrap<ET.Client.Match2G_NotifyMatchSuccessHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.MessageTipsViewComponentSystem.<YIUICloseTween>d__7>
	// ET.StateMachineWrap<ET.Client.MessageTipsViewComponentSystem.<YIUIOpen>d__5>
	// ET.StateMachineWrap<ET.Client.MessageTipsViewComponentSystem.<YIUIOpen>d__8>
	// ET.StateMachineWrap<ET.Client.MessageTipsViewComponentSystem.<YIUIOpenTween>d__6>
	// ET.StateMachineWrap<ET.Client.MiniMapViewComponentSystem.<OnEnterScene>d__4>
	// ET.StateMachineWrap<ET.Client.MiniMapViewComponentSystem.<YIUIOpen>d__3>
	// ET.StateMachineWrap<ET.Client.MoveHelper.<MoveToAsync>d__0>
	// ET.StateMachineWrap<ET.Client.MoveHelper.<MoveToAsync>d__1>
	// ET.StateMachineWrap<ET.Client.MoveStart_Animator.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.MoveStop_Animator.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.NetClient2Main_SessionDisposeHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.OnPatchDownloadFailed_ShowFailedInfo.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.OnPatchDownloadOver_Reset.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.OnPatchDownloadProgress_UpdateProgress.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.OneFrameInputsHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.OperaComponentSystem.<Test1>d__2>
	// ET.StateMachineWrap<ET.Client.OperaComponentSystem.<Test2>d__3>
	// ET.StateMachineWrap<ET.Client.PingComponentSystem.<PingAsync>d__2>
	// ET.StateMachineWrap<ET.Client.PlayEffect_PlayView.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.PlaySound_PlayView.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.PopupTextPanelComponentSystem.<YIUIOpen>d__5>
	// ET.StateMachineWrap<ET.Client.RedDotPanelComponentSystem.<YIUIEvent>d__6>
	// ET.StateMachineWrap<ET.Client.RedDotPanelComponentSystem.<YIUIEvent>d__7>
	// ET.StateMachineWrap<ET.Client.RedDotPanelComponentSystem.<YIUIEvent>d__8>
	// ET.StateMachineWrap<ET.Client.RedDotPanelComponentSystem.<YIUIOpen>d__5>
	// ET.StateMachineWrap<ET.Client.RemoveEffect_RemoveView.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.ResourcesLoaderComponentSystem.<DownloadWebFilesAsync>d__12>
	// ET.StateMachineWrap<ET.Client.ResourcesLoaderComponentSystem.<LoadAllAssetsAsync>d__5<object>>
	// ET.StateMachineWrap<ET.Client.ResourcesLoaderComponentSystem.<LoadAssetAsync>d__4<object>>
	// ET.StateMachineWrap<ET.Client.ResourcesLoaderComponentSystem.<LoadSceneAsync>d__8>
	// ET.StateMachineWrap<ET.Client.ResourcesLoaderComponentSystem.<LoadSubAssetsAsync>d__6<object>>
	// ET.StateMachineWrap<ET.Client.ResourcesLoaderComponentSystem.<UpdateManifestAsync>d__10>
	// ET.StateMachineWrap<ET.Client.ResourcesLoaderComponentSystem.<UpdateVersionAsync>d__9>
	// ET.StateMachineWrap<ET.Client.Room2C_AdjustUpdateTimeHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.Room2C_CheckHashFailHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.Room2C_StartHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.RouterAddressComponentSystem.<GetAllRouter>d__2>
	// ET.StateMachineWrap<ET.Client.RouterAddressComponentSystem.<Init>d__1>
	// ET.StateMachineWrap<ET.Client.RouterAddressComponentSystem.<WaitTenMinGetAllRouter>d__3>
	// ET.StateMachineWrap<ET.Client.RouterCheckComponentSystem.<CheckAsync>d__1>
	// ET.StateMachineWrap<ET.Client.RouterHelper.<Connect>d__2>
	// ET.StateMachineWrap<ET.Client.RouterHelper.<CreateRouterSession>d__0>
	// ET.StateMachineWrap<ET.Client.RouterHelper.<GetRouterAddress>d__1>
	// ET.StateMachineWrap<ET.Client.SceneChangeFinishEvent.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.SceneChangeHelper.<SceneChangeTo>d__0>
	// ET.StateMachineWrap<ET.Client.SceneChangeStartEvent.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.ShowErrorTip_CreateView.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.StartHotUpDate_CreatHotUpdateUI.<Run>d__0>
	// ET.StateMachineWrap<ET.Client.TapTapSDKHelper.<Login>d__1>
	// ET.StateMachineWrap<ET.Client.TextTipsViewComponentSystem.<PlayAnimation>d__6>
	// ET.StateMachineWrap<ET.Client.TextTipsViewComponentSystem.<YIUIOpen>d__5>
	// ET.StateMachineWrap<ET.Client.TipsHelper.<CloseTipsView>d__7>
	// ET.StateMachineWrap<ET.Client.TipsHelper.<Open>d__0<object>>
	// ET.StateMachineWrap<ET.Client.TipsHelper.<OpenToParent2NewVo>d__6<object>>
	// ET.StateMachineWrap<ET.Client.TipsHelper.<OpenToParent>d__2<object>>
	// ET.StateMachineWrap<ET.Client.TipsHelper.<OpenToParent>d__4<object>>
	// ET.StateMachineWrap<ET.Client.TipsPanelComponentSystem.<>c__DisplayClass5_0.<<OpenTips>g__Create|0>d>
	// ET.StateMachineWrap<ET.Client.TipsPanelComponentSystem.<OpenTips>d__5>
	// ET.StateMachineWrap<ET.Client.TipsPanelComponentSystem.<PutTips>d__6>
	// ET.StateMachineWrap<ET.Client.TipsPanelComponentSystem.<YIUIEvent>d__3>
	// ET.StateMachineWrap<ET.Client.TipsPanelComponentSystem.<YIUIOpen>d__2>
	// ET.StateMachineWrap<ET.Client.UIBagComponentSystem.<Refresh>d__2>
	// ET.StateMachineWrap<ET.Client.UIBagEvent.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UICommonItemSystem.<Refresh>d__1>
	// ET.StateMachineWrap<ET.Client.UIComponentSystem.<Create>d__1>
	// ET.StateMachineWrap<ET.Client.UIFlyTipEvent.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UIGMEvent.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UIGlobalComponentSystem.<OnCreate>d__1>
	// ET.StateMachineWrap<ET.Client.UIHelpEvent.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UIHelper.<>c__DisplayClass9_0.<<AddListenerAsync>g__clickAcionAsync|0>d>
	// ET.StateMachineWrap<ET.Client.UIHotUpdateEvent.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UILSLobbyComponentSystem.<EnterMap>d__1>
	// ET.StateMachineWrap<ET.Client.UILSLobbyEvent.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UILSLoginEvent.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UILSRoomEvent.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UILobbyComponentSystem.<EnterMap>d__1>
	// ET.StateMachineWrap<ET.Client.UILobbyEvent.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UILoginComponentSystem.<OnLogin>d__4>
	// ET.StateMachineWrap<ET.Client.UILoginComponentSystem.<OnNormalLoginBtn>d__1>
	// ET.StateMachineWrap<ET.Client.UILoginComponentSystem.<OnTapTapBtn>d__2>
	// ET.StateMachineWrap<ET.Client.UILoginEvent.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UIMainComponentSystem.<OnAchievementBtn>d__9>
	// ET.StateMachineWrap<ET.Client.UIMainComponentSystem.<OnBagBtn>d__4>
	// ET.StateMachineWrap<ET.Client.UIMainComponentSystem.<OnPetBtn>d__5>
	// ET.StateMachineWrap<ET.Client.UIMainComponentSystem.<OnSettingsBtn>d__2>
	// ET.StateMachineWrap<ET.Client.UIMainComponentSystem.<OnSkillBtn>d__6>
	// ET.StateMachineWrap<ET.Client.UIMainComponentSystem.<OnSocialBtn>d__8>
	// ET.StateMachineWrap<ET.Client.UIMainComponentSystem.<OnTaskBtn>d__7>
	// ET.StateMachineWrap<ET.Client.UIMainEvent.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UIMiniMapComponentSystem.<OnEnterScene>d__2>
	// ET.StateMachineWrap<ET.Client.UIModelShowSystem.<ShowModel>d__5>
	// ET.StateMachineWrap<ET.Client.UIRoleComponentSystem.<OnCreateBtn>d__1>
	// ET.StateMachineWrap<ET.Client.UIRoleComponentSystem.<OnDeleteBtn>d__2>
	// ET.StateMachineWrap<ET.Client.UIRoleComponentSystem.<OnEnterGameBtn>d__3>
	// ET.StateMachineWrap<ET.Client.UIRoleComponentSystem.<UpdateRoleList>d__4>
	// ET.StateMachineWrap<ET.Client.UIRolesEvent.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UIServerComponentSystem.<OnConfirmBtn>d__1>
	// ET.StateMachineWrap<ET.Client.UIServerComponentSystem.<ShowServerList>d__2>
	// ET.StateMachineWrap<ET.Client.UIServerEvent.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UISettingsEvent.<OnCreate>d__0>
	// ET.StateMachineWrap<ET.Client.UISkillGridSystem.<RefeshIcon>d__3>
	// ET.StateMachineWrap<ET.ConsoleComponentSystem.<Start>d__1>
	// ET.StateMachineWrap<ET.Entry.<StartAsync>d__2>
	// ET.StateMachineWrap<ET.EntryEvent1_InitShare.<Run>d__0>
	// ET.StateMachineWrap<ET.FiberInit_Main.<Handle>d__0>
	// ET.StateMachineWrap<ET.MailBoxType_OrderedMessageHandler.<HandleInner>d__1>
	// ET.StateMachineWrap<ET.MailBoxType_UnOrderedMessageHandler.<HandleAsync>d__1>
	// ET.StateMachineWrap<ET.MessageHandler.<Handle>d__1<object,object,object>>
	// ET.StateMachineWrap<ET.MessageHandler.<Handle>d__1<object,object>>
	// ET.StateMachineWrap<ET.MessageSessionHandler.<HandleAsync>d__2<object,object>>
	// ET.StateMachineWrap<ET.MessageSessionHandler.<HandleAsync>d__2<object>>
	// ET.StateMachineWrap<ET.MoveComponentSystem.<MoveToAsync>d__5>
	// ET.StateMachineWrap<ET.NumericChangeEvent_NotifyWatcher.<Run>d__0>
	// ET.StateMachineWrap<ET.ObjectWaitSystem.<>c__DisplayClass5_0.<<Wait>g__WaitTimeout|0>d<object>>
	// ET.StateMachineWrap<ET.ObjectWaitSystem.<Wait>d__4<object>>
	// ET.StateMachineWrap<ET.ObjectWaitSystem.<Wait>d__5<object>>
	// ET.StateMachineWrap<ET.ReloadConfigConsoleHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.ReloadDllConsoleHandler.<Run>d__0>
	// ET.StateMachineWrap<ET.RpcInfo.<Wait>d__7>
	// ET.StateMachineWrap<ET.SessionSystem.<>c__DisplayClass4_0.<<Call>g__Timeout|0>d>
	// ET.StateMachineWrap<ET.SessionSystem.<Call>d__3>
	// ET.StateMachineWrap<ET.SessionSystem.<Call>d__4>
	// ET.StructBsonSerialize<ET.LSInput>
	// ET.StructBsonSerialize<TrueSync.FP>
	// ET.StructBsonSerialize<TrueSync.TSQuaternion>
	// ET.StructBsonSerialize<TrueSync.TSVector2>
	// ET.StructBsonSerialize<TrueSync.TSVector4>
	// ET.StructBsonSerialize<TrueSync.TSVector>
	// ET.StructBsonSerialize<Unity.Mathematics.float2>
	// ET.StructBsonSerialize<Unity.Mathematics.float3>
	// ET.StructBsonSerialize<Unity.Mathematics.float4>
	// ET.StructBsonSerialize<Unity.Mathematics.quaternion>
	// ET.StructBsonSerialize<object>
	// ET.UnOrderMultiMap<object,object>
	// ET.UpdateSystem<object>
	// MemoryPack.Formatters.ArrayFormatter<ET.LSInput>
	// MemoryPack.Formatters.ArrayFormatter<byte>
	// MemoryPack.Formatters.ArrayFormatter<object>
	// MemoryPack.Formatters.DictionaryFormatter<int,long>
	// MemoryPack.Formatters.DictionaryFormatter<long,ET.LSInput>
	// MemoryPack.Formatters.ListFormatter<Unity.Mathematics.float3>
	// MemoryPack.Formatters.ListFormatter<int>
	// MemoryPack.Formatters.ListFormatter<long>
	// MemoryPack.Formatters.ListFormatter<object>
	// MemoryPack.IMemoryPackFormatter<Unity.Mathematics.float3>
	// MemoryPack.IMemoryPackFormatter<byte>
	// MemoryPack.IMemoryPackFormatter<int>
	// MemoryPack.IMemoryPackFormatter<long>
	// MemoryPack.IMemoryPackFormatter<object>
	// MemoryPack.IMemoryPackable<ET.LSInput>
	// MemoryPack.IMemoryPackable<object>
	// MemoryPack.MemoryPackFormatter<ET.LSInput>
	// MemoryPack.MemoryPackFormatter<System.UIntPtr>
	// MemoryPack.MemoryPackFormatter<object>
	// MongoDB.Bson.Serialization.IBsonSerializer<object>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<ET.LSInput>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<TrueSync.FP>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<TrueSync.TSQuaternion>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<TrueSync.TSVector2>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<TrueSync.TSVector4>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<TrueSync.TSVector>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<Unity.Mathematics.float2>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<Unity.Mathematics.float3>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<Unity.Mathematics.float4>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<Unity.Mathematics.quaternion>
	// MongoDB.Bson.Serialization.Serializers.SerializerBase<object>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<ET.LSInput>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<TrueSync.FP>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<TrueSync.TSQuaternion>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<TrueSync.TSVector2>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<TrueSync.TSVector4>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<TrueSync.TSVector>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<Unity.Mathematics.float2>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<Unity.Mathematics.float3>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<Unity.Mathematics.float4>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<Unity.Mathematics.quaternion>
	// MongoDB.Bson.Serialization.Serializers.StructSerializerBase<object>
	// System.Action<DotRecast.Detour.StraightPathItem>
	// System.Action<ET.EntityRef<object>>
	// System.Action<ET.MessageSessionDispatcherInfo>
	// System.Action<ET.NumericWatcherInfo>
	// System.Action<ET.vector2>
	// System.Action<ET.vector3>
	// System.Action<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Action<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Action<System.Numerics.Vector2>
	// System.Action<System.Numerics.Vector3>
	// System.Action<System.ValueTuple<long,long>>
	// System.Action<Unity.Mathematics.float3>
	// System.Action<byte,byte>
	// System.Action<byte>
	// System.Action<float>
	// System.Action<int,int>
	// System.Action<int,object>
	// System.Action<int>
	// System.Action<long,int>
	// System.Action<long,object>
	// System.Action<long>
	// System.Action<object,long>
	// System.Action<object,object>
	// System.Action<object>
	// System.ArraySegment.Enumerator<byte>
	// System.ArraySegment.Enumerator<ushort>
	// System.ArraySegment<byte>
	// System.ArraySegment<ushort>
	// System.ByReference<byte>
	// System.ByReference<ushort>
	// System.Collections.Concurrent.ConcurrentDictionary.<GetEnumerator>d__35<object,object>
	// System.Collections.Concurrent.ConcurrentDictionary.DictionaryEnumerator<object,object>
	// System.Collections.Concurrent.ConcurrentDictionary.Node<object,object>
	// System.Collections.Concurrent.ConcurrentDictionary.Tables<object,object>
	// System.Collections.Concurrent.ConcurrentDictionary<object,object>
	// System.Collections.Concurrent.ConcurrentQueue.<Enumerate>d__28<object>
	// System.Collections.Concurrent.ConcurrentQueue.Segment<object>
	// System.Collections.Concurrent.ConcurrentQueue<object>
	// System.Collections.Generic.ArraySortHelper<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.ArraySortHelper<ET.EntityRef<object>>
	// System.Collections.Generic.ArraySortHelper<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.ArraySortHelper<ET.NumericWatcherInfo>
	// System.Collections.Generic.ArraySortHelper<ET.vector2>
	// System.Collections.Generic.ArraySortHelper<ET.vector3>
	// System.Collections.Generic.ArraySortHelper<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.ArraySortHelper<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.ArraySortHelper<System.Numerics.Vector2>
	// System.Collections.Generic.ArraySortHelper<System.Numerics.Vector3>
	// System.Collections.Generic.ArraySortHelper<System.ValueTuple<long,long>>
	// System.Collections.Generic.ArraySortHelper<Unity.Mathematics.float3>
	// System.Collections.Generic.ArraySortHelper<float>
	// System.Collections.Generic.ArraySortHelper<int>
	// System.Collections.Generic.ArraySortHelper<long>
	// System.Collections.Generic.ArraySortHelper<object>
	// System.Collections.Generic.Comparer<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.Comparer<ET.ActorId>
	// System.Collections.Generic.Comparer<ET.EntityRef<object>>
	// System.Collections.Generic.Comparer<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.Comparer<ET.NumericWatcherInfo>
	// System.Collections.Generic.Comparer<ET.vector2>
	// System.Collections.Generic.Comparer<ET.vector3>
	// System.Collections.Generic.Comparer<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.Comparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.Comparer<System.Numerics.Vector2>
	// System.Collections.Generic.Comparer<System.Numerics.Vector3>
	// System.Collections.Generic.Comparer<System.ValueTuple<long,long>>
	// System.Collections.Generic.Comparer<Unity.Mathematics.float3>
	// System.Collections.Generic.Comparer<float>
	// System.Collections.Generic.Comparer<int>
	// System.Collections.Generic.Comparer<long>
	// System.Collections.Generic.Comparer<object>
	// System.Collections.Generic.Comparer<uint>
	// System.Collections.Generic.Comparer<ushort>
	// System.Collections.Generic.ComparisonComparer<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.ComparisonComparer<ET.ActorId>
	// System.Collections.Generic.ComparisonComparer<ET.EntityRef<object>>
	// System.Collections.Generic.ComparisonComparer<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.ComparisonComparer<ET.NumericWatcherInfo>
	// System.Collections.Generic.ComparisonComparer<ET.vector2>
	// System.Collections.Generic.ComparisonComparer<ET.vector3>
	// System.Collections.Generic.ComparisonComparer<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.ComparisonComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.ComparisonComparer<System.Numerics.Vector2>
	// System.Collections.Generic.ComparisonComparer<System.Numerics.Vector3>
	// System.Collections.Generic.ComparisonComparer<System.ValueTuple<long,long>>
	// System.Collections.Generic.ComparisonComparer<Unity.Mathematics.float3>
	// System.Collections.Generic.ComparisonComparer<float>
	// System.Collections.Generic.ComparisonComparer<int>
	// System.Collections.Generic.ComparisonComparer<long>
	// System.Collections.Generic.ComparisonComparer<object>
	// System.Collections.Generic.ComparisonComparer<uint>
	// System.Collections.Generic.ComparisonComparer<ushort>
	// System.Collections.Generic.Dictionary.Enumerator<int,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.Enumerator<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary.Enumerator<int,int>
	// System.Collections.Generic.Dictionary.Enumerator<int,long>
	// System.Collections.Generic.Dictionary.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.Enumerator<long,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.Enumerator<long,ET.LSInput>
	// System.Collections.Generic.Dictionary.Enumerator<long,long>
	// System.Collections.Generic.Dictionary.Enumerator<long,object>
	// System.Collections.Generic.Dictionary.Enumerator<object,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.Enumerator<object,YIUIFramework.YIUIBindVo>
	// System.Collections.Generic.Dictionary.Enumerator<object,float>
	// System.Collections.Generic.Dictionary.Enumerator<object,int>
	// System.Collections.Generic.Dictionary.Enumerator<object,long>
	// System.Collections.Generic.Dictionary.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.Enumerator<ushort,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,int>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,long>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<long,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<long,ET.LSInput>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<long,long>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<long,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,YIUIFramework.YIUIBindVo>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,float>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,int>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,long>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<ushort,object>
	// System.Collections.Generic.Dictionary.KeyCollection<int,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.KeyCollection<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary.KeyCollection<int,int>
	// System.Collections.Generic.Dictionary.KeyCollection<int,long>
	// System.Collections.Generic.Dictionary.KeyCollection<int,object>
	// System.Collections.Generic.Dictionary.KeyCollection<long,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.KeyCollection<long,ET.LSInput>
	// System.Collections.Generic.Dictionary.KeyCollection<long,long>
	// System.Collections.Generic.Dictionary.KeyCollection<long,object>
	// System.Collections.Generic.Dictionary.KeyCollection<object,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.KeyCollection<object,YIUIFramework.YIUIBindVo>
	// System.Collections.Generic.Dictionary.KeyCollection<object,float>
	// System.Collections.Generic.Dictionary.KeyCollection<object,int>
	// System.Collections.Generic.Dictionary.KeyCollection<object,long>
	// System.Collections.Generic.Dictionary.KeyCollection<object,object>
	// System.Collections.Generic.Dictionary.KeyCollection<ushort,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,int>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,long>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<long,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<long,ET.LSInput>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<long,long>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<long,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,YIUIFramework.YIUIBindVo>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,float>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,int>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,long>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<ushort,object>
	// System.Collections.Generic.Dictionary.ValueCollection<int,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.ValueCollection<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary.ValueCollection<int,int>
	// System.Collections.Generic.Dictionary.ValueCollection<int,long>
	// System.Collections.Generic.Dictionary.ValueCollection<int,object>
	// System.Collections.Generic.Dictionary.ValueCollection<long,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.ValueCollection<long,ET.LSInput>
	// System.Collections.Generic.Dictionary.ValueCollection<long,long>
	// System.Collections.Generic.Dictionary.ValueCollection<long,object>
	// System.Collections.Generic.Dictionary.ValueCollection<object,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary.ValueCollection<object,YIUIFramework.YIUIBindVo>
	// System.Collections.Generic.Dictionary.ValueCollection<object,float>
	// System.Collections.Generic.Dictionary.ValueCollection<object,int>
	// System.Collections.Generic.Dictionary.ValueCollection<object,long>
	// System.Collections.Generic.Dictionary.ValueCollection<object,object>
	// System.Collections.Generic.Dictionary.ValueCollection<ushort,object>
	// System.Collections.Generic.Dictionary<int,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary<int,ET.RpcInfo>
	// System.Collections.Generic.Dictionary<int,int>
	// System.Collections.Generic.Dictionary<int,long>
	// System.Collections.Generic.Dictionary<int,object>
	// System.Collections.Generic.Dictionary<long,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary<long,ET.LSInput>
	// System.Collections.Generic.Dictionary<long,long>
	// System.Collections.Generic.Dictionary<long,object>
	// System.Collections.Generic.Dictionary<object,ET.EntityRef<object>>
	// System.Collections.Generic.Dictionary<object,YIUIFramework.YIUIBindVo>
	// System.Collections.Generic.Dictionary<object,float>
	// System.Collections.Generic.Dictionary<object,int>
	// System.Collections.Generic.Dictionary<object,long>
	// System.Collections.Generic.Dictionary<object,object>
	// System.Collections.Generic.Dictionary<ushort,object>
	// System.Collections.Generic.EqualityComparer<ET.ActorId>
	// System.Collections.Generic.EqualityComparer<ET.EntityRef<object>>
	// System.Collections.Generic.EqualityComparer<ET.LSInput>
	// System.Collections.Generic.EqualityComparer<ET.RpcInfo>
	// System.Collections.Generic.EqualityComparer<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.EqualityComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.EqualityComparer<YIUIFramework.YIUIBindVo>
	// System.Collections.Generic.EqualityComparer<float>
	// System.Collections.Generic.EqualityComparer<int>
	// System.Collections.Generic.EqualityComparer<long>
	// System.Collections.Generic.EqualityComparer<object>
	// System.Collections.Generic.EqualityComparer<uint>
	// System.Collections.Generic.EqualityComparer<ushort>
	// System.Collections.Generic.HashSet.Enumerator<int>
	// System.Collections.Generic.HashSet.Enumerator<object>
	// System.Collections.Generic.HashSet.Enumerator<ushort>
	// System.Collections.Generic.HashSet<int>
	// System.Collections.Generic.HashSet<object>
	// System.Collections.Generic.HashSet<ushort>
	// System.Collections.Generic.HashSetEqualityComparer<int>
	// System.Collections.Generic.HashSetEqualityComparer<object>
	// System.Collections.Generic.HashSetEqualityComparer<ushort>
	// System.Collections.Generic.ICollection<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.ICollection<ET.EntityRef<object>>
	// System.Collections.Generic.ICollection<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.ICollection<ET.NumericWatcherInfo>
	// System.Collections.Generic.ICollection<ET.RpcInfo>
	// System.Collections.Generic.ICollection<ET.vector2>
	// System.Collections.Generic.ICollection<ET.vector3>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,ET.EntityRef<object>>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,ET.RpcInfo>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,long>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<long,ET.EntityRef<object>>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<long,ET.LSInput>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<long,long>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,ET.EntityRef<object>>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,YIUIFramework.YIUIBindVo>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,float>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,int>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,long>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<ushort,object>>
	// System.Collections.Generic.ICollection<System.Numerics.Vector2>
	// System.Collections.Generic.ICollection<System.Numerics.Vector3>
	// System.Collections.Generic.ICollection<System.ValueTuple<long,long>>
	// System.Collections.Generic.ICollection<Unity.Mathematics.float3>
	// System.Collections.Generic.ICollection<float>
	// System.Collections.Generic.ICollection<int>
	// System.Collections.Generic.ICollection<long>
	// System.Collections.Generic.ICollection<object>
	// System.Collections.Generic.ICollection<ushort>
	// System.Collections.Generic.IComparer<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.IComparer<ET.EntityRef<object>>
	// System.Collections.Generic.IComparer<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.IComparer<ET.NumericWatcherInfo>
	// System.Collections.Generic.IComparer<ET.vector2>
	// System.Collections.Generic.IComparer<ET.vector3>
	// System.Collections.Generic.IComparer<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.IComparer<System.Numerics.Vector2>
	// System.Collections.Generic.IComparer<System.Numerics.Vector3>
	// System.Collections.Generic.IComparer<System.ValueTuple<long,long>>
	// System.Collections.Generic.IComparer<Unity.Mathematics.float3>
	// System.Collections.Generic.IComparer<float>
	// System.Collections.Generic.IComparer<int>
	// System.Collections.Generic.IComparer<long>
	// System.Collections.Generic.IComparer<object>
	// System.Collections.Generic.IDictionary<object,object>
	// System.Collections.Generic.IEnumerable<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.IEnumerable<ET.EntityRef<object>>
	// System.Collections.Generic.IEnumerable<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.IEnumerable<ET.NumericWatcherInfo>
	// System.Collections.Generic.IEnumerable<ET.RpcInfo>
	// System.Collections.Generic.IEnumerable<ET.vector2>
	// System.Collections.Generic.IEnumerable<ET.vector3>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,ET.EntityRef<object>>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,ET.RpcInfo>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,long>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<long,ET.EntityRef<object>>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<long,ET.LSInput>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<long,long>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,ET.EntityRef<object>>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,YIUIFramework.YIUIBindVo>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,float>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,int>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,long>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<ushort,object>>
	// System.Collections.Generic.IEnumerable<System.Numerics.Vector2>
	// System.Collections.Generic.IEnumerable<System.Numerics.Vector3>
	// System.Collections.Generic.IEnumerable<System.ValueTuple<long,long>>
	// System.Collections.Generic.IEnumerable<Unity.Mathematics.float3>
	// System.Collections.Generic.IEnumerable<float>
	// System.Collections.Generic.IEnumerable<int>
	// System.Collections.Generic.IEnumerable<long>
	// System.Collections.Generic.IEnumerable<object>
	// System.Collections.Generic.IEnumerable<ushort>
	// System.Collections.Generic.IEnumerator<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.IEnumerator<ET.EntityRef<object>>
	// System.Collections.Generic.IEnumerator<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.IEnumerator<ET.NumericWatcherInfo>
	// System.Collections.Generic.IEnumerator<ET.RpcInfo>
	// System.Collections.Generic.IEnumerator<ET.vector2>
	// System.Collections.Generic.IEnumerator<ET.vector3>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,ET.EntityRef<object>>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,ET.RpcInfo>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,int>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,long>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<long,ET.EntityRef<object>>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<long,ET.LSInput>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<long,long>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,ET.EntityRef<object>>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,YIUIFramework.YIUIBindVo>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,float>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,int>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,long>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<ushort,object>>
	// System.Collections.Generic.IEnumerator<System.Numerics.Vector2>
	// System.Collections.Generic.IEnumerator<System.Numerics.Vector3>
	// System.Collections.Generic.IEnumerator<System.ValueTuple<long,long>>
	// System.Collections.Generic.IEnumerator<Unity.Mathematics.float3>
	// System.Collections.Generic.IEnumerator<float>
	// System.Collections.Generic.IEnumerator<int>
	// System.Collections.Generic.IEnumerator<long>
	// System.Collections.Generic.IEnumerator<object>
	// System.Collections.Generic.IEnumerator<ushort>
	// System.Collections.Generic.IEqualityComparer<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IEqualityComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.IEqualityComparer<int>
	// System.Collections.Generic.IEqualityComparer<long>
	// System.Collections.Generic.IEqualityComparer<object>
	// System.Collections.Generic.IEqualityComparer<ushort>
	// System.Collections.Generic.IList<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.IList<ET.EntityRef<object>>
	// System.Collections.Generic.IList<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.IList<ET.NumericWatcherInfo>
	// System.Collections.Generic.IList<ET.vector2>
	// System.Collections.Generic.IList<ET.vector3>
	// System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.IList<System.Numerics.Vector2>
	// System.Collections.Generic.IList<System.Numerics.Vector3>
	// System.Collections.Generic.IList<System.ValueTuple<long,long>>
	// System.Collections.Generic.IList<Unity.Mathematics.float3>
	// System.Collections.Generic.IList<float>
	// System.Collections.Generic.IList<int>
	// System.Collections.Generic.IList<long>
	// System.Collections.Generic.IList<object>
	// System.Collections.Generic.IReadOnlyDictionary<int,object>
	// System.Collections.Generic.KeyValuePair<int,ET.EntityRef<object>>
	// System.Collections.Generic.KeyValuePair<int,ET.RpcInfo>
	// System.Collections.Generic.KeyValuePair<int,int>
	// System.Collections.Generic.KeyValuePair<int,long>
	// System.Collections.Generic.KeyValuePair<int,object>
	// System.Collections.Generic.KeyValuePair<long,ET.EntityRef<object>>
	// System.Collections.Generic.KeyValuePair<long,ET.LSInput>
	// System.Collections.Generic.KeyValuePair<long,long>
	// System.Collections.Generic.KeyValuePair<long,object>
	// System.Collections.Generic.KeyValuePair<object,ET.EntityRef<object>>
	// System.Collections.Generic.KeyValuePair<object,YIUIFramework.YIUIBindVo>
	// System.Collections.Generic.KeyValuePair<object,float>
	// System.Collections.Generic.KeyValuePair<object,int>
	// System.Collections.Generic.KeyValuePair<object,long>
	// System.Collections.Generic.KeyValuePair<object,object>
	// System.Collections.Generic.KeyValuePair<ushort,object>
	// System.Collections.Generic.LinkedList.Enumerator<object>
	// System.Collections.Generic.LinkedList<object>
	// System.Collections.Generic.LinkedListNode<object>
	// System.Collections.Generic.List.Enumerator<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.List.Enumerator<ET.EntityRef<object>>
	// System.Collections.Generic.List.Enumerator<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.List.Enumerator<ET.NumericWatcherInfo>
	// System.Collections.Generic.List.Enumerator<ET.vector2>
	// System.Collections.Generic.List.Enumerator<ET.vector3>
	// System.Collections.Generic.List.Enumerator<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.List.Enumerator<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.List.Enumerator<System.Numerics.Vector2>
	// System.Collections.Generic.List.Enumerator<System.Numerics.Vector3>
	// System.Collections.Generic.List.Enumerator<System.ValueTuple<long,long>>
	// System.Collections.Generic.List.Enumerator<Unity.Mathematics.float3>
	// System.Collections.Generic.List.Enumerator<float>
	// System.Collections.Generic.List.Enumerator<int>
	// System.Collections.Generic.List.Enumerator<long>
	// System.Collections.Generic.List.Enumerator<object>
	// System.Collections.Generic.List<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.List<ET.EntityRef<object>>
	// System.Collections.Generic.List<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.List<ET.NumericWatcherInfo>
	// System.Collections.Generic.List<ET.vector2>
	// System.Collections.Generic.List<ET.vector3>
	// System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.List<System.Numerics.Vector2>
	// System.Collections.Generic.List<System.Numerics.Vector3>
	// System.Collections.Generic.List<System.ValueTuple<long,long>>
	// System.Collections.Generic.List<Unity.Mathematics.float3>
	// System.Collections.Generic.List<float>
	// System.Collections.Generic.List<int>
	// System.Collections.Generic.List<long>
	// System.Collections.Generic.List<object>
	// System.Collections.Generic.ObjectComparer<DotRecast.Detour.StraightPathItem>
	// System.Collections.Generic.ObjectComparer<ET.ActorId>
	// System.Collections.Generic.ObjectComparer<ET.EntityRef<object>>
	// System.Collections.Generic.ObjectComparer<ET.MessageSessionDispatcherInfo>
	// System.Collections.Generic.ObjectComparer<ET.NumericWatcherInfo>
	// System.Collections.Generic.ObjectComparer<ET.vector2>
	// System.Collections.Generic.ObjectComparer<ET.vector3>
	// System.Collections.Generic.ObjectComparer<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.ObjectComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.ObjectComparer<System.Numerics.Vector2>
	// System.Collections.Generic.ObjectComparer<System.Numerics.Vector3>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<long,long>>
	// System.Collections.Generic.ObjectComparer<Unity.Mathematics.float3>
	// System.Collections.Generic.ObjectComparer<float>
	// System.Collections.Generic.ObjectComparer<int>
	// System.Collections.Generic.ObjectComparer<long>
	// System.Collections.Generic.ObjectComparer<object>
	// System.Collections.Generic.ObjectComparer<uint>
	// System.Collections.Generic.ObjectComparer<ushort>
	// System.Collections.Generic.ObjectEqualityComparer<ET.ActorId>
	// System.Collections.Generic.ObjectEqualityComparer<ET.EntityRef<object>>
	// System.Collections.Generic.ObjectEqualityComparer<ET.LSInput>
	// System.Collections.Generic.ObjectEqualityComparer<ET.RpcInfo>
	// System.Collections.Generic.ObjectEqualityComparer<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.ObjectEqualityComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.ObjectEqualityComparer<YIUIFramework.YIUIBindVo>
	// System.Collections.Generic.ObjectEqualityComparer<float>
	// System.Collections.Generic.ObjectEqualityComparer<int>
	// System.Collections.Generic.ObjectEqualityComparer<long>
	// System.Collections.Generic.ObjectEqualityComparer<object>
	// System.Collections.Generic.ObjectEqualityComparer<uint>
	// System.Collections.Generic.ObjectEqualityComparer<ushort>
	// System.Collections.Generic.Queue.Enumerator<int>
	// System.Collections.Generic.Queue.Enumerator<object>
	// System.Collections.Generic.Queue<int>
	// System.Collections.Generic.Queue<object>
	// System.Collections.Generic.SortedDictionary.<>c__DisplayClass34_0<int,object>
	// System.Collections.Generic.SortedDictionary.<>c__DisplayClass34_0<long,object>
	// System.Collections.Generic.SortedDictionary.<>c__DisplayClass34_1<int,object>
	// System.Collections.Generic.SortedDictionary.<>c__DisplayClass34_1<long,object>
	// System.Collections.Generic.SortedDictionary.Enumerator<int,object>
	// System.Collections.Generic.SortedDictionary.Enumerator<long,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.<>c__DisplayClass5_0<int,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.<>c__DisplayClass5_0<long,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.<>c__DisplayClass6_0<int,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.<>c__DisplayClass6_0<long,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.Enumerator<int,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection.Enumerator<long,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection<int,object>
	// System.Collections.Generic.SortedDictionary.KeyCollection<long,object>
	// System.Collections.Generic.SortedDictionary.KeyValuePairComparer<int,object>
	// System.Collections.Generic.SortedDictionary.KeyValuePairComparer<long,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.<>c__DisplayClass5_0<int,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.<>c__DisplayClass5_0<long,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.<>c__DisplayClass6_0<int,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.<>c__DisplayClass6_0<long,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.Enumerator<int,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection.Enumerator<long,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection<int,object>
	// System.Collections.Generic.SortedDictionary.ValueCollection<long,object>
	// System.Collections.Generic.SortedDictionary<int,object>
	// System.Collections.Generic.SortedDictionary<long,object>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass52_0<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass52_0<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass53_0<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass53_0<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass85_0<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSet.<>c__DisplayClass85_0<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.<Reverse>d__94<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSet.<Reverse>d__94<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.Enumerator<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSet.Enumerator<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.Node<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSet.Node<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.TreeSubSet.<>c__DisplayClass9_0<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSet.TreeSubSet.<>c__DisplayClass9_0<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet.TreeSubSet<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSet.TreeSubSet<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSet<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSet<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.SortedSetEqualityComparer<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.SortedSetEqualityComparer<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.Stack.Enumerator<ET.EntityRef<object>>
	// System.Collections.Generic.Stack.Enumerator<object>
	// System.Collections.Generic.Stack<ET.EntityRef<object>>
	// System.Collections.Generic.Stack<object>
	// System.Collections.Generic.TreeSet<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.TreeSet<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.Generic.TreeWalkPredicate<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.TreeWalkPredicate<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.ObjectModel.ReadOnlyCollection<DotRecast.Detour.StraightPathItem>
	// System.Collections.ObjectModel.ReadOnlyCollection<ET.EntityRef<object>>
	// System.Collections.ObjectModel.ReadOnlyCollection<ET.MessageSessionDispatcherInfo>
	// System.Collections.ObjectModel.ReadOnlyCollection<ET.NumericWatcherInfo>
	// System.Collections.ObjectModel.ReadOnlyCollection<ET.vector2>
	// System.Collections.ObjectModel.ReadOnlyCollection<ET.vector3>
	// System.Collections.ObjectModel.ReadOnlyCollection<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.ObjectModel.ReadOnlyCollection<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Collections.ObjectModel.ReadOnlyCollection<System.Numerics.Vector2>
	// System.Collections.ObjectModel.ReadOnlyCollection<System.Numerics.Vector3>
	// System.Collections.ObjectModel.ReadOnlyCollection<System.ValueTuple<long,long>>
	// System.Collections.ObjectModel.ReadOnlyCollection<Unity.Mathematics.float3>
	// System.Collections.ObjectModel.ReadOnlyCollection<float>
	// System.Collections.ObjectModel.ReadOnlyCollection<int>
	// System.Collections.ObjectModel.ReadOnlyCollection<long>
	// System.Collections.ObjectModel.ReadOnlyCollection<object>
	// System.Comparison<DotRecast.Detour.StraightPathItem>
	// System.Comparison<ET.ActorId>
	// System.Comparison<ET.EntityRef<object>>
	// System.Comparison<ET.MessageSessionDispatcherInfo>
	// System.Comparison<ET.NumericWatcherInfo>
	// System.Comparison<ET.vector2>
	// System.Comparison<ET.vector3>
	// System.Comparison<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Comparison<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Comparison<System.Numerics.Vector2>
	// System.Comparison<System.Numerics.Vector3>
	// System.Comparison<System.ValueTuple<long,long>>
	// System.Comparison<Unity.Mathematics.float3>
	// System.Comparison<float>
	// System.Comparison<int>
	// System.Comparison<long>
	// System.Comparison<object>
	// System.Comparison<uint>
	// System.Comparison<ushort>
	// System.Func<ET.vector2,System.Numerics.Vector2>
	// System.Func<ET.vector2,byte>
	// System.Func<ET.vector3,System.Numerics.Vector3>
	// System.Func<ET.vector3,byte>
	// System.Func<System.Numerics.Vector2,byte>
	// System.Func<System.Numerics.Vector3,byte>
	// System.Func<object,byte>
	// System.Func<object,object,object>
	// System.Func<object,object>
	// System.Func<object>
	// System.IEquatable<ushort>
	// System.Linq.Buffer<ET.RpcInfo>
	// System.Linq.Enumerable.Iterator<ET.vector2>
	// System.Linq.Enumerable.Iterator<ET.vector3>
	// System.Linq.Enumerable.Iterator<System.Numerics.Vector2>
	// System.Linq.Enumerable.Iterator<System.Numerics.Vector3>
	// System.Linq.Enumerable.WhereEnumerableIterator<System.Numerics.Vector2>
	// System.Linq.Enumerable.WhereEnumerableIterator<System.Numerics.Vector3>
	// System.Linq.Enumerable.WhereSelectArrayIterator<ET.vector2,System.Numerics.Vector2>
	// System.Linq.Enumerable.WhereSelectArrayIterator<ET.vector3,System.Numerics.Vector3>
	// System.Linq.Enumerable.WhereSelectEnumerableIterator<ET.vector2,System.Numerics.Vector2>
	// System.Linq.Enumerable.WhereSelectEnumerableIterator<ET.vector3,System.Numerics.Vector3>
	// System.Linq.Enumerable.WhereSelectListIterator<ET.vector2,System.Numerics.Vector2>
	// System.Linq.Enumerable.WhereSelectListIterator<ET.vector3,System.Numerics.Vector3>
	// System.Nullable<YIUIFramework.YIUIBindVo>
	// System.Predicate<DotRecast.Detour.StraightPathItem>
	// System.Predicate<ET.EntityRef<object>>
	// System.Predicate<ET.MessageSessionDispatcherInfo>
	// System.Predicate<ET.NumericWatcherInfo>
	// System.Predicate<ET.vector2>
	// System.Predicate<ET.vector3>
	// System.Predicate<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Predicate<System.Collections.Generic.KeyValuePair<long,object>>
	// System.Predicate<System.Numerics.Vector2>
	// System.Predicate<System.Numerics.Vector3>
	// System.Predicate<System.ValueTuple<long,long>>
	// System.Predicate<Unity.Mathematics.float3>
	// System.Predicate<float>
	// System.Predicate<int>
	// System.Predicate<long>
	// System.Predicate<object>
	// System.Predicate<ushort>
	// System.ReadOnlySpan.Enumerator<byte>
	// System.ReadOnlySpan.Enumerator<ushort>
	// System.ReadOnlySpan<byte>
	// System.ReadOnlySpan<ushort>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<object>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable<object>
	// System.Runtime.CompilerServices.TaskAwaiter<object>
	// System.Span.Enumerator<byte>
	// System.Span.Enumerator<ushort>
	// System.Span<byte>
	// System.Span<ushort>
	// System.Threading.Tasks.ContinuationTaskFromResultTask<object>
	// System.Threading.Tasks.Task<object>
	// System.Threading.Tasks.TaskFactory.<>c<object>
	// System.Threading.Tasks.TaskFactory.<>c__DisplayClass32_0<object>
	// System.Threading.Tasks.TaskFactory.<>c__DisplayClass35_0<object>
	// System.Threading.Tasks.TaskFactory<object>
	// System.ValueTuple<ET.ActorId,object>
	// System.ValueTuple<int,object>
	// System.ValueTuple<long,long>
	// System.ValueTuple<uint,object>
	// System.ValueTuple<uint,uint>
	// System.ValueTuple<ushort,object>
	// UnityEngine.Events.InvokableCall<byte>
	// UnityEngine.Events.InvokableCall<object>
	// UnityEngine.Events.UnityAction<byte>
	// UnityEngine.Events.UnityAction<int>
	// UnityEngine.Events.UnityAction<object>
	// UnityEngine.Events.UnityEvent<byte>
	// UnityEngine.Events.UnityEvent<object>
	// YIUIFramework.LinkedListPool.<>c<object>
	// YIUIFramework.LinkedListPool<object>
	// YIUIFramework.ObjAsyncCache<ET.EntityRef<object>>
	// YIUIFramework.ObjCache<object>
	// YIUIFramework.ObjectPool<object>
	// YIUIFramework.Singleton<object>
	// YIUIFramework.UIDataValueBase<byte>
	// YIUIFramework.UIDataValueBase<int>
	// YIUIFramework.UIDataValueBase<object>
	// YIUIFramework.UIEventDelegate<byte>
	// YIUIFramework.UIEventDelegate<int>
	// YIUIFramework.UIEventDelegate<object>
	// YIUIFramework.UIEventHandleP1<byte>
	// YIUIFramework.UIEventHandleP1<int>
	// YIUIFramework.UIEventHandleP1<object>
	// YIUIFramework.UIEventP1<byte>
	// YIUIFramework.UIEventP1<int>
	// YIUIFramework.UIEventP1<object>
	// YIUIFramework.YIUILoopScroll.<>c__DisplayClass83_0<int,object>
	// YIUIFramework.YIUILoopScroll.<>c__DisplayClass83_0<object,object>
	// YIUIFramework.YIUILoopScroll.ListItemRenderer<int,object>
	// YIUIFramework.YIUILoopScroll.ListItemRenderer<object,object>
	// YIUIFramework.YIUILoopScroll.OnClickItemEvent<int,object>
	// YIUIFramework.YIUILoopScroll.OnClickItemEvent<object,object>
	// YIUIFramework.YIUILoopScroll<int,object>
	// YIUIFramework.YIUILoopScroll<object,object>
	// }}

	public void RefMethods()
	{
		// object DG.Tweening.TweenSettingsExtensions.OnComplete<object>(object,DG.Tweening.TweenCallback)
		// object DG.Tweening.TweenSettingsExtensions.OnUpdate<object>(object,DG.Tweening.TweenCallback)
		// object DG.Tweening.TweenSettingsExtensions.SetEase<object>(object,DG.Tweening.Ease)
		// object DG.Tweening.TweenSettingsExtensions.SetRelative<object>(object)
		// object DG.Tweening.TweenSettingsExtensions.SetRelative<object>(object,bool)
		// ET.ETTask ET.Client.YIUIEventSystem.UIEvent<ET.Client.EventPutTipsView>(ET.Fiber,ET.Client.EventPutTipsView)
		// ET.ETTask ET.Client.YIUIEventSystem.UIEvent<ET.Client.OnClickChildListEvent>(ET.Fiber,ET.Client.OnClickChildListEvent)
		// ET.ETTask ET.Client.YIUIEventSystem.UIEvent<ET.Client.OnClickItemEvent>(ET.Fiber,ET.Client.OnClickItemEvent)
		// ET.ETTask ET.Client.YIUIEventSystem.UIEvent<ET.Client.OnClickParentListEvent>(ET.Fiber,ET.Client.OnClickParentListEvent)
		// ET.ETTask ET.Client.YIUIEventSystem.UIEvent<ET.Client.OnGMEventClose>(ET.Fiber,ET.Client.OnGMEventClose)
		// YIUIFramework.PanelInfo ET.Client.YIUIMgrComponent.GetPanelInfo<object>()
		// ET.ETTask<bool> ET.Client.YIUIMgrComponentSystem.ClosePanelAsync<object>(ET.Client.YIUIMgrComponent,bool,bool)
		// object ET.Client.YIUIMgrComponentSystem.GetPanel<object>(ET.Client.YIUIMgrComponent)
		// ET.ETTask<object> ET.Client.YIUIPanelComponentSystem.OpenViewAsync<object>(ET.Client.YIUIPanelComponent)
		// ET.ETTask<object> ET.Client.YIUIRootComponentSystem.OpenPanelAsync<object,object,object,object>(ET.Client.YIUIRootComponent,object,object,object)
		// ET.ETTask<object> ET.Client.YIUIRootComponentSystem.OpenPanelAsync<object>(ET.Client.YIUIRootComponent)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.A2C_DisconnectHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.A2C_DisconnectHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.A2NetClient_MessageHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.A2NetClient_MessageHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.AE_PlayEffect.<Execute>d__0>(ET.ETTaskCompleted&,ET.Client.AE_PlayEffect.<Execute>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.AE_PlaySound.<Execute>d__0>(ET.ETTaskCompleted&,ET.Client.AE_PlaySound.<Execute>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.AfterCreateClientScene_LSAddComponent.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.AfterCreateClientScene_LSAddComponent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.AfterUnitCreate_CreateUnitView.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.AfterUnitCreate_CreateUnitView.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.ChangePosition_SyncGameObjectPos.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.ChangePosition_SyncGameObjectPos.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.ChangeRotation_SyncGameObjectRotation.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.ChangeRotation_SyncGameObjectRotation.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.EntryEvent3_InitClient.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.EntryEvent3_InitClient.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.FiberInit_NetClient.<Handle>d__0>(ET.ETTaskCompleted&,ET.Client.FiberInit_NetClient.<Handle>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.G2C_ReconnectHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.G2C_ReconnectHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.HitResult_View.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.HitResult_View.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.LSSceneInitFinish_Finish.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.LSSceneInitFinish_Finish.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.LoginFinish_RemoveUILSLogin.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.LoginFinish_RemoveUILSLogin.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_AllItemsHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_AllItemsHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_CreateMyUnitHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_CreateMyUnitHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_CreateUnitsHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_CreateUnitsHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_HitResultHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_HitResultHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_ItemUpdateOpHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_ItemUpdateOpHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_NoticeUnitNumericHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_NoticeUnitNumericHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_RemoveUnitsHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_RemoveUnitsHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_SkillUpdateOpHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_SkillUpdateOpHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_SpellSkillHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_SpellSkillHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.M2C_StopHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.M2C_StopHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.MoveStart_Animator.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.MoveStart_Animator.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.MoveStop_Animator.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.MoveStop_Animator.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.NetClient2Main_SessionDisposeHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.NetClient2Main_SessionDisposeHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.OnPatchDownloadFailed_ShowFailedInfo.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.OnPatchDownloadFailed_ShowFailedInfo.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.OnPatchDownloadOver_Reset.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.OnPatchDownloadOver_Reset.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.OnPatchDownloadProgress_UpdateProgress.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.OnPatchDownloadProgress_UpdateProgress.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.OneFrameInputsHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.OneFrameInputsHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.PlayEffect_PlayView.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.PlayEffect_PlayView.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.PlaySound_PlayView.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.PlaySound_PlayView.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.RedDotPanelComponentSystem.<YIUIEvent>d__6>(ET.ETTaskCompleted&,ET.Client.RedDotPanelComponentSystem.<YIUIEvent>d__6&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.RedDotPanelComponentSystem.<YIUIEvent>d__7>(ET.ETTaskCompleted&,ET.Client.RedDotPanelComponentSystem.<YIUIEvent>d__7&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.RedDotPanelComponentSystem.<YIUIEvent>d__8>(ET.ETTaskCompleted&,ET.Client.RedDotPanelComponentSystem.<YIUIEvent>d__8&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.RemoveEffect_RemoveView.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.RemoveEffect_RemoveView.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.Room2C_AdjustUpdateTimeHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.Room2C_AdjustUpdateTimeHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.Room2C_CheckHashFailHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.Room2C_CheckHashFailHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.Room2C_StartHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.Room2C_StartHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.SceneChangeFinishEvent.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.SceneChangeFinishEvent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.ShowErrorTip_CreateView.<Run>d__0>(ET.ETTaskCompleted&,ET.Client.ShowErrorTip_CreateView.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.UIBagComponentSystem.<Refresh>d__2>(ET.ETTaskCompleted&,ET.Client.UIBagComponentSystem.<Refresh>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.UIMainComponentSystem.<OnAchievementBtn>d__9>(ET.ETTaskCompleted&,ET.Client.UIMainComponentSystem.<OnAchievementBtn>d__9&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.UIMainComponentSystem.<OnBagBtn>d__4>(ET.ETTaskCompleted&,ET.Client.UIMainComponentSystem.<OnBagBtn>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.UIMainComponentSystem.<OnPetBtn>d__5>(ET.ETTaskCompleted&,ET.Client.UIMainComponentSystem.<OnPetBtn>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.UIMainComponentSystem.<OnSettingsBtn>d__2>(ET.ETTaskCompleted&,ET.Client.UIMainComponentSystem.<OnSettingsBtn>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.UIMainComponentSystem.<OnSkillBtn>d__6>(ET.ETTaskCompleted&,ET.Client.UIMainComponentSystem.<OnSkillBtn>d__6&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.UIMainComponentSystem.<OnSocialBtn>d__8>(ET.ETTaskCompleted&,ET.Client.UIMainComponentSystem.<OnSocialBtn>d__8&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.UIMainComponentSystem.<OnTaskBtn>d__7>(ET.ETTaskCompleted&,ET.Client.UIMainComponentSystem.<OnTaskBtn>d__7&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.UIRoleComponentSystem.<OnCreateBtn>d__1>(ET.ETTaskCompleted&,ET.Client.UIRoleComponentSystem.<OnCreateBtn>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.UIRoleComponentSystem.<OnDeleteBtn>d__2>(ET.ETTaskCompleted&,ET.Client.UIRoleComponentSystem.<OnDeleteBtn>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.UIRoleComponentSystem.<UpdateRoleList>d__4>(ET.ETTaskCompleted&,ET.Client.UIRoleComponentSystem.<UpdateRoleList>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.UISkillGridSystem.<RefeshIcon>d__3>(ET.ETTaskCompleted&,ET.Client.UISkillGridSystem.<RefeshIcon>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.EntryEvent1_InitShare.<Run>d__0>(ET.ETTaskCompleted&,ET.EntryEvent1_InitShare.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.NumericChangeEvent_NotifyWatcher.<Run>d__0>(ET.ETTaskCompleted&,ET.NumericChangeEvent_NotifyWatcher.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.ReloadConfigConsoleHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.ReloadConfigConsoleHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.ReloadDllConsoleHandler.<Run>d__0>(ET.ETTaskCompleted&,ET.ReloadDllConsoleHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,ET.Client.ResourcesLoaderComponentSystem.<LoadSceneAsync>d__8>(System.Runtime.CompilerServices.TaskAwaiter&,ET.Client.ResourcesLoaderComponentSystem.<LoadSceneAsync>d__8&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,ET.ConsoleComponentSystem.<Start>d__1>(System.Runtime.CompilerServices.TaskAwaiter<object>&,ET.ConsoleComponentSystem.<Start>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.A2NetClient_RequestHandler.<Run>d__0>(object&,ET.Client.A2NetClient_RequestHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.AppStartInitFinish_CreateLoginUI.<Run>d__0>(object&,ET.Client.AppStartInitFinish_CreateLoginUI.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.AppStartInitFinish_CreateUILSLogin.<Run>d__0>(object&,ET.Client.AppStartInitFinish_CreateUILSLogin.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.ClientSenderComponentSystem.<ConnectAccountAsync>d__4>(object&,ET.Client.ClientSenderComponentSystem.<ConnectAccountAsync>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.ClientSenderComponentSystem.<DisposeAsync>d__3>(object&,ET.Client.ClientSenderComponentSystem.<DisposeAsync>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.ClientSenderComponentSystem.<RemoveFiberAsync>d__2>(object&,ET.Client.ClientSenderComponentSystem.<RemoveFiberAsync>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.EnterMapHelper.<EnterMapAsync>d__0>(object&,ET.Client.EnterMapHelper.<EnterMapAsync>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.EnterMapHelper.<Match>d__1>(object&,ET.Client.EnterMapHelper.<Match>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.EntryEvent3_InitClient.<Run>d__0>(object&,ET.Client.EntryEvent3_InitClient.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.EntryEvent3_InitClient.<StartHotUpdate>d__1>(object&,ET.Client.EntryEvent3_InitClient.<StartHotUpdate>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.FlyTipComponentSystem.<OnAwake>d__3>(object&,ET.Client.FlyTipComponentSystem.<OnAwake>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.G2C_ReconnectHandler.<Run>d__0>(object&,ET.Client.G2C_ReconnectHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.GMCommandComponentSystem.<Run>d__5>(object&,ET.Client.GMCommandComponentSystem.<Run>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.GMCommandItemComponentSystem.<WaitRefresh>d__6>(object&,ET.Client.GMCommandItemComponentSystem.<WaitRefresh>d__6&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.GMViewComponentSystem.<YIUIEvent>d__2>(object&,ET.Client.GMViewComponentSystem.<YIUIEvent>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.LSSceneChangeHelper.<SceneChangeTo>d__0>(object&,ET.Client.LSSceneChangeHelper.<SceneChangeTo>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.LSSceneChangeHelper.<SceneChangeToReconnect>d__2>(object&,ET.Client.LSSceneChangeHelper.<SceneChangeToReconnect>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.LSSceneChangeHelper.<SceneChangeToReplay>d__1>(object&,ET.Client.LSSceneChangeHelper.<SceneChangeToReplay>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.LSSceneChangeStart_AddComponent.<Run>d__0>(object&,ET.Client.LSSceneChangeStart_AddComponent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.LSSceneInitFinish_Finish.<Run>d__0>(object&,ET.Client.LSSceneInitFinish_Finish.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.LSUnitViewComponentSystem.<InitAsync>d__2>(object&,ET.Client.LSUnitViewComponentSystem.<InitAsync>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.LobbyPanelComponentSystem.<OnEventEnterAction>d__3>(object&,ET.Client.LobbyPanelComponentSystem.<OnEventEnterAction>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.LoginFinish_CreateLobbyUI.<Run>d__0>(object&,ET.Client.LoginFinish_CreateLobbyUI.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.LoginFinish_CreateUILSLobby.<Run>d__0>(object&,ET.Client.LoginFinish_CreateUILSLobby.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.LoginFinish_RemoveLoginUI.<Run>d__0>(object&,ET.Client.LoginFinish_RemoveLoginUI.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.LoginHelper.<Login>d__7>(object&,ET.Client.LoginHelper.<Login>d__7&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.LoginPanelComponentSystem.<OnEventLoginAction>d__8>(object&,ET.Client.LoginPanelComponentSystem.<OnEventLoginAction>d__8&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.LoginPanelComponentSystem.<OnLogin>d__11>(object&,ET.Client.LoginPanelComponentSystem.<OnLogin>d__11&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.LoginPanelComponentSystem.<OnTapTapBtn>d__9>(object&,ET.Client.LoginPanelComponentSystem.<OnTapTapBtn>d__9&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.M2C_PathfindingResultHandler.<Run>d__0>(object&,ET.Client.M2C_PathfindingResultHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.M2C_StartSceneChangeHandler.<Run>d__0>(object&,ET.Client.M2C_StartSceneChangeHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.Main2NetClient_ConnectAccountHandler.<Run>d__0>(object&,ET.Client.Main2NetClient_ConnectAccountHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.Main2NetClient_EnterGameHandler.<Run>d__0>(object&,ET.Client.Main2NetClient_EnterGameHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.Main2NetClient_LoginHandler.<Run>d__0>(object&,ET.Client.Main2NetClient_LoginHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.MaskWordComponentSystem.<InitMaskWord>d__1>(object&,ET.Client.MaskWordComponentSystem.<InitMaskWord>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.MaskWordComponentSystem.<InitMaskWordText>d__2>(object&,ET.Client.MaskWordComponentSystem.<InitMaskWordText>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.Match2G_NotifyMatchSuccessHandler.<Run>d__0>(object&,ET.Client.Match2G_NotifyMatchSuccessHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.MessageTipsViewComponentSystem.<YIUICloseTween>d__7>(object&,ET.Client.MessageTipsViewComponentSystem.<YIUICloseTween>d__7&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.MessageTipsViewComponentSystem.<YIUIOpenTween>d__6>(object&,ET.Client.MessageTipsViewComponentSystem.<YIUIOpenTween>d__6&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.MiniMapViewComponentSystem.<OnEnterScene>d__4>(object&,ET.Client.MiniMapViewComponentSystem.<OnEnterScene>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.MoveHelper.<MoveToAsync>d__1>(object&,ET.Client.MoveHelper.<MoveToAsync>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.OperaComponentSystem.<Test1>d__2>(object&,ET.Client.OperaComponentSystem.<Test1>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.OperaComponentSystem.<Test2>d__3>(object&,ET.Client.OperaComponentSystem.<Test2>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.PingComponentSystem.<PingAsync>d__2>(object&,ET.Client.PingComponentSystem.<PingAsync>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.ResourcesLoaderComponentSystem.<LoadSceneAsync>d__8>(object&,ET.Client.ResourcesLoaderComponentSystem.<LoadSceneAsync>d__8&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.RouterAddressComponentSystem.<GetAllRouter>d__2>(object&,ET.Client.RouterAddressComponentSystem.<GetAllRouter>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.RouterAddressComponentSystem.<Init>d__1>(object&,ET.Client.RouterAddressComponentSystem.<Init>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.RouterAddressComponentSystem.<WaitTenMinGetAllRouter>d__3>(object&,ET.Client.RouterAddressComponentSystem.<WaitTenMinGetAllRouter>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.RouterCheckComponentSystem.<CheckAsync>d__1>(object&,ET.Client.RouterCheckComponentSystem.<CheckAsync>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.SceneChangeFinishEvent.<Run>d__0>(object&,ET.Client.SceneChangeFinishEvent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.SceneChangeHelper.<SceneChangeTo>d__0>(object&,ET.Client.SceneChangeHelper.<SceneChangeTo>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.SceneChangeStartEvent.<Run>d__0>(object&,ET.Client.SceneChangeStartEvent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.StartHotUpDate_CreatHotUpdateUI.<Run>d__0>(object&,ET.Client.StartHotUpDate_CreatHotUpdateUI.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.TextTipsViewComponentSystem.<PlayAnimation>d__6>(object&,ET.Client.TextTipsViewComponentSystem.<PlayAnimation>d__6&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.TipsHelper.<CloseTipsView>d__7>(object&,ET.Client.TipsHelper.<CloseTipsView>d__7&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.TipsHelper.<Open>d__0<object>>(object&,ET.Client.TipsHelper.<Open>d__0<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.TipsHelper.<OpenToParent2NewVo>d__6<object>>(object&,ET.Client.TipsHelper.<OpenToParent2NewVo>d__6<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.TipsHelper.<OpenToParent>d__2<object>>(object&,ET.Client.TipsHelper.<OpenToParent>d__2<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.TipsHelper.<OpenToParent>d__4<object>>(object&,ET.Client.TipsHelper.<OpenToParent>d__4<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.TipsPanelComponentSystem.<YIUIEvent>d__3>(object&,ET.Client.TipsPanelComponentSystem.<YIUIEvent>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UICommonItemSystem.<Refresh>d__1>(object&,ET.Client.UICommonItemSystem.<Refresh>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UIHelper.<>c__DisplayClass9_0.<<AddListenerAsync>g__clickAcionAsync|0>d>(object&,ET.Client.UIHelper.<>c__DisplayClass9_0.<<AddListenerAsync>g__clickAcionAsync|0>d&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UILSLobbyComponentSystem.<EnterMap>d__1>(object&,ET.Client.UILSLobbyComponentSystem.<EnterMap>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UILobbyComponentSystem.<EnterMap>d__1>(object&,ET.Client.UILobbyComponentSystem.<EnterMap>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UILoginComponentSystem.<OnLogin>d__4>(object&,ET.Client.UILoginComponentSystem.<OnLogin>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UILoginComponentSystem.<OnNormalLoginBtn>d__1>(object&,ET.Client.UILoginComponentSystem.<OnNormalLoginBtn>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UILoginComponentSystem.<OnTapTapBtn>d__2>(object&,ET.Client.UILoginComponentSystem.<OnTapTapBtn>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UIMiniMapComponentSystem.<OnEnterScene>d__2>(object&,ET.Client.UIMiniMapComponentSystem.<OnEnterScene>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UIModelShowSystem.<ShowModel>d__5>(object&,ET.Client.UIModelShowSystem.<ShowModel>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UIRoleComponentSystem.<OnCreateBtn>d__1>(object&,ET.Client.UIRoleComponentSystem.<OnCreateBtn>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UIRoleComponentSystem.<OnDeleteBtn>d__2>(object&,ET.Client.UIRoleComponentSystem.<OnDeleteBtn>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UIRoleComponentSystem.<OnEnterGameBtn>d__3>(object&,ET.Client.UIRoleComponentSystem.<OnEnterGameBtn>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UIRoleComponentSystem.<UpdateRoleList>d__4>(object&,ET.Client.UIRoleComponentSystem.<UpdateRoleList>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UIServerComponentSystem.<OnConfirmBtn>d__1>(object&,ET.Client.UIServerComponentSystem.<OnConfirmBtn>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Client.UIServerComponentSystem.<ShowServerList>d__2>(object&,ET.Client.UIServerComponentSystem.<ShowServerList>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.ConsoleComponentSystem.<Start>d__1>(object&,ET.ConsoleComponentSystem.<Start>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.Entry.<StartAsync>d__2>(object&,ET.Entry.<StartAsync>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.FiberInit_Main.<Handle>d__0>(object&,ET.FiberInit_Main.<Handle>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.MailBoxType_OrderedMessageHandler.<HandleInner>d__1>(object&,ET.MailBoxType_OrderedMessageHandler.<HandleInner>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.MailBoxType_UnOrderedMessageHandler.<HandleAsync>d__1>(object&,ET.MailBoxType_UnOrderedMessageHandler.<HandleAsync>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.MessageHandler.<Handle>d__1<object,object,object>>(object&,ET.MessageHandler.<Handle>d__1<object,object,object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.MessageHandler.<Handle>d__1<object,object>>(object&,ET.MessageHandler.<Handle>d__1<object,object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.MessageSessionHandler.<HandleAsync>d__2<object,object>>(object&,ET.MessageSessionHandler.<HandleAsync>d__2<object,object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.MessageSessionHandler.<HandleAsync>d__2<object>>(object&,ET.MessageSessionHandler.<HandleAsync>d__2<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.ObjectWaitSystem.<>c__DisplayClass5_0.<<Wait>g__WaitTimeout|0>d<object>>(object&,ET.ObjectWaitSystem.<>c__DisplayClass5_0.<<Wait>g__WaitTimeout|0>d<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.ReloadConfigConsoleHandler.<Run>d__0>(object&,ET.ReloadConfigConsoleHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,ET.SessionSystem.<>c__DisplayClass4_0.<<Call>g__Timeout|0>d>(object&,ET.SessionSystem.<>c__DisplayClass4_0.<<Call>g__Timeout|0>d&)
		// System.Void ET.ETAsyncTaskMethodBuilder<ET.EntityRef<object>>.AwaitUnsafeOnCompleted<object,ET.Client.TipsPanelComponentSystem.<>c__DisplayClass5_0.<<OpenTips>g__Create|0>d>(object&,ET.Client.TipsPanelComponentSystem.<>c__DisplayClass5_0.<<OpenTips>g__Create|0>d&)
		// System.Void ET.ETAsyncTaskMethodBuilder<System.ValueTuple<uint,object>>.AwaitUnsafeOnCompleted<object,ET.Client.RouterHelper.<GetRouterAddress>d__1>(object&,ET.Client.RouterHelper.<GetRouterAddress>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.CommonPanelComponentSystem.<YIUIOpen>d__2>(ET.ETTaskCompleted&,ET.Client.CommonPanelComponentSystem.<YIUIOpen>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.GMPanelComponentSystem.<YIUIOpen>d__5>(ET.ETTaskCompleted&,ET.Client.GMPanelComponentSystem.<YIUIOpen>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.GMViewComponentSystem.<YIUIOpen>d__3>(ET.ETTaskCompleted&,ET.Client.GMViewComponentSystem.<YIUIOpen>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.GM_Test.<Run>d__1>(ET.ETTaskCompleted&,ET.Client.GM_Test.<Run>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.GM_TipsTest1.<Run>d__1>(ET.ETTaskCompleted&,ET.Client.GM_TipsTest1.<Run>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.GM_TipsTest2.<Run>d__1>(ET.ETTaskCompleted&,ET.Client.GM_TipsTest2.<Run>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.GM_TipsTest3.<Run>d__1>(ET.ETTaskCompleted&,ET.Client.GM_TipsTest3.<Run>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.GM_TipsTest4.<Run>d__1>(ET.ETTaskCompleted&,ET.Client.GM_TipsTest4.<Run>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.GM_TipsTest5.<Run>d__1>(ET.ETTaskCompleted&,ET.Client.GM_TipsTest5.<Run>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.HotUpdatePanelComponentSystem.<YIUIOpen>d__2>(ET.ETTaskCompleted&,ET.Client.HotUpdatePanelComponentSystem.<YIUIOpen>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.JoystickViewComponentSystem.<YIUIOpen>d__2>(ET.ETTaskCompleted&,ET.Client.JoystickViewComponentSystem.<YIUIOpen>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.LobbyPanelComponentSystem.<YIUIOpen>d__2>(ET.ETTaskCompleted&,ET.Client.LobbyPanelComponentSystem.<YIUIOpen>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.LoginPanelComponentSystem.<YIUIOpen>d__5>(ET.ETTaskCompleted&,ET.Client.LoginPanelComponentSystem.<YIUIOpen>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.MainPanelComponentSystem.<YIUIOpen>d__2>(ET.ETTaskCompleted&,ET.Client.MainPanelComponentSystem.<YIUIOpen>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.MessageTipsViewComponentSystem.<YIUIOpen>d__5>(ET.ETTaskCompleted&,ET.Client.MessageTipsViewComponentSystem.<YIUIOpen>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.MessageTipsViewComponentSystem.<YIUIOpen>d__8>(ET.ETTaskCompleted&,ET.Client.MessageTipsViewComponentSystem.<YIUIOpen>d__8&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.MiniMapViewComponentSystem.<YIUIOpen>d__3>(ET.ETTaskCompleted&,ET.Client.MiniMapViewComponentSystem.<YIUIOpen>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.PopupTextPanelComponentSystem.<YIUIOpen>d__5>(ET.ETTaskCompleted&,ET.Client.PopupTextPanelComponentSystem.<YIUIOpen>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.RedDotPanelComponentSystem.<YIUIOpen>d__5>(ET.ETTaskCompleted&,ET.Client.RedDotPanelComponentSystem.<YIUIOpen>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.TextTipsViewComponentSystem.<YIUIOpen>d__5>(ET.ETTaskCompleted&,ET.Client.TextTipsViewComponentSystem.<YIUIOpen>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<object,ET.Client.GM_OpenReddotPanel.<Run>d__1>(object&,ET.Client.GM_OpenReddotPanel.<Run>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<object,ET.Client.TipsPanelComponentSystem.<OpenTips>d__5>(object&,ET.Client.TipsPanelComponentSystem.<OpenTips>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<object,ET.Client.TipsPanelComponentSystem.<PutTips>d__6>(object&,ET.Client.TipsPanelComponentSystem.<PutTips>d__6&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<object,ET.Client.TipsPanelComponentSystem.<YIUIOpen>d__2>(object&,ET.Client.TipsPanelComponentSystem.<YIUIOpen>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<object,ET.MoveComponentSystem.<MoveToAsync>d__5>(object&,ET.MoveComponentSystem.<MoveToAsync>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,ET.Client.ResourcesLoaderComponentSystem.<DownloadWebFilesAsync>d__12>(System.Runtime.CompilerServices.TaskAwaiter&,ET.Client.ResourcesLoaderComponentSystem.<DownloadWebFilesAsync>d__12&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,ET.Client.ResourcesLoaderComponentSystem.<UpdateManifestAsync>d__10>(System.Runtime.CompilerServices.TaskAwaiter&,ET.Client.ResourcesLoaderComponentSystem.<UpdateManifestAsync>d__10&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,ET.Client.ResourcesLoaderComponentSystem.<UpdateVersionAsync>d__9>(System.Runtime.CompilerServices.TaskAwaiter&,ET.Client.ResourcesLoaderComponentSystem.<UpdateVersionAsync>d__9&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.AwaitUnsafeOnCompleted<object,ET.Client.LoginHelper.<CreateRole>d__3>(object&,ET.Client.LoginHelper.<CreateRole>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.AwaitUnsafeOnCompleted<object,ET.Client.LoginHelper.<DeleteRole>d__4>(object&,ET.Client.LoginHelper.<DeleteRole>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.AwaitUnsafeOnCompleted<object,ET.Client.LoginHelper.<EnterGame>d__6>(object&,ET.Client.LoginHelper.<EnterGame>d__6&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.AwaitUnsafeOnCompleted<object,ET.Client.LoginHelper.<GetRealmKey>d__5>(object&,ET.Client.LoginHelper.<GetRealmKey>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.AwaitUnsafeOnCompleted<object,ET.Client.LoginHelper.<GetRoles>d__2>(object&,ET.Client.LoginHelper.<GetRoles>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.AwaitUnsafeOnCompleted<object,ET.Client.LoginHelper.<GetServerInfos>d__1>(object&,ET.Client.LoginHelper.<GetServerInfos>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.AwaitUnsafeOnCompleted<object,ET.Client.LoginHelper.<LoginAccount>d__0>(object&,ET.Client.LoginHelper.<LoginAccount>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.AwaitUnsafeOnCompleted<object,ET.Client.MoveHelper.<MoveToAsync>d__0>(object&,ET.Client.MoveHelper.<MoveToAsync>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<long>.AwaitUnsafeOnCompleted<object,ET.Client.ClientSenderComponentSystem.<EnterGameAsync>d__5>(object&,ET.Client.ClientSenderComponentSystem.<EnterGameAsync>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder<long>.AwaitUnsafeOnCompleted<object,ET.Client.ClientSenderComponentSystem.<LoginAsync>d__6>(object&,ET.Client.ClientSenderComponentSystem.<LoginAsync>d__6&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,ET.Client.UILobbyEvent.<OnCreate>d__0>(ET.ETTaskCompleted&,ET.Client.UILobbyEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,ET.Client.ResourcesLoaderComponentSystem.<LoadAllAssetsAsync>d__5<object>>(System.Runtime.CompilerServices.TaskAwaiter&,ET.Client.ResourcesLoaderComponentSystem.<LoadAllAssetsAsync>d__5<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,ET.Client.ResourcesLoaderComponentSystem.<LoadAssetAsync>d__4<object>>(System.Runtime.CompilerServices.TaskAwaiter&,ET.Client.ResourcesLoaderComponentSystem.<LoadAssetAsync>d__4<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,ET.Client.ResourcesLoaderComponentSystem.<LoadSubAssetsAsync>d__6<object>>(System.Runtime.CompilerServices.TaskAwaiter&,ET.Client.ResourcesLoaderComponentSystem.<LoadSubAssetsAsync>d__6<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,ET.Client.HttpClientHelper.<Get>d__0>(System.Runtime.CompilerServices.TaskAwaiter<object>&,ET.Client.HttpClientHelper.<Get>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,ET.Client.TapTapSDKHelper.<Login>d__1>(System.Runtime.CompilerServices.TaskAwaiter<object>&,ET.Client.TapTapSDKHelper.<Login>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.ClientSenderComponentSystem.<Call>d__8>(object&,ET.Client.ClientSenderComponentSystem.<Call>d__8&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.GameObjectPoolHelper.<GetGameObjectAsync>d__5>(object&,ET.Client.GameObjectPoolHelper.<GetGameObjectAsync>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.GameObjectPoolHelper.<GetObjectFromPoolAsync>d__2>(object&,ET.Client.GameObjectPoolHelper.<GetObjectFromPoolAsync>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.ResourcesLoaderComponentSystem.<LoadAllAssetsAsync>d__5<object>>(object&,ET.Client.ResourcesLoaderComponentSystem.<LoadAllAssetsAsync>d__5<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.ResourcesLoaderComponentSystem.<LoadAssetAsync>d__4<object>>(object&,ET.Client.ResourcesLoaderComponentSystem.<LoadAssetAsync>d__4<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.RouterHelper.<CreateRouterSession>d__0>(object&,ET.Client.RouterHelper.<CreateRouterSession>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UIBagEvent.<OnCreate>d__0>(object&,ET.Client.UIBagEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UIComponentSystem.<Create>d__1>(object&,ET.Client.UIComponentSystem.<Create>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UIFlyTipEvent.<OnCreate>d__0>(object&,ET.Client.UIFlyTipEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UIGMEvent.<OnCreate>d__0>(object&,ET.Client.UIGMEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UIGlobalComponentSystem.<OnCreate>d__1>(object&,ET.Client.UIGlobalComponentSystem.<OnCreate>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UIHelpEvent.<OnCreate>d__0>(object&,ET.Client.UIHelpEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UIHotUpdateEvent.<OnCreate>d__0>(object&,ET.Client.UIHotUpdateEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UILSLobbyEvent.<OnCreate>d__0>(object&,ET.Client.UILSLobbyEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UILSLoginEvent.<OnCreate>d__0>(object&,ET.Client.UILSLoginEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UILSRoomEvent.<OnCreate>d__0>(object&,ET.Client.UILSRoomEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UILobbyEvent.<OnCreate>d__0>(object&,ET.Client.UILobbyEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UILoginEvent.<OnCreate>d__0>(object&,ET.Client.UILoginEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UIMainEvent.<OnCreate>d__0>(object&,ET.Client.UIMainEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UIRolesEvent.<OnCreate>d__0>(object&,ET.Client.UIRolesEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UIServerEvent.<OnCreate>d__0>(object&,ET.Client.UIServerEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.Client.UISettingsEvent.<OnCreate>d__0>(object&,ET.Client.UISettingsEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.ObjectWaitSystem.<Wait>d__4<object>>(object&,ET.ObjectWaitSystem.<Wait>d__4<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.ObjectWaitSystem.<Wait>d__5<object>>(object&,ET.ObjectWaitSystem.<Wait>d__5<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.RpcInfo.<Wait>d__7>(object&,ET.RpcInfo.<Wait>d__7&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.SessionSystem.<Call>d__3>(object&,ET.SessionSystem.<Call>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,ET.SessionSystem.<Call>d__4>(object&,ET.SessionSystem.<Call>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder<uint>.AwaitUnsafeOnCompleted<object,ET.Client.RouterHelper.<Connect>d__2>(object&,ET.Client.RouterHelper.<Connect>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.A2C_DisconnectHandler.<Run>d__0>(ET.Client.A2C_DisconnectHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.A2NetClient_MessageHandler.<Run>d__0>(ET.Client.A2NetClient_MessageHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.A2NetClient_RequestHandler.<Run>d__0>(ET.Client.A2NetClient_RequestHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.AE_PlayEffect.<Execute>d__0>(ET.Client.AE_PlayEffect.<Execute>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.AE_PlaySound.<Execute>d__0>(ET.Client.AE_PlaySound.<Execute>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.AfterCreateClientScene_LSAddComponent.<Run>d__0>(ET.Client.AfterCreateClientScene_LSAddComponent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.AfterUnitCreate_CreateUnitView.<Run>d__0>(ET.Client.AfterUnitCreate_CreateUnitView.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.AppStartInitFinish_CreateLoginUI.<Run>d__0>(ET.Client.AppStartInitFinish_CreateLoginUI.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.AppStartInitFinish_CreateUILSLogin.<Run>d__0>(ET.Client.AppStartInitFinish_CreateUILSLogin.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.ChangePosition_SyncGameObjectPos.<Run>d__0>(ET.Client.ChangePosition_SyncGameObjectPos.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.ChangeRotation_SyncGameObjectRotation.<Run>d__0>(ET.Client.ChangeRotation_SyncGameObjectRotation.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.ClientSenderComponentSystem.<ConnectAccountAsync>d__4>(ET.Client.ClientSenderComponentSystem.<ConnectAccountAsync>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.ClientSenderComponentSystem.<DisposeAsync>d__3>(ET.Client.ClientSenderComponentSystem.<DisposeAsync>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.ClientSenderComponentSystem.<RemoveFiberAsync>d__2>(ET.Client.ClientSenderComponentSystem.<RemoveFiberAsync>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.EnterMapHelper.<EnterMapAsync>d__0>(ET.Client.EnterMapHelper.<EnterMapAsync>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.EnterMapHelper.<Match>d__1>(ET.Client.EnterMapHelper.<Match>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.EntryEvent3_InitClient.<Run>d__0>(ET.Client.EntryEvent3_InitClient.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.EntryEvent3_InitClient.<StartHotUpdate>d__1>(ET.Client.EntryEvent3_InitClient.<StartHotUpdate>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.FiberInit_NetClient.<Handle>d__0>(ET.Client.FiberInit_NetClient.<Handle>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.FlyTipComponentSystem.<OnAwake>d__3>(ET.Client.FlyTipComponentSystem.<OnAwake>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.G2C_ReconnectHandler.<Run>d__0>(ET.Client.G2C_ReconnectHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.GMCommandComponentSystem.<Run>d__5>(ET.Client.GMCommandComponentSystem.<Run>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.GMCommandItemComponentSystem.<WaitRefresh>d__6>(ET.Client.GMCommandItemComponentSystem.<WaitRefresh>d__6&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.GMViewComponentSystem.<YIUIEvent>d__2>(ET.Client.GMViewComponentSystem.<YIUIEvent>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.HitResult_View.<Run>d__0>(ET.Client.HitResult_View.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.LSSceneChangeHelper.<SceneChangeTo>d__0>(ET.Client.LSSceneChangeHelper.<SceneChangeTo>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.LSSceneChangeHelper.<SceneChangeToReconnect>d__2>(ET.Client.LSSceneChangeHelper.<SceneChangeToReconnect>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.LSSceneChangeHelper.<SceneChangeToReplay>d__1>(ET.Client.LSSceneChangeHelper.<SceneChangeToReplay>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.LSSceneChangeStart_AddComponent.<Run>d__0>(ET.Client.LSSceneChangeStart_AddComponent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.LSSceneInitFinish_Finish.<Run>d__0>(ET.Client.LSSceneInitFinish_Finish.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.LSUnitViewComponentSystem.<InitAsync>d__2>(ET.Client.LSUnitViewComponentSystem.<InitAsync>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.LobbyPanelComponentSystem.<OnEventEnterAction>d__3>(ET.Client.LobbyPanelComponentSystem.<OnEventEnterAction>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.LoginFinish_CreateLobbyUI.<Run>d__0>(ET.Client.LoginFinish_CreateLobbyUI.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.LoginFinish_CreateUILSLobby.<Run>d__0>(ET.Client.LoginFinish_CreateUILSLobby.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.LoginFinish_RemoveLoginUI.<Run>d__0>(ET.Client.LoginFinish_RemoveLoginUI.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.LoginFinish_RemoveUILSLogin.<Run>d__0>(ET.Client.LoginFinish_RemoveUILSLogin.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.LoginHelper.<Login>d__7>(ET.Client.LoginHelper.<Login>d__7&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.LoginPanelComponentSystem.<OnEventLoginAction>d__8>(ET.Client.LoginPanelComponentSystem.<OnEventLoginAction>d__8&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.LoginPanelComponentSystem.<OnLogin>d__11>(ET.Client.LoginPanelComponentSystem.<OnLogin>d__11&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.LoginPanelComponentSystem.<OnTapTapBtn>d__9>(ET.Client.LoginPanelComponentSystem.<OnTapTapBtn>d__9&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_AllItemsHandler.<Run>d__0>(ET.Client.M2C_AllItemsHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_CreateMyUnitHandler.<Run>d__0>(ET.Client.M2C_CreateMyUnitHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_CreateUnitsHandler.<Run>d__0>(ET.Client.M2C_CreateUnitsHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_HitResultHandler.<Run>d__0>(ET.Client.M2C_HitResultHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_ItemUpdateOpHandler.<Run>d__0>(ET.Client.M2C_ItemUpdateOpHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_NoticeUnitNumericHandler.<Run>d__0>(ET.Client.M2C_NoticeUnitNumericHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_PathfindingResultHandler.<Run>d__0>(ET.Client.M2C_PathfindingResultHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_RemoveUnitsHandler.<Run>d__0>(ET.Client.M2C_RemoveUnitsHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_SkillUpdateOpHandler.<Run>d__0>(ET.Client.M2C_SkillUpdateOpHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_SpellSkillHandler.<Run>d__0>(ET.Client.M2C_SpellSkillHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_StartSceneChangeHandler.<Run>d__0>(ET.Client.M2C_StartSceneChangeHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.M2C_StopHandler.<Run>d__0>(ET.Client.M2C_StopHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.Main2NetClient_ConnectAccountHandler.<Run>d__0>(ET.Client.Main2NetClient_ConnectAccountHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.Main2NetClient_EnterGameHandler.<Run>d__0>(ET.Client.Main2NetClient_EnterGameHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.Main2NetClient_LoginHandler.<Run>d__0>(ET.Client.Main2NetClient_LoginHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.MaskWordComponentSystem.<InitMaskWord>d__1>(ET.Client.MaskWordComponentSystem.<InitMaskWord>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.MaskWordComponentSystem.<InitMaskWordText>d__2>(ET.Client.MaskWordComponentSystem.<InitMaskWordText>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.Match2G_NotifyMatchSuccessHandler.<Run>d__0>(ET.Client.Match2G_NotifyMatchSuccessHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.MessageTipsViewComponentSystem.<YIUICloseTween>d__7>(ET.Client.MessageTipsViewComponentSystem.<YIUICloseTween>d__7&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.MessageTipsViewComponentSystem.<YIUIOpenTween>d__6>(ET.Client.MessageTipsViewComponentSystem.<YIUIOpenTween>d__6&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.MiniMapViewComponentSystem.<OnEnterScene>d__4>(ET.Client.MiniMapViewComponentSystem.<OnEnterScene>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.MoveHelper.<MoveToAsync>d__1>(ET.Client.MoveHelper.<MoveToAsync>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.MoveStart_Animator.<Run>d__0>(ET.Client.MoveStart_Animator.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.MoveStop_Animator.<Run>d__0>(ET.Client.MoveStop_Animator.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.NetClient2Main_SessionDisposeHandler.<Run>d__0>(ET.Client.NetClient2Main_SessionDisposeHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.OnPatchDownloadFailed_ShowFailedInfo.<Run>d__0>(ET.Client.OnPatchDownloadFailed_ShowFailedInfo.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.OnPatchDownloadOver_Reset.<Run>d__0>(ET.Client.OnPatchDownloadOver_Reset.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.OnPatchDownloadProgress_UpdateProgress.<Run>d__0>(ET.Client.OnPatchDownloadProgress_UpdateProgress.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.OneFrameInputsHandler.<Run>d__0>(ET.Client.OneFrameInputsHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.OperaComponentSystem.<Test1>d__2>(ET.Client.OperaComponentSystem.<Test1>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.OperaComponentSystem.<Test2>d__3>(ET.Client.OperaComponentSystem.<Test2>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.PingComponentSystem.<PingAsync>d__2>(ET.Client.PingComponentSystem.<PingAsync>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.PlayEffect_PlayView.<Run>d__0>(ET.Client.PlayEffect_PlayView.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.PlaySound_PlayView.<Run>d__0>(ET.Client.PlaySound_PlayView.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.RedDotPanelComponentSystem.<YIUIEvent>d__6>(ET.Client.RedDotPanelComponentSystem.<YIUIEvent>d__6&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.RedDotPanelComponentSystem.<YIUIEvent>d__7>(ET.Client.RedDotPanelComponentSystem.<YIUIEvent>d__7&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.RedDotPanelComponentSystem.<YIUIEvent>d__8>(ET.Client.RedDotPanelComponentSystem.<YIUIEvent>d__8&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.RemoveEffect_RemoveView.<Run>d__0>(ET.Client.RemoveEffect_RemoveView.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.ResourcesLoaderComponentSystem.<LoadSceneAsync>d__8>(ET.Client.ResourcesLoaderComponentSystem.<LoadSceneAsync>d__8&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.Room2C_AdjustUpdateTimeHandler.<Run>d__0>(ET.Client.Room2C_AdjustUpdateTimeHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.Room2C_CheckHashFailHandler.<Run>d__0>(ET.Client.Room2C_CheckHashFailHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.Room2C_StartHandler.<Run>d__0>(ET.Client.Room2C_StartHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.RouterAddressComponentSystem.<GetAllRouter>d__2>(ET.Client.RouterAddressComponentSystem.<GetAllRouter>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.RouterAddressComponentSystem.<Init>d__1>(ET.Client.RouterAddressComponentSystem.<Init>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.RouterAddressComponentSystem.<WaitTenMinGetAllRouter>d__3>(ET.Client.RouterAddressComponentSystem.<WaitTenMinGetAllRouter>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.RouterCheckComponentSystem.<CheckAsync>d__1>(ET.Client.RouterCheckComponentSystem.<CheckAsync>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.SceneChangeFinishEvent.<Run>d__0>(ET.Client.SceneChangeFinishEvent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.SceneChangeHelper.<SceneChangeTo>d__0>(ET.Client.SceneChangeHelper.<SceneChangeTo>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.SceneChangeStartEvent.<Run>d__0>(ET.Client.SceneChangeStartEvent.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.ShowErrorTip_CreateView.<Run>d__0>(ET.Client.ShowErrorTip_CreateView.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.StartHotUpDate_CreatHotUpdateUI.<Run>d__0>(ET.Client.StartHotUpDate_CreatHotUpdateUI.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.TextTipsViewComponentSystem.<PlayAnimation>d__6>(ET.Client.TextTipsViewComponentSystem.<PlayAnimation>d__6&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.TipsHelper.<CloseTipsView>d__7>(ET.Client.TipsHelper.<CloseTipsView>d__7&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.TipsHelper.<Open>d__0<object>>(ET.Client.TipsHelper.<Open>d__0<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.TipsHelper.<OpenToParent2NewVo>d__6<object>>(ET.Client.TipsHelper.<OpenToParent2NewVo>d__6<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.TipsHelper.<OpenToParent>d__2<object>>(ET.Client.TipsHelper.<OpenToParent>d__2<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.TipsHelper.<OpenToParent>d__4<object>>(ET.Client.TipsHelper.<OpenToParent>d__4<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.TipsPanelComponentSystem.<YIUIEvent>d__3>(ET.Client.TipsPanelComponentSystem.<YIUIEvent>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIBagComponentSystem.<Refresh>d__2>(ET.Client.UIBagComponentSystem.<Refresh>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UICommonItemSystem.<Refresh>d__1>(ET.Client.UICommonItemSystem.<Refresh>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIHelper.<>c__DisplayClass9_0.<<AddListenerAsync>g__clickAcionAsync|0>d>(ET.Client.UIHelper.<>c__DisplayClass9_0.<<AddListenerAsync>g__clickAcionAsync|0>d&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UILSLobbyComponentSystem.<EnterMap>d__1>(ET.Client.UILSLobbyComponentSystem.<EnterMap>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UILobbyComponentSystem.<EnterMap>d__1>(ET.Client.UILobbyComponentSystem.<EnterMap>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UILoginComponentSystem.<OnLogin>d__4>(ET.Client.UILoginComponentSystem.<OnLogin>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UILoginComponentSystem.<OnNormalLoginBtn>d__1>(ET.Client.UILoginComponentSystem.<OnNormalLoginBtn>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UILoginComponentSystem.<OnTapTapBtn>d__2>(ET.Client.UILoginComponentSystem.<OnTapTapBtn>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIMainComponentSystem.<OnAchievementBtn>d__9>(ET.Client.UIMainComponentSystem.<OnAchievementBtn>d__9&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIMainComponentSystem.<OnBagBtn>d__4>(ET.Client.UIMainComponentSystem.<OnBagBtn>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIMainComponentSystem.<OnPetBtn>d__5>(ET.Client.UIMainComponentSystem.<OnPetBtn>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIMainComponentSystem.<OnSettingsBtn>d__2>(ET.Client.UIMainComponentSystem.<OnSettingsBtn>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIMainComponentSystem.<OnSkillBtn>d__6>(ET.Client.UIMainComponentSystem.<OnSkillBtn>d__6&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIMainComponentSystem.<OnSocialBtn>d__8>(ET.Client.UIMainComponentSystem.<OnSocialBtn>d__8&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIMainComponentSystem.<OnTaskBtn>d__7>(ET.Client.UIMainComponentSystem.<OnTaskBtn>d__7&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIMiniMapComponentSystem.<OnEnterScene>d__2>(ET.Client.UIMiniMapComponentSystem.<OnEnterScene>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIModelShowSystem.<ShowModel>d__5>(ET.Client.UIModelShowSystem.<ShowModel>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIRoleComponentSystem.<OnCreateBtn>d__1>(ET.Client.UIRoleComponentSystem.<OnCreateBtn>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIRoleComponentSystem.<OnDeleteBtn>d__2>(ET.Client.UIRoleComponentSystem.<OnDeleteBtn>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIRoleComponentSystem.<OnEnterGameBtn>d__3>(ET.Client.UIRoleComponentSystem.<OnEnterGameBtn>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIRoleComponentSystem.<UpdateRoleList>d__4>(ET.Client.UIRoleComponentSystem.<UpdateRoleList>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIServerComponentSystem.<OnConfirmBtn>d__1>(ET.Client.UIServerComponentSystem.<OnConfirmBtn>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UIServerComponentSystem.<ShowServerList>d__2>(ET.Client.UIServerComponentSystem.<ShowServerList>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.UISkillGridSystem.<RefeshIcon>d__3>(ET.Client.UISkillGridSystem.<RefeshIcon>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.YIUIEventSystem.<UIEvent>d__20<ET.Client.EventPutTipsView>>(ET.Client.YIUIEventSystem.<UIEvent>d__20<ET.Client.EventPutTipsView>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.YIUIEventSystem.<UIEvent>d__20<ET.Client.OnClickChildListEvent>>(ET.Client.YIUIEventSystem.<UIEvent>d__20<ET.Client.OnClickChildListEvent>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.YIUIEventSystem.<UIEvent>d__20<ET.Client.OnClickItemEvent>>(ET.Client.YIUIEventSystem.<UIEvent>d__20<ET.Client.OnClickItemEvent>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.YIUIEventSystem.<UIEvent>d__20<ET.Client.OnClickParentListEvent>>(ET.Client.YIUIEventSystem.<UIEvent>d__20<ET.Client.OnClickParentListEvent>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Client.YIUIEventSystem.<UIEvent>d__20<ET.Client.OnGMEventClose>>(ET.Client.YIUIEventSystem.<UIEvent>d__20<ET.Client.OnGMEventClose>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.ConsoleComponentSystem.<Start>d__1>(ET.ConsoleComponentSystem.<Start>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.Entry.<StartAsync>d__2>(ET.Entry.<StartAsync>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EntryEvent1_InitShare.<Run>d__0>(ET.EntryEvent1_InitShare.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EventSystem.<PublishAsync>d__4<object,ET.Client.LSSceneChangeStart>>(ET.EventSystem.<PublishAsync>d__4<object,ET.Client.LSSceneChangeStart>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EventSystem.<PublishAsync>d__4<object,ET.Client.StartHotUpDate>>(ET.EventSystem.<PublishAsync>d__4<object,ET.Client.StartHotUpDate>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EventSystem.<PublishAsync>d__4<object,ET.EntryEvent1>>(ET.EventSystem.<PublishAsync>d__4<object,ET.EntryEvent1>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EventSystem.<PublishAsync>d__4<object,ET.EntryEvent2>>(ET.EventSystem.<PublishAsync>d__4<object,ET.EntryEvent2>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EventSystem.<PublishAsync>d__4<object,ET.EntryEvent3>>(ET.EventSystem.<PublishAsync>d__4<object,ET.EntryEvent3>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.EventSystem.<PublishAsync>d__4<object,ET.LoginFinish>>(ET.EventSystem.<PublishAsync>d__4<object,ET.LoginFinish>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.FiberInit_Main.<Handle>d__0>(ET.FiberInit_Main.<Handle>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.MailBoxType_OrderedMessageHandler.<HandleInner>d__1>(ET.MailBoxType_OrderedMessageHandler.<HandleInner>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.MailBoxType_UnOrderedMessageHandler.<HandleAsync>d__1>(ET.MailBoxType_UnOrderedMessageHandler.<HandleAsync>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.MessageHandler.<Handle>d__1<object,object,object>>(ET.MessageHandler.<Handle>d__1<object,object,object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.MessageHandler.<Handle>d__1<object,object>>(ET.MessageHandler.<Handle>d__1<object,object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.MessageSessionHandler.<HandleAsync>d__2<object,object>>(ET.MessageSessionHandler.<HandleAsync>d__2<object,object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.MessageSessionHandler.<HandleAsync>d__2<object>>(ET.MessageSessionHandler.<HandleAsync>d__2<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.NumericChangeEvent_NotifyWatcher.<Run>d__0>(ET.NumericChangeEvent_NotifyWatcher.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.ObjectWaitSystem.<>c__DisplayClass5_0.<<Wait>g__WaitTimeout|0>d<object>>(ET.ObjectWaitSystem.<>c__DisplayClass5_0.<<Wait>g__WaitTimeout|0>d<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.ReloadConfigConsoleHandler.<Run>d__0>(ET.ReloadConfigConsoleHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.ReloadDllConsoleHandler.<Run>d__0>(ET.ReloadDllConsoleHandler.<Run>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder.Start<ET.SessionSystem.<>c__DisplayClass4_0.<<Call>g__Timeout|0>d>(ET.SessionSystem.<>c__DisplayClass4_0.<<Call>g__Timeout|0>d&)
		// System.Void ET.ETAsyncTaskMethodBuilder<ET.Client.WaitType.Wait_Room2C_Start>.Start<ET.ObjectWaitSystem.<Wait>d__4<ET.Client.WaitType.Wait_Room2C_Start>>(ET.ObjectWaitSystem.<Wait>d__4<ET.Client.WaitType.Wait_Room2C_Start>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_CreateMyUnit>.Start<ET.ObjectWaitSystem.<Wait>d__4<ET.Client.Wait_CreateMyUnit>>(ET.ObjectWaitSystem.<Wait>d__4<ET.Client.Wait_CreateMyUnit>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_SceneChangeFinish>.Start<ET.ObjectWaitSystem.<Wait>d__4<ET.Client.Wait_SceneChangeFinish>>(ET.ObjectWaitSystem.<Wait>d__4<ET.Client.Wait_SceneChangeFinish>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_UnitStop>.Start<ET.ObjectWaitSystem.<Wait>d__4<ET.Client.Wait_UnitStop>>(ET.ObjectWaitSystem.<Wait>d__4<ET.Client.Wait_UnitStop>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<ET.EntityRef<object>>.Start<ET.Client.TipsPanelComponentSystem.<>c__DisplayClass5_0.<<OpenTips>g__Create|0>d>(ET.Client.TipsPanelComponentSystem.<>c__DisplayClass5_0.<<OpenTips>g__Create|0>d&)
		// System.Void ET.ETAsyncTaskMethodBuilder<System.ValueTuple<uint,object>>.Start<ET.Client.RouterHelper.<GetRouterAddress>d__1>(ET.Client.RouterHelper.<GetRouterAddress>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<ET.Client.CommonPanelComponentSystem.<YIUIOpen>d__2>(ET.Client.CommonPanelComponentSystem.<YIUIOpen>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<ET.Client.GMPanelComponentSystem.<YIUIOpen>d__5>(ET.Client.GMPanelComponentSystem.<YIUIOpen>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<ET.Client.GMViewComponentSystem.<YIUIOpen>d__3>(ET.Client.GMViewComponentSystem.<YIUIOpen>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<ET.Client.GM_OpenReddotPanel.<Run>d__1>(ET.Client.GM_OpenReddotPanel.<Run>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<ET.Client.GM_Test.<Run>d__1>(ET.Client.GM_Test.<Run>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<ET.Client.GM_TipsTest1.<Run>d__1>(ET.Client.GM_TipsTest1.<Run>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<ET.Client.GM_TipsTest2.<Run>d__1>(ET.Client.GM_TipsTest2.<Run>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<ET.Client.GM_TipsTest3.<Run>d__1>(ET.Client.GM_TipsTest3.<Run>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<ET.Client.GM_TipsTest4.<Run>d__1>(ET.Client.GM_TipsTest4.<Run>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<ET.Client.GM_TipsTest5.<Run>d__1>(ET.Client.GM_TipsTest5.<Run>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<ET.Client.HotUpdatePanelComponentSystem.<YIUIOpen>d__2>(ET.Client.HotUpdatePanelComponentSystem.<YIUIOpen>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<ET.Client.JoystickViewComponentSystem.<YIUIOpen>d__2>(ET.Client.JoystickViewComponentSystem.<YIUIOpen>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<ET.Client.LobbyPanelComponentSystem.<YIUIOpen>d__2>(ET.Client.LobbyPanelComponentSystem.<YIUIOpen>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<ET.Client.LoginPanelComponentSystem.<YIUIOpen>d__5>(ET.Client.LoginPanelComponentSystem.<YIUIOpen>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<ET.Client.MainPanelComponentSystem.<YIUIOpen>d__2>(ET.Client.MainPanelComponentSystem.<YIUIOpen>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<ET.Client.MessageTipsViewComponentSystem.<YIUIOpen>d__5>(ET.Client.MessageTipsViewComponentSystem.<YIUIOpen>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<ET.Client.MessageTipsViewComponentSystem.<YIUIOpen>d__8>(ET.Client.MessageTipsViewComponentSystem.<YIUIOpen>d__8&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<ET.Client.MiniMapViewComponentSystem.<YIUIOpen>d__3>(ET.Client.MiniMapViewComponentSystem.<YIUIOpen>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<ET.Client.PopupTextPanelComponentSystem.<YIUIOpen>d__5>(ET.Client.PopupTextPanelComponentSystem.<YIUIOpen>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<ET.Client.RedDotPanelComponentSystem.<YIUIOpen>d__5>(ET.Client.RedDotPanelComponentSystem.<YIUIOpen>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<ET.Client.TextTipsViewComponentSystem.<YIUIOpen>d__5>(ET.Client.TextTipsViewComponentSystem.<YIUIOpen>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<ET.Client.TipsPanelComponentSystem.<OpenTips>d__5>(ET.Client.TipsPanelComponentSystem.<OpenTips>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<ET.Client.TipsPanelComponentSystem.<PutTips>d__6>(ET.Client.TipsPanelComponentSystem.<PutTips>d__6&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<ET.Client.TipsPanelComponentSystem.<YIUIOpen>d__2>(ET.Client.TipsPanelComponentSystem.<YIUIOpen>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<ET.Client.YIUIMgrComponentSystem.<ClosePanelAsync>d__16<object>>(ET.Client.YIUIMgrComponentSystem.<ClosePanelAsync>d__16<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<ET.MoveComponentSystem.<MoveToAsync>d__5>(ET.MoveComponentSystem.<MoveToAsync>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.Start<ET.Client.LoginHelper.<CreateRole>d__3>(ET.Client.LoginHelper.<CreateRole>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.Start<ET.Client.LoginHelper.<DeleteRole>d__4>(ET.Client.LoginHelper.<DeleteRole>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.Start<ET.Client.LoginHelper.<EnterGame>d__6>(ET.Client.LoginHelper.<EnterGame>d__6&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.Start<ET.Client.LoginHelper.<GetRealmKey>d__5>(ET.Client.LoginHelper.<GetRealmKey>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.Start<ET.Client.LoginHelper.<GetRoles>d__2>(ET.Client.LoginHelper.<GetRoles>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.Start<ET.Client.LoginHelper.<GetServerInfos>d__1>(ET.Client.LoginHelper.<GetServerInfos>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.Start<ET.Client.LoginHelper.<LoginAccount>d__0>(ET.Client.LoginHelper.<LoginAccount>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.Start<ET.Client.MoveHelper.<MoveToAsync>d__0>(ET.Client.MoveHelper.<MoveToAsync>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.Start<ET.Client.ResourcesLoaderComponentSystem.<DownloadWebFilesAsync>d__12>(ET.Client.ResourcesLoaderComponentSystem.<DownloadWebFilesAsync>d__12&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.Start<ET.Client.ResourcesLoaderComponentSystem.<UpdateManifestAsync>d__10>(ET.Client.ResourcesLoaderComponentSystem.<UpdateManifestAsync>d__10&)
		// System.Void ET.ETAsyncTaskMethodBuilder<int>.Start<ET.Client.ResourcesLoaderComponentSystem.<UpdateVersionAsync>d__9>(ET.Client.ResourcesLoaderComponentSystem.<UpdateVersionAsync>d__9&)
		// System.Void ET.ETAsyncTaskMethodBuilder<long>.Start<ET.Client.ClientSenderComponentSystem.<EnterGameAsync>d__5>(ET.Client.ClientSenderComponentSystem.<EnterGameAsync>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder<long>.Start<ET.Client.ClientSenderComponentSystem.<LoginAsync>d__6>(ET.Client.ClientSenderComponentSystem.<LoginAsync>d__6&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.ClientSenderComponentSystem.<Call>d__8>(ET.Client.ClientSenderComponentSystem.<Call>d__8&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.GameObjectPoolHelper.<GetGameObjectAsync>d__5>(ET.Client.GameObjectPoolHelper.<GetGameObjectAsync>d__5&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.GameObjectPoolHelper.<GetObjectFromPoolAsync>d__2>(ET.Client.GameObjectPoolHelper.<GetObjectFromPoolAsync>d__2&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.HttpClientHelper.<Get>d__0>(ET.Client.HttpClientHelper.<Get>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.ResourcesLoaderComponentSystem.<LoadAllAssetsAsync>d__5<object>>(ET.Client.ResourcesLoaderComponentSystem.<LoadAllAssetsAsync>d__5<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.ResourcesLoaderComponentSystem.<LoadAssetAsync>d__4<object>>(ET.Client.ResourcesLoaderComponentSystem.<LoadAssetAsync>d__4<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.ResourcesLoaderComponentSystem.<LoadSubAssetsAsync>d__6<object>>(ET.Client.ResourcesLoaderComponentSystem.<LoadSubAssetsAsync>d__6<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.RouterHelper.<CreateRouterSession>d__0>(ET.Client.RouterHelper.<CreateRouterSession>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.TapTapSDKHelper.<Login>d__1>(ET.Client.TapTapSDKHelper.<Login>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UIBagEvent.<OnCreate>d__0>(ET.Client.UIBagEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UIComponentSystem.<Create>d__1>(ET.Client.UIComponentSystem.<Create>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UIFlyTipEvent.<OnCreate>d__0>(ET.Client.UIFlyTipEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UIGMEvent.<OnCreate>d__0>(ET.Client.UIGMEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UIGlobalComponentSystem.<OnCreate>d__1>(ET.Client.UIGlobalComponentSystem.<OnCreate>d__1&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UIHelpEvent.<OnCreate>d__0>(ET.Client.UIHelpEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UIHotUpdateEvent.<OnCreate>d__0>(ET.Client.UIHotUpdateEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UILSLobbyEvent.<OnCreate>d__0>(ET.Client.UILSLobbyEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UILSLoginEvent.<OnCreate>d__0>(ET.Client.UILSLoginEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UILSRoomEvent.<OnCreate>d__0>(ET.Client.UILSRoomEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UILobbyEvent.<OnCreate>d__0>(ET.Client.UILobbyEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UILoginEvent.<OnCreate>d__0>(ET.Client.UILoginEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UIMainEvent.<OnCreate>d__0>(ET.Client.UIMainEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UIRolesEvent.<OnCreate>d__0>(ET.Client.UIRolesEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UIServerEvent.<OnCreate>d__0>(ET.Client.UIServerEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.UISettingsEvent.<OnCreate>d__0>(ET.Client.UISettingsEvent.<OnCreate>d__0&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.YIUIPanelComponentSystem.<OpenViewAsync>d__11<object>>(ET.Client.YIUIPanelComponentSystem.<OpenViewAsync>d__11<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.YIUIRootComponentSystem.<OpenPanelAsync>d__1<object>>(ET.Client.YIUIRootComponentSystem.<OpenPanelAsync>d__1<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.Client.YIUIRootComponentSystem.<OpenPanelAsync>d__5<object,object,object,object>>(ET.Client.YIUIRootComponentSystem.<OpenPanelAsync>d__5<object,object,object,object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.ObjectWaitSystem.<Wait>d__4<object>>(ET.ObjectWaitSystem.<Wait>d__4<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.ObjectWaitSystem.<Wait>d__5<object>>(ET.ObjectWaitSystem.<Wait>d__5<object>&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.RpcInfo.<Wait>d__7>(ET.RpcInfo.<Wait>d__7&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.SessionSystem.<Call>d__3>(ET.SessionSystem.<Call>d__3&)
		// System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<ET.SessionSystem.<Call>d__4>(ET.SessionSystem.<Call>d__4&)
		// System.Void ET.ETAsyncTaskMethodBuilder<uint>.Start<ET.Client.RouterHelper.<Connect>d__2>(ET.Client.RouterHelper.<Connect>d__2&)
		// object ET.Entity.AddChild<object,int>(int,bool)
		// object ET.Entity.AddChild<object,object,object>(object,object,bool)
		// object ET.Entity.AddChild<object,object>(object,bool)
		// object ET.Entity.AddChildWithId<object,ET.Client.EffectData>(long,ET.Client.EffectData,bool)
		// object ET.Entity.AddChildWithId<object,int,int>(long,int,int,bool)
		// object ET.Entity.AddChildWithId<object,object,object,object>(long,object,object,object,bool)
		// object ET.Entity.AddChildWithId<object,object,object>(long,object,object,bool)
		// object ET.Entity.AddChildWithId<object,object>(long,object,bool)
		// object ET.Entity.AddChildWithId<object>(long,bool)
		// object ET.Entity.AddComponent<object,int,int>(int,int,bool)
		// object ET.Entity.AddComponent<object,int>(int,bool)
		// object ET.Entity.AddComponent<object,long>(long,bool)
		// object ET.Entity.AddComponent<object,object,int>(object,int,bool)
		// object ET.Entity.AddComponent<object,object,object>(object,object,bool)
		// object ET.Entity.AddComponent<object,object>(object,bool)
		// object ET.Entity.AddComponent<object>(bool)
		// object ET.Entity.AddComponentWithId<object,int,int>(long,int,int,bool)
		// object ET.Entity.AddComponentWithId<object,int>(long,int,bool)
		// object ET.Entity.AddComponentWithId<object,long>(long,long,bool)
		// object ET.Entity.AddComponentWithId<object,object,int>(long,object,int,bool)
		// object ET.Entity.AddComponentWithId<object,object,object,object>(long,object,object,object,bool)
		// object ET.Entity.AddComponentWithId<object,object,object>(long,object,object,bool)
		// object ET.Entity.AddComponentWithId<object,object>(long,object,bool)
		// object ET.Entity.AddComponentWithId<object>(long,bool)
		// object ET.Entity.GetChild<object>(long)
		// object ET.Entity.GetComponent<object>()
		// object ET.Entity.GetParent<object>()
		// System.Void ET.Entity.RemoveComponent<object>()
		// System.Void ET.EntitySystemSingleton.Awake<ET.Client.EffectData>(ET.Entity,ET.Client.EffectData)
		// System.Void ET.EntitySystemSingleton.Awake<int,int>(ET.Entity,int,int)
		// System.Void ET.EntitySystemSingleton.Awake<int>(ET.Entity,int)
		// System.Void ET.EntitySystemSingleton.Awake<long>(ET.Entity,long)
		// System.Void ET.EntitySystemSingleton.Awake<object,int>(ET.Entity,object,int)
		// System.Void ET.EntitySystemSingleton.Awake<object,object,object>(ET.Entity,object,object,object)
		// System.Void ET.EntitySystemSingleton.Awake<object,object>(ET.Entity,object,object)
		// System.Void ET.EntitySystemSingleton.Awake<object>(ET.Entity,object)
		// long ET.EnumHelper.FromString<long>(string)
		// System.Void ET.EventSystem.Invoke<ET.NetComponentOnRead>(long,ET.NetComponentOnRead)
		// System.Void ET.EventSystem.Publish<object,ET.AfterUnitCreate>(object,ET.AfterUnitCreate)
		// System.Void ET.EventSystem.Publish<object,ET.AppStartInitFinish>(object,ET.AppStartInitFinish)
		// System.Void ET.EventSystem.Publish<object,ET.ChangeEquipItem>(object,ET.ChangeEquipItem)
		// System.Void ET.EventSystem.Publish<object,ET.ChangePosition>(object,ET.ChangePosition)
		// System.Void ET.EventSystem.Publish<object,ET.ChangeRotation>(object,ET.ChangeRotation)
		// System.Void ET.EventSystem.Publish<object,ET.Client.LSSceneInitFinish>(object,ET.Client.LSSceneInitFinish)
		// System.Void ET.EventSystem.Publish<object,ET.Client.OnPatchDownloadFailed>(object,ET.Client.OnPatchDownloadFailed)
		// System.Void ET.EventSystem.Publish<object,ET.Client.OnPatchDownloadOver>(object,ET.Client.OnPatchDownloadOver)
		// System.Void ET.EventSystem.Publish<object,ET.Client.OnPatchDownloadProgress>(object,ET.Client.OnPatchDownloadProgress)
		// System.Void ET.EventSystem.Publish<object,ET.Client.PlayEffect>(object,ET.Client.PlayEffect)
		// System.Void ET.EventSystem.Publish<object,ET.Client.PlaySound>(object,ET.Client.PlaySound)
		// System.Void ET.EventSystem.Publish<object,ET.Client.ShowErrorTip>(object,ET.Client.ShowErrorTip)
		// System.Void ET.EventSystem.Publish<object,ET.Client.ShowItemTips>(object,ET.Client.ShowItemTips)
		// System.Void ET.EventSystem.Publish<object,ET.EnterMapFinish>(object,ET.EnterMapFinish)
		// System.Void ET.EventSystem.Publish<object,ET.HitResult>(object,ET.HitResult)
		// System.Void ET.EventSystem.Publish<object,ET.MoveStart>(object,ET.MoveStart)
		// System.Void ET.EventSystem.Publish<object,ET.MoveStop>(object,ET.MoveStop)
		// System.Void ET.EventSystem.Publish<object,ET.NumericChange>(object,ET.NumericChange)
		// System.Void ET.EventSystem.Publish<object,ET.SceneChangeFinish>(object,ET.SceneChangeFinish)
		// System.Void ET.EventSystem.Publish<object,ET.SceneChangeStart>(object,ET.SceneChangeStart)
		// System.Void ET.EventSystem.Publish<object,ET.UnitGetComponent>(object,ET.UnitGetComponent)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.Client.LSSceneChangeStart>(object,ET.Client.LSSceneChangeStart)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.Client.StartHotUpDate>(object,ET.Client.StartHotUpDate)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.EntryEvent1>(object,ET.EntryEvent1)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.EntryEvent2>(object,ET.EntryEvent2)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.EntryEvent3>(object,ET.EntryEvent3)
		// ET.ETTask ET.EventSystem.PublishAsync<object,ET.LoginFinish>(object,ET.LoginFinish)
		// object ET.MongoHelper.FromJson<object>(string)
		// System.Void ET.ObjectHelper.Swap<object>(object&,object&)
		// System.Void ET.RandomGenerator.BreakRank<object>(System.Collections.Generic.List<object>)
		// object ET.World.AddSingleton<object>()
		// string Luban.StringUtil.CollectionToString<float>(System.Collections.Generic.IEnumerable<float>)
		// string Luban.StringUtil.CollectionToString<int>(System.Collections.Generic.IEnumerable<int>)
		// string Luban.StringUtil.CollectionToString<object>(System.Collections.Generic.IEnumerable<object>)
		// System.Collections.Generic.List<object> MemoryPack.Formatters.ListFormatter.DeserializePackable<object>(MemoryPack.MemoryPackReader&)
		// System.Void MemoryPack.Formatters.ListFormatter.DeserializePackable<object>(MemoryPack.MemoryPackReader&,System.Collections.Generic.List<object>&)
		// System.Void MemoryPack.Formatters.ListFormatter.SerializePackable<object>(MemoryPack.MemoryPackWriter&,System.Collections.Generic.List<object>&)
		// byte[] MemoryPack.Internal.MemoryMarshalEx.AllocateUninitializedArray<byte>(int,bool)
		// byte& MemoryPack.Internal.MemoryMarshalEx.GetArrayDataReference<byte>(byte[])
		// MemoryPack.MemoryPackFormatter<byte> MemoryPack.MemoryPackFormatterProvider.GetFormatter<byte>()
		// MemoryPack.MemoryPackFormatter<long> MemoryPack.MemoryPackFormatterProvider.GetFormatter<long>()
		// MemoryPack.MemoryPackFormatter<object> MemoryPack.MemoryPackFormatterProvider.GetFormatter<object>()
		// bool MemoryPack.MemoryPackFormatterProvider.IsRegistered<ET.LSInput>()
		// bool MemoryPack.MemoryPackFormatterProvider.IsRegistered<object>()
		// System.Void MemoryPack.MemoryPackFormatterProvider.Register<ET.LSInput>(MemoryPack.MemoryPackFormatter<ET.LSInput>)
		// System.Void MemoryPack.MemoryPackFormatterProvider.Register<object>(MemoryPack.MemoryPackFormatter<object>)
		// System.Void MemoryPack.MemoryPackReader.DangerousReadUnmanagedArray<byte>(byte[]&)
		// byte[] MemoryPack.MemoryPackReader.DangerousReadUnmanagedArray<byte>()
		// MemoryPack.IMemoryPackFormatter<byte> MemoryPack.MemoryPackReader.GetFormatter<byte>()
		// MemoryPack.IMemoryPackFormatter<long> MemoryPack.MemoryPackReader.GetFormatter<long>()
		// MemoryPack.IMemoryPackFormatter<object> MemoryPack.MemoryPackReader.GetFormatter<object>()
		// System.Void MemoryPack.MemoryPackReader.ReadPackable<object>(object&)
		// object MemoryPack.MemoryPackReader.ReadPackable<object>()
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<ET.ActorId>(ET.ActorId&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<ET.LSInput>(ET.LSInput&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<TrueSync.TSQuaternion>(TrueSync.TSQuaternion&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<TrueSync.TSVector>(TrueSync.TSVector&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<Unity.Mathematics.float3>(Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<Unity.Mathematics.quaternion,int>(Unity.Mathematics.quaternion&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<Unity.Mathematics.quaternion>(Unity.Mathematics.quaternion&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,ET.ActorId>(byte&,int&,ET.ActorId&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,Unity.Mathematics.float3>(byte&,int&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,int,long,float,float>(byte&,int&,int&,long&,float&,float&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,int,long>(byte&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,int>(byte&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,long,ET.LSInput>(byte&,int&,long&,ET.LSInput&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,long,Unity.Mathematics.float3,Unity.Mathematics.quaternion>(byte&,int&,long&,Unity.Mathematics.float3&,Unity.Mathematics.quaternion&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,long,long>(byte&,int&,long&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int,long>(byte&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,int>(byte&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,TrueSync.TSVector,TrueSync.TSQuaternion>(byte&,long&,TrueSync.TSVector&,TrueSync.TSQuaternion&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,Unity.Mathematics.float3>(byte&,long&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,int,int,Unity.Mathematics.float3,Unity.Mathematics.float3>(byte&,long&,int&,int&,Unity.Mathematics.float3&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,int,int,int>(byte&,long&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,int,long,float,Unity.Mathematics.float3>(byte&,long&,int&,long&,float&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,int,long,int>(byte&,long&,int&,long&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,int,long,long>(byte&,long&,int&,long&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,int,long>(byte&,long&,int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,int>(byte&,long&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long,long,int,int>(byte&,long&,long&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,long>(byte&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte,uint>(byte&,uint&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<byte>(byte&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<float>(float&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<int,int,int>(int&,int&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<int,long,long,long,int>(int&,long&,long&,long&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<int,long>(int&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<int>(int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<long,ET.LSInput>(long&,ET.LSInput&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<long,TrueSync.TSVector,TrueSync.TSQuaternion>(long&,TrueSync.TSVector&,TrueSync.TSQuaternion&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<long,int>(long&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<long,long,int>(long&,long&,int&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<long,long>(long&,long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<long>(long&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanaged<uint>(uint&)
		// System.Void MemoryPack.MemoryPackReader.ReadUnmanagedArray<byte>(byte[]&)
		// byte[] MemoryPack.MemoryPackReader.ReadUnmanagedArray<byte>()
		// System.Void MemoryPack.MemoryPackReader.ReadValue<object>(object&)
		// byte MemoryPack.MemoryPackReader.ReadValue<byte>()
		// long MemoryPack.MemoryPackReader.ReadValue<long>()
		// object MemoryPack.MemoryPackReader.ReadValue<object>()
		// System.Void MemoryPack.MemoryPackWriter.DangerousWriteUnmanagedArray<byte>(byte[])
		// MemoryPack.IMemoryPackFormatter<byte> MemoryPack.MemoryPackWriter.GetFormatter<byte>()
		// MemoryPack.IMemoryPackFormatter<long> MemoryPack.MemoryPackWriter.GetFormatter<long>()
		// MemoryPack.IMemoryPackFormatter<object> MemoryPack.MemoryPackWriter.GetFormatter<object>()
		// System.Void MemoryPack.MemoryPackWriter.WritePackable<object>(object&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<ET.LSInput>(ET.LSInput&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<Unity.Mathematics.quaternion,int>(Unity.Mathematics.quaternion&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<int,int,int>(int&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<int,long,long,long,int>(int&,long&,long&,long&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<int,long>(int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<int>(int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<long,ET.LSInput>(long&,ET.LSInput&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<long,TrueSync.TSVector,TrueSync.TSQuaternion>(long&,TrueSync.TSVector&,TrueSync.TSQuaternion&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<long,int>(long&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<long,long,int>(long&,long&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<long,long>(long&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanaged<long>(long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedArray<byte>(byte[])
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,ET.ActorId>(byte,byte&,int&,ET.ActorId&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,Unity.Mathematics.float3>(byte,byte&,int&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,int,long,float,float>(byte,byte&,int&,int&,long&,float&,float&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,int,long>(byte,byte&,int&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,int>(byte,byte&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,long,ET.LSInput>(byte,byte&,int&,long&,ET.LSInput&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,long,Unity.Mathematics.float3,Unity.Mathematics.quaternion>(byte,byte&,int&,long&,Unity.Mathematics.float3&,Unity.Mathematics.quaternion&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,long,long>(byte,byte&,int&,long&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int,long>(byte,byte&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,int>(byte,byte&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,TrueSync.TSVector,TrueSync.TSQuaternion>(byte,byte&,long&,TrueSync.TSVector&,TrueSync.TSQuaternion&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,Unity.Mathematics.float3>(byte,byte&,long&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,int,int,Unity.Mathematics.float3,Unity.Mathematics.float3>(byte,byte&,long&,int&,int&,Unity.Mathematics.float3&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,int,int,int>(byte,byte&,long&,int&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,int,long,float,Unity.Mathematics.float3>(byte,byte&,long&,int&,long&,float&,Unity.Mathematics.float3&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,int,long,int>(byte,byte&,long&,int&,long&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,int,long,long>(byte,byte&,long&,int&,long&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,int,long>(byte,byte&,long&,int&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,int>(byte,byte&,long&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long,long,int,int>(byte,byte&,long&,long&,int&,int&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,long>(byte,byte&,long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte,uint>(byte,byte&,uint&)
		// System.Void MemoryPack.MemoryPackWriter.WriteUnmanagedWithObjectHeader<byte>(byte,byte&)
		// System.Void MemoryPack.MemoryPackWriter.WriteValue<byte>(byte&)
		// System.Void MemoryPack.MemoryPackWriter.WriteValue<long>(long&)
		// System.Void MemoryPack.MemoryPackWriter.WriteValue<object>(object&)
		// object MongoDB.Bson.Serialization.BsonSerializer.Deserialize<object>(MongoDB.Bson.IO.IBsonReader,System.Action<MongoDB.Bson.Serialization.BsonDeserializationContext.Builder>)
		// object MongoDB.Bson.Serialization.BsonSerializer.Deserialize<object>(string,System.Action<MongoDB.Bson.Serialization.BsonDeserializationContext.Builder>)
		// MongoDB.Bson.Serialization.IBsonSerializer<object> MongoDB.Bson.Serialization.BsonSerializer.LookupSerializer<object>()
		// object MongoDB.Bson.Serialization.IBsonSerializerExtensions.Deserialize<object>(MongoDB.Bson.Serialization.IBsonSerializer<object>,MongoDB.Bson.Serialization.BsonDeserializationContext)
		// object System.Activator.CreateInstance<object>()
		// byte[] System.Array.Empty<byte>()
		// object[] System.Array.Empty<object>()
		// object System.Collections.Generic.CollectionExtensions.GetValueOrDefault<int,object>(System.Collections.Generic.IReadOnlyDictionary<int,object>,int)
		// object System.Collections.Generic.CollectionExtensions.GetValueOrDefault<int,object>(System.Collections.Generic.IReadOnlyDictionary<int,object>,int,object)
		// bool System.Enum.TryParse<int>(string,bool,int&)
		// bool System.Enum.TryParse<int>(string,int&)
		// int System.HashCode.Combine<TrueSync.TSVector2,int>(TrueSync.TSVector2,int)
		// int System.HashCode.Combine<object>(object)
		// System.Collections.Generic.IEnumerable<System.Numerics.Vector2> System.Linq.Enumerable.Select<ET.vector2,System.Numerics.Vector2>(System.Collections.Generic.IEnumerable<ET.vector2>,System.Func<ET.vector2,System.Numerics.Vector2>)
		// System.Collections.Generic.IEnumerable<System.Numerics.Vector3> System.Linq.Enumerable.Select<ET.vector3,System.Numerics.Vector3>(System.Collections.Generic.IEnumerable<ET.vector3>,System.Func<ET.vector3,System.Numerics.Vector3>)
		// ET.RpcInfo[] System.Linq.Enumerable.ToArray<ET.RpcInfo>(System.Collections.Generic.IEnumerable<ET.RpcInfo>)
		// System.Collections.Generic.List<ET.EntityRef<object>> System.Linq.Enumerable.ToList<ET.EntityRef<object>>(System.Collections.Generic.IEnumerable<ET.EntityRef<object>>)
		// System.Collections.Generic.List<System.Numerics.Vector2> System.Linq.Enumerable.ToList<System.Numerics.Vector2>(System.Collections.Generic.IEnumerable<System.Numerics.Vector2>)
		// System.Collections.Generic.List<System.Numerics.Vector3> System.Linq.Enumerable.ToList<System.Numerics.Vector3>(System.Collections.Generic.IEnumerable<System.Numerics.Vector3>)
		// System.Collections.Generic.List<long> System.Linq.Enumerable.ToList<long>(System.Collections.Generic.IEnumerable<long>)
		// System.Collections.Generic.List<object> System.Linq.Enumerable.ToList<object>(System.Collections.Generic.IEnumerable<object>)
		// System.Collections.Generic.IEnumerable<System.Numerics.Vector2> System.Linq.Enumerable.Iterator<ET.vector2>.Select<System.Numerics.Vector2>(System.Func<ET.vector2,System.Numerics.Vector2>)
		// System.Collections.Generic.IEnumerable<System.Numerics.Vector3> System.Linq.Enumerable.Iterator<ET.vector3>.Select<System.Numerics.Vector3>(System.Func<ET.vector3,System.Numerics.Vector3>)
		// System.Span<byte> System.MemoryExtensions.AsSpan<byte>(byte[])
		// bool System.MemoryExtensions.IsTypeComparableAsBytes<ushort>(ulong&)
		// bool System.MemoryExtensions.StartsWith<ushort>(System.ReadOnlySpan<ushort>,System.ReadOnlySpan<ushort>)
		// object System.Reflection.CustomAttributeExtensions.GetCustomAttribute<object>(System.Reflection.MemberInfo)
		// byte& System.Runtime.CompilerServices.Unsafe.Add<byte>(byte&,int)
		// ushort& System.Runtime.CompilerServices.Unsafe.Add<ushort>(ushort&,System.IntPtr)
		// bool System.Runtime.CompilerServices.Unsafe.AreSame<ushort>(ushort&,ushort&)
		// byte& System.Runtime.CompilerServices.Unsafe.As<byte,byte>(byte&)
		// byte& System.Runtime.CompilerServices.Unsafe.As<ushort,byte>(ushort&)
		// object& System.Runtime.CompilerServices.Unsafe.As<object,object>(object&)
		// byte& System.Runtime.CompilerServices.Unsafe.AsRef<byte>(byte&)
		// long& System.Runtime.CompilerServices.Unsafe.AsRef<long>(long&)
		// object& System.Runtime.CompilerServices.Unsafe.AsRef<object>(object&)
		// ET.ActorId System.Runtime.CompilerServices.Unsafe.ReadUnaligned<ET.ActorId>(byte&)
		// ET.LSInput System.Runtime.CompilerServices.Unsafe.ReadUnaligned<ET.LSInput>(byte&)
		// TrueSync.TSQuaternion System.Runtime.CompilerServices.Unsafe.ReadUnaligned<TrueSync.TSQuaternion>(byte&)
		// TrueSync.TSVector System.Runtime.CompilerServices.Unsafe.ReadUnaligned<TrueSync.TSVector>(byte&)
		// Unity.Mathematics.float3 System.Runtime.CompilerServices.Unsafe.ReadUnaligned<Unity.Mathematics.float3>(byte&)
		// Unity.Mathematics.quaternion System.Runtime.CompilerServices.Unsafe.ReadUnaligned<Unity.Mathematics.quaternion>(byte&)
		// byte System.Runtime.CompilerServices.Unsafe.ReadUnaligned<byte>(byte&)
		// float System.Runtime.CompilerServices.Unsafe.ReadUnaligned<float>(byte&)
		// int System.Runtime.CompilerServices.Unsafe.ReadUnaligned<int>(byte&)
		// long System.Runtime.CompilerServices.Unsafe.ReadUnaligned<long>(byte&)
		// uint System.Runtime.CompilerServices.Unsafe.ReadUnaligned<uint>(byte&)
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<ET.ActorId>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<ET.LSInput>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<TrueSync.TSQuaternion>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<TrueSync.TSVector>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<Unity.Mathematics.float3>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<Unity.Mathematics.quaternion>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<byte>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<float>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<int>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<long>()
		// int System.Runtime.CompilerServices.Unsafe.SizeOf<uint>()
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<ET.ActorId>(byte&,ET.ActorId)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<ET.LSInput>(byte&,ET.LSInput)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<TrueSync.TSQuaternion>(byte&,TrueSync.TSQuaternion)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<TrueSync.TSVector>(byte&,TrueSync.TSVector)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<Unity.Mathematics.float3>(byte&,Unity.Mathematics.float3)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<Unity.Mathematics.quaternion>(byte&,Unity.Mathematics.quaternion)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<byte>(byte&,byte)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<float>(byte&,float)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<int>(byte&,int)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<long>(byte&,long)
		// System.Void System.Runtime.CompilerServices.Unsafe.WriteUnaligned<uint>(byte&,uint)
		// byte& System.Runtime.InteropServices.MemoryMarshal.GetReference<byte>(System.Span<byte>)
		// ushort& System.Runtime.InteropServices.MemoryMarshal.GetReference<ushort>(System.ReadOnlySpan<ushort>)
		// bool System.SpanHelpers.SequenceEqual<ushort>(ushort&,ushort&,int)
		// System.Threading.Tasks.Task<object> System.Threading.Tasks.TaskFactory.StartNew<object>(System.Func<object>,System.Threading.CancellationToken)
		// object UnityEngine.Component.GetComponent<object>()
		// object[] UnityEngine.Component.GetComponentsInChildren<object>()
		// object[] UnityEngine.Component.GetComponentsInChildren<object>(bool)
		// object UnityEngine.GameObject.AddComponent<object>()
		// object UnityEngine.GameObject.GetComponent<object>()
		// object UnityEngine.GameObject.GetComponentInChildren<object>()
		// object UnityEngine.GameObject.GetComponentInChildren<object>(bool)
		// object[] UnityEngine.GameObject.GetComponentsInChildren<object>(bool)
		// object UnityEngine.Object.Instantiate<object>(object,UnityEngine.Transform)
		// object UnityEngine.Object.Instantiate<object>(object,UnityEngine.Transform,bool)
		// object UnityEngine.Resources.Load<object>(string)
		// YIUIFramework.ParamGetResult YIUIFramework.ParamVo.Get<byte>(byte&,int,byte)
		// YIUIFramework.ParamGetResult YIUIFramework.ParamVo.Get<float>(float&,int,float)
		// YIUIFramework.ParamGetResult YIUIFramework.ParamVo.Get<int>(int&,int,int)
		// YIUIFramework.ParamGetResult YIUIFramework.ParamVo.Get<long>(long&,int,long)
		// YIUIFramework.ParamGetResult YIUIFramework.ParamVo.Get<object>(object&,int,object)
		// byte YIUIFramework.ParamVo.Get<byte>(int,byte)
		// float YIUIFramework.ParamVo.Get<float>(int,float)
		// int YIUIFramework.ParamVo.Get<int>(int,int)
		// long YIUIFramework.ParamVo.Get<long>(int,long)
		// object YIUIFramework.ParamVo.Get<object>(int,object)
		// bool YIUIFramework.StrConv.ToNumber<byte>(string,byte&)
		// bool YIUIFramework.StrConv.ToNumber<float>(string,float&)
		// bool YIUIFramework.StrConv.ToNumber<int>(string,int&)
		// bool YIUIFramework.StrConv.ToNumber<long>(string,long&)
		// bool YIUIFramework.StrConv.ToNumber<object>(string,object&)
		// object YIUIFramework.UIBindCDETable.FindUIOwner<object>(string)
		// object YIUIFramework.UIBindComponentTable.FindComponent<object>(string)
		// object YIUIFramework.UIBindDataTable.FindDataValue<object>(string)
		// object YIUIFramework.UIBindEventTable.FindEvent<object>(string)
		// YooAsset.AllAssetsHandle YooAsset.ResourcePackage.LoadAllAssetsAsync<object>(string,uint)
		// YooAsset.AssetHandle YooAsset.ResourcePackage.LoadAssetAsync<object>(string,uint)
		// YooAsset.AssetHandle YooAsset.ResourcePackage.LoadAssetSync<object>(string)
		// YooAsset.SubAssetsHandle YooAsset.ResourcePackage.LoadSubAssetsAsync<object>(string,uint)
		// YooAsset.SubAssetsHandle YooAsset.ResourcePackage.LoadSubAssetsSync<object>(string)
		// string string.Join<float>(string,System.Collections.Generic.IEnumerable<float>)
		// string string.Join<int>(string,System.Collections.Generic.IEnumerable<int>)
		// string string.Join<object>(string,System.Collections.Generic.IEnumerable<object>)
		// string string.JoinCore<float>(System.Char*,int,System.Collections.Generic.IEnumerable<float>)
		// string string.JoinCore<int>(System.Char*,int,System.Collections.Generic.IEnumerable<int>)
		// string string.JoinCore<object>(System.Char*,int,System.Collections.Generic.IEnumerable<object>)
	}
}