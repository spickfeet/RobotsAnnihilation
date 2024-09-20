using Assets.Scripts.Utilities.Sounds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class SoundSettingsMenu : MonoBehaviour
    {
        private SoundSettings _soundSettings = new();

        [SerializeField] private Slider _masterVolume;
        [SerializeField] private Slider _musicVolume;
        [SerializeField] private Slider _SFXVolume;

        private void Start()
        {
            if (PlayerPrefs.HasKey("MasterVolume"))
            {
                _masterVolume.value = _soundSettings.MasterVolume;
            }
            if (PlayerPrefs.HasKey("MusicVolume"))
            {
                _musicVolume.value = _soundSettings.MusicVolume;
            }
            if (PlayerPrefs.HasKey("SFXVolume"))
            {
                _SFXVolume.value = _soundSettings.SFXVolume;
            }
        }

        public void VolumeChanged(string volume)
        {
            switch (volume)
            {
                case "MasterVolume":
                    _soundSettings.MasterVolume = _masterVolume.value;
                    break;
                case "MusicVolume":
                    _soundSettings.MusicVolume = _musicVolume.value;
                    break;
                case "SFXVolume":
                    _soundSettings.SFXVolume = _SFXVolume.value;
                    break;
            }
        }
    }
}
