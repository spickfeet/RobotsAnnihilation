using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _guide;
    public void StartScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void GuidActive()
    {
        _guide.SetActive(true);
    }
}
