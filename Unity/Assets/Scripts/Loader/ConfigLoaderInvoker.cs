using System;
using System.Collections.Generic;
using System.IO;
using Luban;
using UnityEngine;
using YooAsset;

namespace ET
{
    [Invoke]
    public class GetAllConfigBytes : AInvokeHandler<ConfigLoader.GetAllConfigBytes, ETTask<Dictionary<Type, ByteBuf>>>
    {
        public override async ETTask<Dictionary<Type, ByteBuf>> Handle(ConfigLoader.GetAllConfigBytes args)
        {
            GlobalConfig globalConfig = Resources.Load<GlobalConfig>("GlobalConfig");
            EPlayMode playMode = globalConfig.EPlayMode;
            Dictionary<Type, ByteBuf> output = new Dictionary<Type, ByteBuf>();
            HashSet<Type> configTypes = CodeTypes.Instance.GetTypes(typeof(ConfigAttribute));

            if (Define.IsEditor && playMode == EPlayMode.EditorSimulateMode)
            {
                string ct = "cs";
                // GlobalConfig globalConfig = Resources.Load<GlobalConfig>("GlobalConfig");
                CodeMode codeMode = globalConfig.CodeMode;
                switch (codeMode)
                {
                    case CodeMode.Client:
                        ct = "c";
                        break;
                    case CodeMode.Server:
                        ct = "s";
                        break;
                    case CodeMode.ClientServer:
                        ct = "cs";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                List<string> startConfigs = new List<string>()
                {
                    "StartMachineConfigCategory",
                    "StartProcessConfigCategory",
                    "StartSceneConfigCategory",
                    "StartZoneConfigCategory",
                };
                foreach (Type configType in configTypes)
                {
                    string configFilePath;
                    if (startConfigs.Contains(configType.Name))
                    {
                        configFilePath = $"../Config/Excel/{ct}/{Options.Instance.StartConfig}/{configType.Name.ToLower()}.bytes";
                    }
                    else
                    {
                        configFilePath = $"../Config/Excel/{ct}/{configType.Name.ToLower()}.bytes";
                    }

                    output[configType] = new ByteBuf(File.ReadAllBytes(configFilePath));
                }
            }
            else
            {
                foreach (Type type in configTypes)
                {
                    TextAsset v = await ResourcesComponent.Instance.LoadAssetAsync<TextAsset>(
                        $"Assets/Bundles/Config/{type.Name.ToLower()}.bytes");
                    output[type] = new ByteBuf(v.bytes);
                }
            }

            return output;
        }
    }

    [Invoke]
    public class GetOneConfigBytes : AInvokeHandler<ConfigLoader.GetOneConfigBytes, ETTask<ByteBuf>>
    {
        public override async ETTask<ByteBuf> Handle(ConfigLoader.GetOneConfigBytes args)
        {
            string ct = "cs";
            GlobalConfig globalConfig = Resources.Load<GlobalConfig>("GlobalConfig");
            CodeMode codeMode = globalConfig.CodeMode;
            switch (codeMode)
            {
                case CodeMode.Client:
                    ct = "c";
                    break;
                case CodeMode.Server:
                    ct = "s";
                    break;
                case CodeMode.ClientServer:
                    ct = "cs";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            List<string> startConfigs = new List<string>()
            {
                "StartMachineConfigCategory",
                "StartProcessConfigCategory",
                "StartSceneConfigCategory",
                "StartZoneConfigCategory",
            };

            string configName = args.ConfigName.ToLower();

            string configFilePath;
            if (startConfigs.Contains(configName))
            {
                configFilePath = $"../Config/Excel/{ct}/{Options.Instance.StartConfig}/{configName}.bytes";
            }
            else
            {
                configFilePath = $"../Config/Excel/{ct}/{configName}.bytes";
            }

            await ETTask.CompletedTask;
            return new ByteBuf(File.ReadAllBytes(configFilePath));
        }
    }
}