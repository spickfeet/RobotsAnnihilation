using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utilities.Sounds
{
    public class GlobalMusicController : MonoBehaviour
    {
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioClip[] _musicClips;

        private ISoundManager _soundManager;

        private void Awake()
        {
            _soundManager = new SoundManager(_musicSource, SoundType.Music);
        }

        public void ChangeMusic(Music music)
        {
            _soundManager.PlayLoop(_musicClips[(int)music]);
        }

        public void ChangeDefaultVolume(float baseVolume)
        {
            _soundManager.DefaultVolume = baseVolume;
        }      
    }
}
