using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class AudioComponent : Entity, IAwake, IDestroy, IUpdate
    {
        public List<AudioSource> Sounds = new();
        public List<AudioSource> Musics = new();

        public float SoundVolume;
        public float MusicVolume;
    }
}