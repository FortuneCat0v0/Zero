using System;

namespace ET
{
    public enum ConfigFolder
    {
        Localhost,
        Release,
        RouterTest,
        Benchmark
    }

    public static class ToolsEditor
    {
        public static void ExcelExporter()
        {
            // #if UNITY_EDITOR_OSX || UNITY_EDITOR_LINUX
            //             const string tools = "./Tool";
            // #else
            //             const string tools = ".\\Tool.exe";
            // #endif
            //             ShellHelper.Run($"{tools} --AppType=ExcelExporter --Console=1", "../Bin/");

#if UNITY_EDITOR_OSX || UNITY_EDITOR_LINUX
            foreach (ConfigFolder configFolder in Enum.GetValues(typeof(ConfigFolder)))
            {
                ShellHelper.Run($"gen_code_client.bat {configFolder}", "../Tools/Luban/");
                ShellHelper.Run($"gen_code_server.bat {configFolder}", "../Tools/Luban/");
                ShellHelper.Run($"gen_code_client_server.bat {configFolder}", "../Tools/Luban/");
            }
#else
            foreach (ConfigFolder configFolder in Enum.GetValues(typeof(ConfigFolder)))
            {
                ShellHelper.Run($"gen_code_client.bat {configFolder}", "../Tools/Luban/");
                ShellHelper.Run($"gen_code_server.bat {configFolder}", "../Tools/Luban/");
                ShellHelper.Run($"gen_code_client_server.bat {configFolder}", "../Tools/Luban/");
            }
#endif
        }

        public static void Proto2CS()
        {
#if UNITY_EDITOR_OSX || UNITY_EDITOR_LINUX
            const string tools = "./Tool";
#else
            const string tools = ".\\Tool.exe";
#endif
            ShellHelper.Run($"{tools} --AppType=Proto2CS --Console=1", "../Bin/");
        }
    }
}