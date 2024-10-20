using System.Collections.Generic;
using System.Net;

namespace ET
{
    [EnableClass]
    public partial class StartSceneConfigCategory
    {
        public MultiMap<int, StartSceneConfig> Gates = new();

        public MultiMap<int, StartSceneConfig> ProcessScenes = new();

        public Dictionary<long, Dictionary<SceneType, StartSceneConfig>> ClientScenesByType = new();

        public Dictionary<long, Dictionary<string, StartSceneConfig>> OneScenesByName = new();

        public StartSceneConfig LocationConfig;

        public Dictionary<int, StartSceneConfig> Realms = new();

        public List<StartSceneConfig> Routers = new();

        public List<StartSceneConfig> Maps = new();

        public StartSceneConfig Account;

        public StartSceneConfig LoginCenter;

        public StartSceneConfig UnitCache;

        public StartSceneConfig Match;

        public StartSceneConfig Benchmark;

        public List<StartSceneConfig> GetByProcess(int process)
        {
            return this.ProcessScenes[process];
        }

        public StartSceneConfig GetOneBySceneType(int zone, SceneType type)
        {
            return this.ClientScenesByType[zone][type];
        }

        public StartSceneConfig GetBySceneName(int zone, string name)
        {
            return this.OneScenesByName[zone][name];
        }

        partial void PostInit()
        {
            foreach (StartSceneConfig startSceneConfig in this.DataList)
            {
                this.ProcessScenes.Add(startSceneConfig.Process, startSceneConfig);

                if (!this.OneScenesByName.ContainsKey(startSceneConfig.Zone))
                {
                    this.OneScenesByName.Add(startSceneConfig.Zone, new());
                }

                this.OneScenesByName[startSceneConfig.Zone].Add(startSceneConfig.Name, startSceneConfig);

                switch (startSceneConfig.Type)
                {
                    case SceneType.Realm:
                        this.Realms.Add(startSceneConfig.Zone, startSceneConfig);
                        break;
                    case SceneType.Gate:
                        this.Gates.Add(startSceneConfig.Zone, startSceneConfig);
                        break;
                    case SceneType.Location:
                        this.LocationConfig = startSceneConfig;
                        break;
                    case SceneType.Router:
                        this.Routers.Add(startSceneConfig);
                        break;
                    case SceneType.Map:
                        this.Maps.Add(startSceneConfig);
                        break;
                    case SceneType.Match:
                        this.Match = startSceneConfig;
                        break;
                    case SceneType.BenchmarkServer:
                        this.Benchmark = startSceneConfig;
                        break;
                    case SceneType.Account:
                        this.Account = startSceneConfig;
                        break;
                    case SceneType.LoginCenter:
                        this.LoginCenter = startSceneConfig;
                        break;
                    case SceneType.UnitCache:
                        if (!this.ClientScenesByType.ContainsKey(startSceneConfig.Zone))
                        {
                            this.ClientScenesByType.Add(startSceneConfig.Zone, new());
                        }

                        this.ClientScenesByType[startSceneConfig.Zone].Add(startSceneConfig.Type, startSceneConfig);
                        break;
                }
            }
        }
    }

    public partial class StartSceneConfig
    {
        public ActorId ActorId;

        public SceneType Type;

        public StartProcessConfig StartProcessConfig
        {
            get
            {
                return StartProcessConfigCategory.Instance.Get(this.Process);
            }
        }

        public StartZoneConfig StartZoneConfig
        {
            get
            {
                return StartZoneConfigCategory.Instance.Get(this.Zone);
            }
        }

        // 内网地址外网端口，通过防火墙映射端口过来
        private IPEndPoint innerIPPort;

        public IPEndPoint InnerIPPort
        {
            get
            {
                if (this.innerIPPort == null)
                {
                    this.innerIPPort = NetworkHelper.ToIPEndPoint($"{this.StartProcessConfig.InnerIP}:{this.Port}");
                }

                return this.innerIPPort;
            }
        }

        private IPEndPoint outerIPPort;

        // 外网地址外网端口
        public IPEndPoint OuterIPPort
        {
            get
            {
                if (this.outerIPPort == null)
                {
                    this.outerIPPort = NetworkHelper.ToIPEndPoint($"{this.StartProcessConfig.OuterIP}:{this.Port}");
                }

                return this.outerIPPort;
            }
        }

        partial void PostInit()
        {
            this.ActorId = new ActorId(this.Process, this.Id, 1);
            this.Type = EnumHelper.FromString<SceneType>(this.SceneType);
        }
    }
}