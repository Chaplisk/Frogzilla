using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityAtoms.BaseAtoms;

public class CinemachineShakeCustom : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _vc;

    private float _intensity;
    private float _shakeTimer;

    private void Update()
    {
        if(_shakeTimer > 0)
            _shakeTimer -= Time.deltaTime;

        CinemachineBasicMultiChannelPerlin noise = _vc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        noise.m_AmplitudeGain = _shakeTimer <= 0.0 ? 0.0f : _intensity;
    }

    public void ShakeCamera(FloatPair pair)
    {
        _intensity = pair.Item1;
        _shakeTimer = pair.Item2;
    }
}
