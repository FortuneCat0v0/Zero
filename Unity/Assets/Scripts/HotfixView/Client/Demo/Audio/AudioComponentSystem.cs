using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class PlaySound_PlayView : AEvent<Scene, PlaySound>
    {
        protected override async ETTask Run(Scene scene, PlaySound args)
        {
            scene.GetComponent<AudioComponent>().PlaySound(AudioConfigCategory.Instance.Get(args.AudioConfigId).AssetName);
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(AudioComponent))]
    [EntitySystemOf(typeof(AudioComponent))]
    public static partial class AudioComponentSystem
    {
        [EntitySystem]
        private static void Awake(this AudioComponent self)
        {
            self.InitVolume();
        }

        [EntitySystem]
        private static void Destroy(this AudioComponent self)
        {
            self.RemoveAllAudio();
        }

        [EntitySystem]
        private static void Update(this AudioComponent self)
        {
            for (int i = self.Sounds.Count - 1; i > -1; i--)
            {
                AudioSource audioSource = self.Sounds[i];
                if (audioSource.isPlaying == false)
                {
                    audioSource.Stop();
                    audioSource.clip = null;
                    audioSource.loop = false;
                    GameObjectPoolHelper.ReturnObjectToPool(audioSource.gameObject);

                    self.Sounds.RemoveAt(i);
                }
            }

            for (int i = self.Musics.Count - 1; i > -1; i--)
            {
                AudioSource audioSource = self.Musics[i];
                if (audioSource.isPlaying == false)
                {
                    audioSource.Stop();
                    audioSource.clip = null;
                    audioSource.loop = false;
                    GameObjectPoolHelper.ReturnObjectToPool(audioSource.gameObject);

                    self.Musics.RemoveAt(i);
                }
            }
        }

        public static void RemoveAllAudio(this AudioComponent self)
        {
            foreach (AudioSource audioSource in self.Sounds)
            {
                audioSource.Stop();
                audioSource.clip = null;
                audioSource.loop = false;
                GameObjectPoolHelper.ReturnObjectToPool(audioSource.gameObject);
            }

            self.Sounds.Clear();

            foreach (AudioSource audioSource in self.Musics)
            {
                audioSource.Stop();
                audioSource.clip = null;
                audioSource.loop = false;
                GameObjectPoolHelper.ReturnObjectToPool(audioSource.gameObject);
            }

            self.Musics.Clear();
        }

        private static void InitVolume(this AudioComponent self)
        {
            float sound = PlayerPrefsHelper.GetFloat(PlayerPrefsHelper.SoundVolume, 1f);
            float music = PlayerPrefsHelper.GetFloat(PlayerPrefsHelper.MusicVolume, 1f);
            self.SoundVolume = sound;
            self.MusicVolume = music;
        }

        /// <summary>
        /// 播放音效，如：击打音效
        /// </summary>
        /// <param name="self"></param>
        /// <param name="name"></param>
        /// <param name="volume"></param>
        public static void PlaySound(this AudioComponent self, string name, float volume = 1f)
        {
            AudioSource audioSource = self.GetAudioSource();
            AudioClip audioClip = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<AudioClip>(AssetPathHelper.GetSoundPath(name));
            audioSource.clip = audioClip;
            audioSource.loop = false;
            audioSource.volume = volume * self.SoundVolume;
            audioSource.Play();

            self.Sounds.Add(audioSource);
        }

        /// <summary>
        /// 播放背景音乐
        /// </summary>
        /// <param name="self"></param>
        /// <param name="name"></param>
        /// <param name="volume"></param>
        public static void PlayMusic(this AudioComponent self, string name, float volume = 1f)
        {
            AudioSource audioSource = self.GetAudioSource();
            AudioClip audioClip = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<AudioClip>(AssetPathHelper.GetMusicPath(name));
            audioSource.clip = audioClip;
            audioSource.loop = true;
            audioSource.volume = volume * self.MusicVolume;
            audioSource.Play();

            self.Musics.Add(audioSource);
        }

        public static void ChangeSoundVolume(this AudioComponent self, float volume)
        {
            self.SoundVolume = volume;

            foreach (AudioSource audioSource in self.Sounds)
            {
                audioSource.volume = volume;
            }
        }

        public static void ChangeMusicsVolume(this AudioComponent self, float volume)
        {
            self.SoundVolume = volume;

            foreach (AudioSource audioSource in self.Musics)
            {
                audioSource.volume = volume;
            }
        }

        private static AudioSource GetAudioSource(this AudioComponent self)
        {
            GameObject go = GameObjectPoolHelper.GetObjectFromPool(self.Scene(), AssetPathHelper.GetAudioPlayerPath());
            go.transform.SetParent(self.Root().GetComponent<GlobalComponent>().Audio);
            return go.GetComponent<AudioSource>();
        }
    }
}