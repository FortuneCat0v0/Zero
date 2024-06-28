namespace ET.Client.Audio
{
    [FriendOf(typeof(AudioComponent))]
    [EntitySystemOf(typeof(AudioComponent))]
    public static partial class AudioComponentSystem
    {
        [EntitySystem]
        private static void Awake(this AudioComponent self)
        {
        }

        /// <summary>
        /// 播放人声，如：对话
        /// </summary>
        /// <param name="self"></param>
        /// <param name="name"></param>
        public static void PlayVoice(this AudioComponent self, string name)
        {
            // loop 为 false
        }

        /// <summary>
        /// 播放音效，如：击打音效
        /// </summary>
        /// <param name="self"></param>
        /// <param name="name"></param>
        public static void PlaySound(this AudioComponent self, string name)
        {
            // loop 为 false
        }

        /// <summary>
        /// 播放背景音乐
        /// </summary>
        /// <param name="self"></param>
        /// <param name="name"></param>
        public static void PlayMusic(this AudioComponent self, string name)
        {
            // loop 为 true
        }
    }
}