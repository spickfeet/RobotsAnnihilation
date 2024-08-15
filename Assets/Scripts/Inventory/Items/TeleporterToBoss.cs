using Assets.Scripts.Inventory.Items;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TeleporterToBoss : MonoBehaviour, IInteractable
{
    private Transform _teleportPos;
    private Transform _player;

    private Camera _camera;
    private CinemachineVirtualCamera _cinemachineVirtualCamera;
    private Vector3 _offset = new Vector3(0, 0, -10);

    private void Start()
    {
        _teleportPos = GameObject.FindWithTag("BossFightStartPos").transform;
        _player = FindAnyObjectByType<Player>().transform;
        _camera = FindAnyObjectByType<Camera>();
        _cinemachineVirtualCamera = FindAnyObjectByType<CinemachineVirtualCamera>();
    }

    public void Interact()
    {
        StartCoroutine(CinemachineVirtualCameraEnable());
        _camera.transform.position = _teleportPos.position + _offset;
        _player.position = _teleportPos.position;
    }

    private IEnumerator CinemachineVirtualCameraEnable()
    {
        _cinemachineVirtualCamera.enabled = false;
        yield return new WaitForSeconds(0.01f);
        _cinemachineVirtualCamera.enabled = true;

    }
}
