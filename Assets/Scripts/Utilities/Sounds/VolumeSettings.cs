using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utilities.Sounds
{
    public class SoundSettings : ISoundSettings
    {
        public float MasterVolume
        {
            get { return PlayerPrefs.GetFloat("MasterVolume"); }
            set { PlayerPrefs.SetFloat("MasterVolume", value); }
        }
        public float MusicVolume
        {
            get { return PlayerPrefs.GetFloat("MusicVolume"); }
            set { PlayerPrefs.SetFloat("MusicVolume", value); }
        }
        public float SFXVolume
        {
            get { return PlayerPrefs.GetFloat("SFXVolume"); }
            set { PlayerPrefs.SetFloat("SFXVolume", value); }
        }
    }
}
