using Assets.Scripts.Utilities.Sounds;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestroyer : MonoBehaviour
{
    [SerializeField] private float _lifetime = 0.5f;

    [SerializeField] private AudioClip _destroySound;
    private ISoundManager _soundManager;

    private void Awake()
    {
        _soundManager = new SoundManager(GetComponent<AudioSource>(),SoundType.SFX);
    }

    private void Update()
    {
        _lifetime -= Time.deltaTime;
        if (_lifetime <= 0)
        {
            if (_destroySound != null )
                _soundManager.PlayOneShot(_destroySound, true);
            Destroy(gameObject);
        }
    }
}
