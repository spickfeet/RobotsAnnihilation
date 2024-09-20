using UnityEngine;

namespace Assets.Scripts.Utilities.Sounds
{
    public class SoundManager : ISoundManager
    {
        private AudioSource _audioSource;
        private SoundType _soundType;
        private float _defaultVolume;

        private ISoundSettings _soundSettings = new SoundSettings();

        public SoundType SoundType
        {
            get { return _soundType; }
            set { _soundType = value; }
        }

        public float DefaultVolume
        {
            get { return _defaultVolume; }
            set
            {
                _defaultVolume = value;
                LoadVolume();
            }
        }

        public SoundManager(AudioSource audioSource, SoundType soundType)
        {
            _audioSource = audioSource;
            _soundType = soundType;
            _defaultVolume = _audioSource.volume;
            LoadVolume();
        }

        public void LoadVolume()
        {         
            if (_audioSource != null)
            {
                float masterVolume = _defaultVolume * (PlayerPrefs.HasKey("MasterVolume") == true ? _soundSettings.MasterVolume : 1);
                if (_soundType == SoundType.SFX)
                {
                    _audioSource.volume = (PlayerPrefs.HasKey("SFXVolume") == true ? _soundSettings.SFXVolume : 1) * masterVolume;
                }
                if (_soundType == SoundType.Music)
                {
                    _audioSource.volume = (PlayerPrefs.HasKey("MusicVolume") == true ? _soundSettings.MusicVolume : 0.5f) * masterVolume;
                }
            }
        }

        public void PlayOneShot(AudioClip audioClip, bool destroyed = false, float volume = -1)
        {
            if (audioClip != null)
            {
                if (destroyed == false)
                {
                    _audioSource.PlayOneShot(audioClip, volume < 0 ? _audioSource.volume : volume);
                    return;
                }
                AudioSource.PlayClipAtPoint(audioClip, _audioSource.transform.position, volume < 0 ? _audioSource.volume : volume);
            }
        }

        public void PlayLoop(AudioClip audioClip)
        {
            _audioSource.loop = true;
            _audioSource.resource = audioClip;
            _audioSource.Play();
        }
    }
}

