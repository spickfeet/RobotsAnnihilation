using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera _cinemachineCamera;
    private CinemachineTransposer _transposer;
    private CinemachineBasicMultiChannelPerlin _channelPerlin;

    private float _cameraSize;

    public CinemachineVirtualCamera CinemachineCamera
    {
        get { return _cinemachineCamera; }
        set { _cinemachineCamera = value; }
    }

    public CinemachineTransposer Transposer
    {
        get { return _transposer; }
        set { _transposer = value; }
    }

    public CinemachineBasicMultiChannelPerlin ChannelPerlin
    {
        get { return _channelPerlin; }
        set { _channelPerlin = value; }
    }

    private void Awake()
    {
        CinemachineCamera = GetComponent<CinemachineVirtualCamera>();
        Transposer = CinemachineCamera.GetCinemachineComponent<CinemachineTransposer>();
        ChannelPerlin = CinemachineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    public void ChangeFollow(Transform follower)
    {
        if (follower != null) CinemachineCamera.Follow = follower;
    }
    public void Shake(float amplitude, float frequency, float time, float fadeTimeAmplitude, float fadeTimeFrequency)
    {
        StopCoroutine(ShakeCamera(amplitude, frequency, time, fadeTimeAmplitude, fadeTimeFrequency));
        StartCoroutine(ShakeCamera(amplitude, frequency, time, fadeTimeAmplitude, fadeTimeFrequency));
    }

    public IEnumerator ChangeSize(float newSize)
    {
        if (_cinemachineCamera.m_Lens.OrthographicSize == newSize) yield break;
        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            _cinemachineCamera.m_Lens.OrthographicSize = Mathf.Lerp(_cameraSize, newSize, EasyInOut(i));
        }
    }

    private IEnumerator ShakeCamera(float amplitude, float frequency, float time, float fadeTimeAmplitude, float fadeTimeFrequency)
    {
        ChannelPerlin.m_AmplitudeGain = amplitude;
        ChannelPerlin.m_FrequencyGain = frequency;
        yield return new WaitForSeconds(time);

        for (float i = 0, j = 0; i < fadeTimeAmplitude && j < fadeTimeFrequency; i += Time.deltaTime, j += Time.deltaTime)
        {
            if (i < fadeTimeAmplitude)
            {
                ChannelPerlin.m_AmplitudeGain -= Time.deltaTime * amplitude / fadeTimeAmplitude;
            }
            if (j < fadeTimeFrequency)
            {
                ChannelPerlin.m_FrequencyGain -= Time.deltaTime * amplitude / fadeTimeFrequency;
            }
        }
        ChannelPerlin.m_AmplitudeGain = 0;
        ChannelPerlin.m_FrequencyGain = 0;
    }
    private float EasyInOut(float x)
    {
        return x < 0.5 ? x * x * 2 : (1 - (1 - x) * (1 - x) * 2);
    }

}
