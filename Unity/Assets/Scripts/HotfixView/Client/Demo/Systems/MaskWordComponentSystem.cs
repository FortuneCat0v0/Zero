using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(MaskWordComponent))]
    [EntitySystemOf(typeof(MaskWordComponent))]
    public static partial class MaskWordComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MaskWordComponent self)
        {
            MaskWordComponent.Instance = self;
            self.InitMaskWord().Coroutine();
        }

        private static async ETTask InitMaskWord(this MaskWordComponent self)
        {
            self.keyDict.Clear();
            await self.InitMaskWordText("MaskWord", "、");
            await self.InitMaskWordText("MaskWord2", "、\r\n");
            await self.InitMaskWordText("MaskWord3", "、");
        }

        private static async ETTask InitMaskWordText(this MaskWordComponent self, string maskword, string split)
        {
            var path_1 = AssetPathHelper.GetTextPath(maskword);
            TextAsset textAsset3 = await self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<TextAsset>(path_1);
            self.MaskWord = textAsset3.text;
            self.sensitiveWordsArray = Regex.Split(self.MaskWord, split, RegexOptions.IgnoreCase);

            foreach (string s in self.sensitiveWordsArray)
            {
                if (string.IsNullOrEmpty(s))
                    continue;
                if (self.keyDict.ContainsKey(s[0]))
                    self.keyDict[s[0]].Add(s.Trim(new char[] { '\r' }));
                else
                    self.keyDict.Add(s[0], new List<string> { s.Trim(new char[] { '\r' }) });
            }
        }

        //判断一个字符串是否包含敏感词，包括含的话将其替换为*
        public static bool IsContainSensitiveWords(this MaskWordComponent self, string text)
        {
            bool isFind = false;
            if (null == self.sensitiveWordsArray || string.IsNullOrEmpty(text))
                return isFind;

            int len = text.Length;
            bool isOK = true;
            for (int i = 0; i < len; i++)
            {
                if (!self.keyDict.ContainsKey(text[i]))
                {
                    continue;
                }

                foreach (string s in self.keyDict[text[i]])
                {
                    isOK = true;
                    int j = i;
                    foreach (char c in s)
                    {
                        if (j >= len || c != text[j++])
                        {
                            isOK = false;
                            break;
                        }
                    }

                    if (isOK)
                    {
                        isFind = true;
                        i += s.Length - 1;
                        break;
                    }
                }

                if (isFind)
                {
                    break;
                }
            }

            return isFind;
        }

        //判断一个字符串是否包含敏感词，包括含的话将其替换为*
        public static bool IsContainSensitiveWords(this MaskWordComponent self, ref string text, out string SensitiveWords)
        {
            bool isFind = false;
            SensitiveWords = "";
            if (null == self.sensitiveWordsArray || string.IsNullOrEmpty(text))
                return isFind;

            int len = text.Length;
            StringBuilder sb = new StringBuilder(len);
            bool isOK = true;
            for (int i = 0; i < len; i++)
            {
                if (self.keyDict.ContainsKey(text[i]))
                {
                    foreach (string s in self.keyDict[text[i]])
                    {
                        isOK = true;
                        int j = i;
                        foreach (char c in s)
                        {
                            if (j >= len || c != text[j++])
                            {
                                isOK = false;
                                break;
                            }
                        }

                        if (isOK)
                        {
                            SensitiveWords += s;
                            isFind = true;
                            i += s.Length - 1;
                            sb.Append('*', s.Length);
                            break;
                        }
                    }

                    if (!isOK)
                        sb.Append(text[i]);
                }
                else
                    sb.Append(text[i]);
            }

            if (isFind)
                text = sb.ToString();

            return isFind;
        }
    }
}