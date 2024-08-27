using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utilities.Sounds
{
    public interface ISoundManager
    {
        SoundType SoundType { get; set; }
        float DefaultVolume { get; set; }
        void LoadVolume();
        void PlayOneShot(AudioClip audioClip, bool destroyed = false, float volume = -1);
        void PlayLoop(AudioClip audioClip);
    }
}
