using Assets.Scripts.Utilities.Sounds;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightStarter : MonoBehaviour
{
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private GameObject _boss;
    [SerializeField] private GameObject _healthBar;

    [SerializeField] GlobalMusicController _musicController;

    private Transform _player;

    private bool _canStart = true;

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            if (_canStart)
            {
                _musicController.ChangeDefaultVolume(0.5f);
                _musicController.ChangeMusic(Music.BossFightMusic);

                _boss.SetActive(true);
                _healthBar.SetActive(true);
                _player = player.transform;
                StartCoroutine(ShowBoss());
                _canStart = false;
            }
        }
    }

    private IEnumerator ShowBoss()
    {
        yield return new WaitForSeconds(0.11f);
        _cameraController.ChangeFollow(_boss.transform);
        yield return new WaitForSeconds(1);
        _cameraController.ChangeFollow(_player);
        Destroy(gameObject);
    }

}
