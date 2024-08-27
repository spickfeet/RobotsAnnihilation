using Assets.Scripts.Utilities.Sounds;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _guide;
    [SerializeField] private GameObject _settings;
    [SerializeField] private TextMeshProUGUI _classicModRecord;
    [SerializeField] private TextMeshProUGUI _infinityModRecord;

    [SerializeField] private AudioSource _audioSource;
    private ISoundManager _soundManager;

    private void Awake()
    {
        _soundManager = new SoundManager(_audioSource, SoundType.Music);
    }

    private void Start()
    {
        _classicModRecord.text = "Classic Mod Record: " + (PlayerPrefs.HasKey("ClassicModRecord") == true ? PlayerPrefs.GetInt("ClassicModRecord").ToString() : "");
        _infinityModRecord.text = "Infinity Mod Record: " + (PlayerPrefs.HasKey("InfinityModRecord") == true ? PlayerPrefs.GetInt("InfinityModRecord").ToString() : "");
    }

    private void FixedUpdate()
    {
        _soundManager.LoadVolume();
    }


    public void StartScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void GuidActive()
    {
        _guide.SetActive(true);
    }
    public void SettingsActive(bool status)
    {
        _settings.SetActive(status);
        if(status == false)
        {
            PlayerPrefs.Save();
        }
    }
}
