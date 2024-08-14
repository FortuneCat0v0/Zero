using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class MaskWordComponent : Entity, IAwake
    {
        public string MaskWord;
        public string[] sensitiveWordsArray = null;
        public Dictionary<char, List<string>> keyDict = new();

        [StaticField]
        public static MaskWordComponent Instance;
    }
}