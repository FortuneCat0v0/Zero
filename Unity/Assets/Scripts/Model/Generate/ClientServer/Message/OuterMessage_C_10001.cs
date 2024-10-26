using MemoryPack;
using System.Collections.Generic;

namespace ET
{
    [MemoryPackable]
    [Message(OuterMessage.HttpGetRouterResponse)]
    public partial class HttpGetRouterResponse : MessageObject
    {
        public static HttpGetRouterResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(HttpGetRouterResponse), isFromPool) as HttpGetRouterResponse;
        }

        [MemoryPackOrder(0)]
        public List<string> Realms { get; set; } = new();

        [MemoryPackOrder(1)]
        public List<string> Routers { get; set; } = new();

        [MemoryPackOrder(2)]
        public string Account { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Realms.Clear();
            this.Routers.Clear();
            this.Account = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.RouterSync)]
    public partial class RouterSync : MessageObject
    {
        public static RouterSync Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(RouterSync), isFromPool) as RouterSync;
        }

        [MemoryPackOrder(0)]
        public uint ConnectId { get; set; }

        [MemoryPackOrder(1)]
        public string Address { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.ConnectId = default;
            this.Address = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.KeyValuePair_Int_Int)]
    public partial class KeyValuePair_Int_Int : MessageObject
    {
        public static KeyValuePair_Int_Int Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(KeyValuePair_Int_Int), isFromPool) as KeyValuePair_Int_Int;
        }

        [MemoryPackOrder(0)]
        public int Key { get; set; }

        [MemoryPackOrder(1)]
        public int Value { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Key = default;
            this.Value = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_TestRequest)]
    [ResponseType(nameof(M2C_TestResponse))]
    public partial class C2M_TestRequest : MessageObject, ILocationRequest
    {
        public static C2M_TestRequest Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_TestRequest), isFromPool) as C2M_TestRequest;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string request { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.request = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_TestResponse)]
    public partial class M2C_TestResponse : MessageObject, IResponse
    {
        public static M2C_TestResponse Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_TestResponse), isFromPool) as M2C_TestResponse;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public string response { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.response = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2G_EnterMap)]
    [ResponseType(nameof(G2C_EnterMap))]
    public partial class C2G_EnterMap : MessageObject, ISessionRequest
    {
        public static C2G_EnterMap Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2G_EnterMap), isFromPool) as C2G_EnterMap;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.G2C_EnterMap)]
    public partial class G2C_EnterMap : MessageObject, ISessionResponse
    {
        public static G2C_EnterMap Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_EnterMap), isFromPool) as G2C_EnterMap;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        /// <summary>
        /// 自己的UnitId
        /// </summary>
        [MemoryPackOrder(3)]
        public long MyId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.MyId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.MoveInfo)]
    public partial class MoveInfo : MessageObject
    {
        public static MoveInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(MoveInfo), isFromPool) as MoveInfo;
        }

        [MemoryPackOrder(0)]
        public List<Unity.Mathematics.float3> Points { get; set; } = new();

        [MemoryPackOrder(1)]
        public Unity.Mathematics.quaternion Rotation { get; set; }

        [MemoryPackOrder(2)]
        public int TurnSpeed { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Points.Clear();
            this.Rotation = default;
            this.TurnSpeed = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.UnitInfo)]
    public partial class UnitInfo : MessageObject
    {
        public static UnitInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(UnitInfo), isFromPool) as UnitInfo;
        }

        [MemoryPackOrder(0)]
        public long UnitId { get; set; }

        [MemoryPackOrder(1)]
        public int EUnitType { get; set; }

        [MemoryPackOrder(2)]
        public int ConfigId { get; set; }

        [MemoryPackOrder(3)]
        public Unity.Mathematics.float3 Position { get; set; }

        [MemoryPackOrder(4)]
        public Unity.Mathematics.float3 Forward { get; set; }

        [MongoDB.Bson.Serialization.Attributes.BsonDictionaryOptions(MongoDB.Bson.Serialization.Options.DictionaryRepresentation.ArrayOfArrays)]
        [MemoryPackOrder(5)]
        public Dictionary<int, long> KV { get; set; } = new();
        [MemoryPackOrder(6)]
        public MoveInfo MoveInfo { get; set; }

        [MemoryPackOrder(7)]
        public List<SkillInfo> SkillInfos { get; set; } = new();

        [MemoryPackOrder(8)]
        public List<KeyValuePair_Int_Int> SkillGridDict { get; set; } = new();

        [MemoryPackOrder(9)]
        public int ERoleCamp { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.UnitId = default;
            this.EUnitType = default;
            this.ConfigId = default;
            this.Position = default;
            this.Forward = default;
            this.KV.Clear();
            this.MoveInfo = default;
            this.SkillInfos.Clear();
            this.SkillGridDict.Clear();
            this.ERoleCamp = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_CreateUnits)]
    public partial class M2C_CreateUnits : MessageObject, IMessage
    {
        public static M2C_CreateUnits Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_CreateUnits), isFromPool) as M2C_CreateUnits;
        }

        [MemoryPackOrder(0)]
        public List<UnitInfo> Units { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Units.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_CreateMyUnit)]
    public partial class M2C_CreateMyUnit : MessageObject, IMessage
    {
        public static M2C_CreateMyUnit Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_CreateMyUnit), isFromPool) as M2C_CreateMyUnit;
        }

        [MemoryPackOrder(0)]
        public UnitInfo Unit { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Unit = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_StartSceneChange)]
    public partial class M2C_StartSceneChange : MessageObject, IMessage
    {
        public static M2C_StartSceneChange Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_StartSceneChange), isFromPool) as M2C_StartSceneChange;
        }

        [MemoryPackOrder(0)]
        public long SceneInstanceId { get; set; }

        [MemoryPackOrder(1)]
        public string SceneName { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.SceneInstanceId = default;
            this.SceneName = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_RemoveUnits)]
    public partial class M2C_RemoveUnits : MessageObject, IMessage
    {
        public static M2C_RemoveUnits Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_RemoveUnits), isFromPool) as M2C_RemoveUnits;
        }

        [MemoryPackOrder(0)]
        public List<long> Units { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Units.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_PathfindingResult)]
    public partial class C2M_PathfindingResult : MessageObject, ILocationMessage
    {
        public static C2M_PathfindingResult Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_PathfindingResult), isFromPool) as C2M_PathfindingResult;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public Unity.Mathematics.float3 Position { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Position = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_Stop)]
    public partial class C2M_Stop : MessageObject, ILocationMessage
    {
        public static C2M_Stop Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_Stop), isFromPool) as C2M_Stop;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_PathfindingResult)]
    public partial class M2C_PathfindingResult : MessageObject, IMessage
    {
        public static M2C_PathfindingResult Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_PathfindingResult), isFromPool) as M2C_PathfindingResult;
        }

        [MemoryPackOrder(0)]
        public long UnitId { get; set; }

        [MemoryPackOrder(1)]
        public Unity.Mathematics.float3 Position { get; set; }

        [MemoryPackOrder(2)]
        public List<Unity.Mathematics.float3> Points { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.UnitId = default;
            this.Position = default;
            this.Points.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_Stop)]
    public partial class M2C_Stop : MessageObject, IMessage
    {
        public static M2C_Stop Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_Stop), isFromPool) as M2C_Stop;
        }

        [MemoryPackOrder(0)]
        public int Error { get; set; }

        [MemoryPackOrder(1)]
        public long UnitId { get; set; }

        [MemoryPackOrder(2)]
        public Unity.Mathematics.float3 Position { get; set; }

        [MemoryPackOrder(3)]
        public Unity.Mathematics.quaternion Rotation { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Error = default;
            this.UnitId = default;
            this.Position = default;
            this.Rotation = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2G_Ping)]
    [ResponseType(nameof(G2C_Ping))]
    public partial class C2G_Ping : MessageObject, ISessionRequest
    {
        public static C2G_Ping Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2G_Ping), isFromPool) as C2G_Ping;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.G2C_Ping)]
    public partial class G2C_Ping : MessageObject, ISessionResponse
    {
        public static G2C_Ping Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_Ping), isFromPool) as G2C_Ping;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public long Time { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.Time = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.G2C_Test)]
    public partial class G2C_Test : MessageObject, ISessionMessage
    {
        public static G2C_Test Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_Test), isFromPool) as G2C_Test;
        }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            
            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_Reload)]
    [ResponseType(nameof(M2C_Reload))]
    public partial class C2M_Reload : MessageObject, ISessionRequest
    {
        public static C2M_Reload Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_Reload), isFromPool) as C2M_Reload;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string Account { get; set; }

        [MemoryPackOrder(2)]
        public string Password { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Account = default;
            this.Password = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_Reload)]
    public partial class M2C_Reload : MessageObject, ISessionResponse
    {
        public static M2C_Reload Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_Reload), isFromPool) as M2C_Reload;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2R_Login)]
    [ResponseType(nameof(R2C_Login))]
    public partial class C2R_Login : MessageObject, ISessionRequest
    {
        public static C2R_Login Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2R_Login), isFromPool) as C2R_Login;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        /// <summary>
        /// 帐号
        /// </summary>
        [MemoryPackOrder(1)]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [MemoryPackOrder(2)]
        public string Password { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Account = default;
            this.Password = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.R2C_Login)]
    public partial class R2C_Login : MessageObject, ISessionResponse
    {
        public static R2C_Login Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(R2C_Login), isFromPool) as R2C_Login;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public string Address { get; set; }

        [MemoryPackOrder(4)]
        public long Key { get; set; }

        [MemoryPackOrder(5)]
        public long GateId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.Address = default;
            this.Key = default;
            this.GateId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2G_LoginGate)]
    [ResponseType(nameof(G2C_LoginGate))]
    public partial class C2G_LoginGate : MessageObject, ISessionRequest
    {
        public static C2G_LoginGate Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2G_LoginGate), isFromPool) as C2G_LoginGate;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        /// <summary>
        /// 帐号
        /// </summary>
        [MemoryPackOrder(1)]
        public long Key { get; set; }

        [MemoryPackOrder(2)]
        public long GateId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Key = default;
            this.GateId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.G2C_LoginGate)]
    public partial class G2C_LoginGate : MessageObject, ISessionResponse
    {
        public static G2C_LoginGate Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_LoginGate), isFromPool) as G2C_LoginGate;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public long PlayerId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.PlayerId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.G2C_TestHotfixMessage)]
    public partial class G2C_TestHotfixMessage : MessageObject, ISessionMessage
    {
        public static G2C_TestHotfixMessage Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_TestHotfixMessage), isFromPool) as G2C_TestHotfixMessage;
        }

        [MemoryPackOrder(0)]
        public string Info { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Info = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_TestRobotCase)]
    [ResponseType(nameof(M2C_TestRobotCase))]
    public partial class C2M_TestRobotCase : MessageObject, ILocationRequest
    {
        public static C2M_TestRobotCase Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_TestRobotCase), isFromPool) as C2M_TestRobotCase;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int N { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.N = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_TestRobotCase)]
    public partial class M2C_TestRobotCase : MessageObject, ILocationResponse
    {
        public static M2C_TestRobotCase Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_TestRobotCase), isFromPool) as M2C_TestRobotCase;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public int N { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.N = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_TestRobotCase2)]
    public partial class C2M_TestRobotCase2 : MessageObject, ILocationMessage
    {
        public static C2M_TestRobotCase2 Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_TestRobotCase2), isFromPool) as C2M_TestRobotCase2;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int N { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.N = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_TestRobotCase2)]
    public partial class M2C_TestRobotCase2 : MessageObject, ILocationMessage
    {
        public static M2C_TestRobotCase2 Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_TestRobotCase2), isFromPool) as M2C_TestRobotCase2;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int N { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.N = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_TransferMap)]
    [ResponseType(nameof(M2C_TransferMap))]
    public partial class C2M_TransferMap : MessageObject, ILocationRequest
    {
        public static C2M_TransferMap Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_TransferMap), isFromPool) as C2M_TransferMap;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_TransferMap)]
    public partial class M2C_TransferMap : MessageObject, ILocationResponse
    {
        public static M2C_TransferMap Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_TransferMap), isFromPool) as M2C_TransferMap;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2G_Benchmark)]
    [ResponseType(nameof(G2C_Benchmark))]
    public partial class C2G_Benchmark : MessageObject, ISessionRequest
    {
        public static C2G_Benchmark Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2G_Benchmark), isFromPool) as C2G_Benchmark;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.G2C_Benchmark)]
    public partial class G2C_Benchmark : MessageObject, ISessionResponse
    {
        public static G2C_Benchmark Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_Benchmark), isFromPool) as G2C_Benchmark;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2A_LoginAccount)]
    [ResponseType(nameof(A2C_LoginAccount))]
    public partial class C2A_LoginAccount : MessageObject, ISessionRequest
    {
        public static C2A_LoginAccount Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2A_LoginAccount), isFromPool) as C2A_LoginAccount;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string Account { get; set; }

        [MemoryPackOrder(2)]
        public string Password { get; set; }

        [MemoryPackOrder(3)]
        public int ELoginType { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Account = default;
            this.Password = default;
            this.ELoginType = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.A2C_LoginAccount)]
    public partial class A2C_LoginAccount : MessageObject, ISessionResponse
    {
        public static A2C_LoginAccount Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(A2C_LoginAccount), isFromPool) as A2C_LoginAccount;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public string Token { get; set; }

        [MemoryPackOrder(4)]
        public long AccountId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.Token = default;
            this.AccountId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.A2C_Disconnect)]
    public partial class A2C_Disconnect : MessageObject, IMessage
    {
        public static A2C_Disconnect Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(A2C_Disconnect), isFromPool) as A2C_Disconnect;
        }

        [MemoryPackOrder(0)]
        public int Error { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Error = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.ServerInfo)]
    public partial class ServerInfo : MessageObject
    {
        public static ServerInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ServerInfo), isFromPool) as ServerInfo;
        }

        [MemoryPackOrder(0)]
        public long Id { get; set; }

        [MemoryPackOrder(1)]
        public int Status { get; set; }

        [MemoryPackOrder(2)]
        public string ServerName { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Id = default;
            this.Status = default;
            this.ServerName = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2A_GetServers)]
    [ResponseType(nameof(A2C_GetServers))]
    public partial class C2A_GetServers : MessageObject, ISessionRequest
    {
        public static C2A_GetServers Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2A_GetServers), isFromPool) as C2A_GetServers;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string Token { get; set; }

        [MemoryPackOrder(2)]
        public long AccountId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Token = default;
            this.AccountId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.A2C_GetServers)]
    public partial class A2C_GetServers : MessageObject, ISessionResponse
    {
        public static A2C_GetServers Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(A2C_GetServers), isFromPool) as A2C_GetServers;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public List<ServerInfo> ServerInfos { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.ServerInfos.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.RoleInfo)]
    public partial class RoleInfo : MessageObject
    {
        public static RoleInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(RoleInfo), isFromPool) as RoleInfo;
        }

        [MemoryPackOrder(0)]
        public long Id { get; set; }

        [MemoryPackOrder(1)]
        public string Name { get; set; }

        [MemoryPackOrder(2)]
        public int State { get; set; }

        [MemoryPackOrder(3)]
        public long AccountId { get; set; }

        [MemoryPackOrder(4)]
        public long LastLoginTime { get; set; }

        [MemoryPackOrder(5)]
        public long CreateTime { get; set; }

        [MemoryPackOrder(6)]
        public int ServerId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Id = default;
            this.Name = default;
            this.State = default;
            this.AccountId = default;
            this.LastLoginTime = default;
            this.CreateTime = default;
            this.ServerId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2A_CreateRole)]
    [ResponseType(nameof(A2C_CreateRole))]
    public partial class C2A_CreateRole : MessageObject, ISessionRequest
    {
        public static C2A_CreateRole Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2A_CreateRole), isFromPool) as C2A_CreateRole;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string Token { get; set; }

        [MemoryPackOrder(2)]
        public long AccountId { get; set; }

        [MemoryPackOrder(3)]
        public string Name { get; set; }

        [MemoryPackOrder(4)]
        public int ServerId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Token = default;
            this.AccountId = default;
            this.Name = default;
            this.ServerId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.A2C_CreateRole)]
    public partial class A2C_CreateRole : MessageObject, ISessionResponse
    {
        public static A2C_CreateRole Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(A2C_CreateRole), isFromPool) as A2C_CreateRole;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public RoleInfo RoleInfo { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.RoleInfo = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2A_GetRoles)]
    [ResponseType(nameof(A2C_GetRoles))]
    public partial class C2A_GetRoles : MessageObject, ISessionRequest
    {
        public static C2A_GetRoles Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2A_GetRoles), isFromPool) as C2A_GetRoles;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string Token { get; set; }

        [MemoryPackOrder(2)]
        public long AccountId { get; set; }

        [MemoryPackOrder(3)]
        public int ServerId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Token = default;
            this.AccountId = default;
            this.ServerId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.A2C_GetRoles)]
    public partial class A2C_GetRoles : MessageObject, ISessionResponse
    {
        public static A2C_GetRoles Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(A2C_GetRoles), isFromPool) as A2C_GetRoles;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public List<RoleInfo> RoleInfos { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.RoleInfos.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2A_DeleteRole)]
    [ResponseType(nameof(A2C_DeleteRole))]
    public partial class C2A_DeleteRole : MessageObject, ISessionRequest
    {
        public static C2A_DeleteRole Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2A_DeleteRole), isFromPool) as C2A_DeleteRole;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string Token { get; set; }

        [MemoryPackOrder(2)]
        public long AccountId { get; set; }

        [MemoryPackOrder(3)]
        public long RoleId { get; set; }

        [MemoryPackOrder(4)]
        public int ServerId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Token = default;
            this.AccountId = default;
            this.RoleId = default;
            this.ServerId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.A2C_DeleteRole)]
    public partial class A2C_DeleteRole : MessageObject, ISessionResponse
    {
        public static A2C_DeleteRole Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(A2C_DeleteRole), isFromPool) as A2C_DeleteRole;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public long DeletedRoleId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.DeletedRoleId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2A_GetRealmKey)]
    [ResponseType(nameof(A2C_GetRealmKey))]
    public partial class C2A_GetRealmKey : MessageObject, ISessionRequest
    {
        public static C2A_GetRealmKey Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2A_GetRealmKey), isFromPool) as C2A_GetRealmKey;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string Token { get; set; }

        [MemoryPackOrder(2)]
        public int ServerId { get; set; }

        [MemoryPackOrder(3)]
        public long AccountId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Token = default;
            this.ServerId = default;
            this.AccountId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.A2C_GetRealmKey)]
    public partial class A2C_GetRealmKey : MessageObject, ISessionResponse
    {
        public static A2C_GetRealmKey Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(A2C_GetRealmKey), isFromPool) as A2C_GetRealmKey;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public string RealmKey { get; set; }

        [MemoryPackOrder(4)]
        public string RealmAddress { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.RealmKey = default;
            this.RealmAddress = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2R_LoginRealm)]
    [ResponseType(nameof(R2C_LoginRealm))]
    public partial class C2R_LoginRealm : MessageObject, ISessionRequest
    {
        public static C2R_LoginRealm Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2R_LoginRealm), isFromPool) as C2R_LoginRealm;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long AccountId { get; set; }

        [MemoryPackOrder(2)]
        public string RealmTokenKey { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.AccountId = default;
            this.RealmTokenKey = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.R2C_LoginRealm)]
    public partial class R2C_LoginRealm : MessageObject, ISessionResponse
    {
        public static R2C_LoginRealm Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(R2C_LoginRealm), isFromPool) as R2C_LoginRealm;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public string GateSessionKey { get; set; }

        [MemoryPackOrder(4)]
        public string GateAddress { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.GateSessionKey = default;
            this.GateAddress = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2G_LoginGameGate)]
    [ResponseType(nameof(G2C_LoginGameGate))]
    public partial class C2G_LoginGameGate : MessageObject, ISessionRequest
    {
        public static C2G_LoginGameGate Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2G_LoginGameGate), isFromPool) as C2G_LoginGameGate;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string Key { get; set; }

        [MemoryPackOrder(2)]
        public long RoleId { get; set; }

        [MemoryPackOrder(3)]
        public long AccountId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Key = default;
            this.RoleId = default;
            this.AccountId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.G2C_LoginGameGate)]
    public partial class G2C_LoginGameGate : MessageObject, ISessionResponse
    {
        public static G2C_LoginGameGate Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_LoginGameGate), isFromPool) as G2C_LoginGameGate;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2G_EnterGame)]
    [ResponseType(nameof(G2C_EnterGame))]
    public partial class C2G_EnterGame : MessageObject, ISessionRequest
    {
        public static C2G_EnterGame Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2G_EnterGame), isFromPool) as C2G_EnterGame;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.G2C_EnterGame)]
    public partial class G2C_EnterGame : MessageObject, ISessionResponse
    {
        public static G2C_EnterGame Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_EnterGame), isFromPool) as G2C_EnterGame;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        /// <summary>
        /// 自己unitId
        /// </summary>
        [MemoryPackOrder(3)]
        public long MyId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.MyId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_GM)]
    [ResponseType(nameof(M2C_GM))]
    public partial class C2M_GM : MessageObject, ILocationRequest
    {
        public static C2M_GM Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_GM), isFromPool) as C2M_GM;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string GMMessage { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.GMMessage = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_GM)]
    public partial class M2C_GM : MessageObject, ILocationResponse
    {
        public static M2C_GM Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_GM), isFromPool) as M2C_GM;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.AttributeEntryInfo)]
    public partial class AttributeEntryInfo : MessageObject
    {
        public static AttributeEntryInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(AttributeEntryInfo), isFromPool) as AttributeEntryInfo;
        }

        [MemoryPackOrder(0)]
        public long Id { get; set; }

        [MemoryPackOrder(1)]
        public int Key { get; set; }

        [MemoryPackOrder(2)]
        public long Value { get; set; }

        [MemoryPackOrder(3)]
        public int EntryType { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Id = default;
            this.Key = default;
            this.Value = default;
            this.EntryType = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.ItemInfo)]
    public partial class ItemInfo : MessageObject
    {
        public static ItemInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(ItemInfo), isFromPool) as ItemInfo;
        }

        [MemoryPackOrder(0)]
        public long Id { get; set; }

        [MemoryPackOrder(1)]
        public int ConfigId { get; set; }

        [MemoryPackOrder(2)]
        public int Quality { get; set; }

        [MemoryPackOrder(3)]
        public int Num { get; set; }

        [MemoryPackOrder(4)]
        public List<AttributeEntryInfo> AttributeEntryInfos { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Id = default;
            this.ConfigId = default;
            this.Quality = default;
            this.Num = default;
            this.AttributeEntryInfos.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_NoticeUnitNumeric)]
    public partial class M2C_NoticeUnitNumeric : MessageObject, IMessage
    {
        public static M2C_NoticeUnitNumeric Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_NoticeUnitNumeric), isFromPool) as M2C_NoticeUnitNumeric;
        }

        [MemoryPackOrder(0)]
        public long UnitId { get; set; }

        [MemoryPackOrder(1)]
        public int NumericType { get; set; }

        [MemoryPackOrder(2)]
        public long NewValue { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.UnitId = default;
            this.NumericType = default;
            this.NewValue = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_AllItems)]
    public partial class M2C_AllItems : MessageObject, IMessage
    {
        public static M2C_AllItems Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_AllItems), isFromPool) as M2C_AllItems;
        }

        [MemoryPackOrder(0)]
        public int ItemContainerType { get; set; }

        [MemoryPackOrder(1)]
        public List<int> EquipPositions { get; set; } = new();

        [MemoryPackOrder(2)]
        public List<ItemInfo> ItemInfos { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.ItemContainerType = default;
            this.EquipPositions.Clear();
            this.ItemInfos.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_ItemUpdateOp)]
    public partial class M2C_ItemUpdateOp : MessageObject, IMessage
    {
        public static M2C_ItemUpdateOp Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_ItemUpdateOp), isFromPool) as M2C_ItemUpdateOp;
        }

        [MemoryPackOrder(0)]
        public ItemInfo ItemInfo { get; set; }

        [MemoryPackOrder(1)]
        public int ItemOpType { get; set; }

        [MemoryPackOrder(2)]
        public int ItemContainerType { get; set; }

        [MemoryPackOrder(3)]
        public int EquipPosition { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.ItemInfo = default;
            this.ItemOpType = default;
            this.ItemContainerType = default;
            this.EquipPosition = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_SpellSkill)]
    public partial class C2M_SpellSkill : MessageObject, ILocationMessage
    {
        public static C2M_SpellSkill Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_SpellSkill), isFromPool) as C2M_SpellSkill;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int SkillConfigId { get; set; }

        [MemoryPackOrder(2)]
        public long TargetUnitId { get; set; }

        [MemoryPackOrder(3)]
        public float Angle { get; set; }

        [MemoryPackOrder(4)]
        public float Distance { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.SkillConfigId = default;
            this.TargetUnitId = default;
            this.Angle = default;
            this.Distance = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_SpellSkill)]
    public partial class M2C_SpellSkill : MessageObject, IMessage
    {
        public static M2C_SpellSkill Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_SpellSkill), isFromPool) as M2C_SpellSkill;
        }

        [MemoryPackOrder(0)]
        public long UnitId { get; set; }

        [MemoryPackOrder(1)]
        public int SkillConfigId { get; set; }

        [MemoryPackOrder(2)]
        public long TargetUnitId { get; set; }

        [MemoryPackOrder(3)]
        public float Angle { get; set; }

        [MemoryPackOrder(4)]
        public Unity.Mathematics.float3 Position { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.UnitId = default;
            this.SkillConfigId = default;
            this.TargetUnitId = default;
            this.Angle = default;
            this.Position = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.SkillInfo)]
    public partial class SkillInfo : MessageObject
    {
        public static SkillInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(SkillInfo), isFromPool) as SkillInfo;
        }

        [MemoryPackOrder(0)]
        public long Id { get; set; }

        [MemoryPackOrder(1)]
        public int SkillConfigId { get; set; }

        [MemoryPackOrder(2)]
        public long SpellStartTime { get; set; }

        [MemoryPackOrder(3)]
        public long SpellEndTime { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Id = default;
            this.SkillConfigId = default;
            this.SpellStartTime = default;
            this.SpellEndTime = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_SkillUpdateOp)]
    public partial class M2C_SkillUpdateOp : MessageObject, IMessage
    {
        public static M2C_SkillUpdateOp Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_SkillUpdateOp), isFromPool) as M2C_SkillUpdateOp;
        }

        [MemoryPackOrder(0)]
        public long UnitId { get; set; }

        [MemoryPackOrder(1)]
        public int SkillOpType { get; set; }

        [MemoryPackOrder(2)]
        public SkillInfo SkillInfo { get; set; }

        [MemoryPackOrder(3)]
        public List<KeyValuePair_Int_Int> SkillGridDict { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.UnitId = default;
            this.SkillOpType = default;
            this.SkillInfo = default;
            this.SkillGridDict.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_HitResult)]
    public partial class M2C_HitResult : MessageObject, IMessage
    {
        public static M2C_HitResult Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_HitResult), isFromPool) as M2C_HitResult;
        }

        [MemoryPackOrder(0)]
        public long FromUnitId { get; set; }

        [MemoryPackOrder(1)]
        public long ToUnitId { get; set; }

        [MemoryPackOrder(2)]
        public int HitResultType { get; set; }

        [MemoryPackOrder(3)]
        public int Value { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.FromUnitId = default;
            this.ToUnitId = default;
            this.HitResultType = default;
            this.Value = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2M_Recharge)]
    [ResponseType(nameof(M2C_Recharge))]
    public partial class C2M_Recharge : MessageObject, ILocationRequest
    {
        public static C2M_Recharge Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_Recharge), isFromPool) as C2M_Recharge;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Num { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Num = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.M2C_Recharge)]
    public partial class M2C_Recharge : MessageObject, ILocationResponse
    {
        public static M2C_Recharge Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_Recharge), isFromPool) as M2C_Recharge;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.C2Chat_SendChat)]
    [ResponseType(nameof(Chat2C_SendChat))]
    public partial class C2Chat_SendChat : MessageObject, IChatRequest
    {
        public static C2Chat_SendChat Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2Chat_SendChat), isFromPool) as C2Chat_SendChat;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string ChatMessage { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ChatMessage = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.Chat2C_SendChat)]
    public partial class Chat2C_SendChat : MessageObject, IChatResponse
    {
        public static Chat2C_SendChat Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Chat2C_SendChat), isFromPool) as Chat2C_SendChat;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(OuterMessage.Chat2C_NoticeChat)]
    public partial class Chat2C_NoticeChat : MessageObject, IMessage
    {
        public static Chat2C_NoticeChat Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Chat2C_NoticeChat), isFromPool) as Chat2C_NoticeChat;
        }

        [MemoryPackOrder(0)]
        public string Name { get; set; }

        [MemoryPackOrder(1)]
        public string ChatMessage { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Name = default;
            this.ChatMessage = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    public static class OuterMessage
    {
        public const ushort HttpGetRouterResponse = 10002;
        public const ushort RouterSync = 10003;
        public const ushort KeyValuePair_Int_Int = 10004;
        public const ushort C2M_TestRequest = 10005;
        public const ushort M2C_TestResponse = 10006;
        public const ushort C2G_EnterMap = 10007;
        public const ushort G2C_EnterMap = 10008;
        public const ushort MoveInfo = 10009;
        public const ushort UnitInfo = 10010;
        public const ushort M2C_CreateUnits = 10011;
        public const ushort M2C_CreateMyUnit = 10012;
        public const ushort M2C_StartSceneChange = 10013;
        public const ushort M2C_RemoveUnits = 10014;
        public const ushort C2M_PathfindingResult = 10015;
        public const ushort C2M_Stop = 10016;
        public const ushort M2C_PathfindingResult = 10017;
        public const ushort M2C_Stop = 10018;
        public const ushort C2G_Ping = 10019;
        public const ushort G2C_Ping = 10020;
        public const ushort G2C_Test = 10021;
        public const ushort C2M_Reload = 10022;
        public const ushort M2C_Reload = 10023;
        public const ushort C2R_Login = 10024;
        public const ushort R2C_Login = 10025;
        public const ushort C2G_LoginGate = 10026;
        public const ushort G2C_LoginGate = 10027;
        public const ushort G2C_TestHotfixMessage = 10028;
        public const ushort C2M_TestRobotCase = 10029;
        public const ushort M2C_TestRobotCase = 10030;
        public const ushort C2M_TestRobotCase2 = 10031;
        public const ushort M2C_TestRobotCase2 = 10032;
        public const ushort C2M_TransferMap = 10033;
        public const ushort M2C_TransferMap = 10034;
        public const ushort C2G_Benchmark = 10035;
        public const ushort G2C_Benchmark = 10036;
        public const ushort C2A_LoginAccount = 10037;
        public const ushort A2C_LoginAccount = 10038;
        public const ushort A2C_Disconnect = 10039;
        public const ushort ServerInfo = 10040;
        public const ushort C2A_GetServers = 10041;
        public const ushort A2C_GetServers = 10042;
        public const ushort RoleInfo = 10043;
        public const ushort C2A_CreateRole = 10044;
        public const ushort A2C_CreateRole = 10045;
        public const ushort C2A_GetRoles = 10046;
        public const ushort A2C_GetRoles = 10047;
        public const ushort C2A_DeleteRole = 10048;
        public const ushort A2C_DeleteRole = 10049;
        public const ushort C2A_GetRealmKey = 10050;
        public const ushort A2C_GetRealmKey = 10051;
        public const ushort C2R_LoginRealm = 10052;
        public const ushort R2C_LoginRealm = 10053;
        public const ushort C2G_LoginGameGate = 10054;
        public const ushort G2C_LoginGameGate = 10055;
        public const ushort C2G_EnterGame = 10056;
        public const ushort G2C_EnterGame = 10057;
        public const ushort C2M_GM = 10058;
        public const ushort M2C_GM = 10059;
        public const ushort AttributeEntryInfo = 10060;
        public const ushort ItemInfo = 10061;
        public const ushort M2C_NoticeUnitNumeric = 10062;
        public const ushort M2C_AllItems = 10063;
        public const ushort M2C_ItemUpdateOp = 10064;
        public const ushort C2M_SpellSkill = 10065;
        public const ushort M2C_SpellSkill = 10066;
        public const ushort SkillInfo = 10067;
        public const ushort M2C_SkillUpdateOp = 10068;
        public const ushort M2C_HitResult = 10069;
        public const ushort C2M_Recharge = 10070;
        public const ushort M2C_Recharge = 10071;
        public const ushort C2Chat_SendChat = 10072;
        public const ushort Chat2C_SendChat = 10073;
        public const ushort Chat2C_NoticeChat = 10074;
    }
}