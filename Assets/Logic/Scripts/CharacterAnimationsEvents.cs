using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class CharacterAnimationsEvents : MonoBehaviour
{
    [SerializeField] private FloatPairEvent _shakeCamera;
    [SerializeField] private float _shakeIntensity;
    [SerializeField] private float _shakeDuration;

    public void Footstep()
    {
        FloatPair f = new FloatPair();
        f.Item1 = _shakeIntensity;
        f.Item2 = _shakeDuration;

        _shakeCamera.Raise(f);
    }
}
