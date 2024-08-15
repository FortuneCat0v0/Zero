using System;
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
            string path = AssetPathHelper.GetTextPath(maskword);
            TextAsset textAsset = await self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<TextAsset>(path);
            self.MaskWord = textAsset.text;
            self.sensitiveWordsArray = Regex.Split(self.MaskWord, split, RegexOptions.IgnoreCase);

            foreach (string word in self.sensitiveWordsArray)
            {
                if (string.IsNullOrWhiteSpace(word)) continue;

                char key = word[0];
                string trimmedWord = word.Trim('\r');

                if (!self.keyDict.ContainsKey(key))
                {
                    self.keyDict[key] = new List<string>();
                }

                self.keyDict[key].Add(trimmedWord);
            }
        }

        public static bool IsContainSensitiveWords(this MaskWordComponent self, ref string text, out string sensitiveWords)
        {
            sensitiveWords = string.Empty;
            if (self.sensitiveWordsArray == null || string.IsNullOrEmpty(text))
                return false;

            StringBuilder sb = new StringBuilder(text.Length);
            bool found = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (self.keyDict.TryGetValue(text[i], out var wordList))
                {
                    bool matched = false;
                    foreach (string word in wordList)
                    {
                        if (text.AsSpan(i).StartsWith(word))
                        {
                            sb.Append('*', word.Length);
                            sensitiveWords += word;
                            i += word.Length - 1;
                            matched = true;
                            found = true;
                            break;
                        }
                    }

                    if (!matched)
                        sb.Append(text[i]);
                }
                else
                {
                    sb.Append(text[i]);
                }
            }

            if (found)
                text = sb.ToString();

            return found;
        }
    }
}