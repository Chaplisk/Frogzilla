using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityAtoms.BaseAtoms;

public class Custom_CharacterController : MonoBehaviour
{
    public bool canMove;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private GameObject _model;
    [SerializeField] private Animator _animator;
    [SerializeField] private List<ParticleSystem> _waterJet = new List<ParticleSystem>();
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpCooldown;
    [SerializeField] private Transform _groundedEmpty;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private float _groundDistance;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private FloatPairEvent _shakeCamera;
    [SerializeField] private float _shakeMinimumNotGroundedDelay;
    [SerializeField] private float _atterrissageShakeIntensity;
    [SerializeField] private float _atterrissageShakeDuration;
    [SerializeField] private AudioSource _waterJetSound;
    [SerializeField] private float _waterJetSoundLerpSpeed;

    private float _horizontalAxis;
    private Vector3 _modelBaseScale;
    private bool _isFiring;
    private float _jumpTimer;
    private float _timerSinceNotGrounded;
    private float _waterJetSoundBaseVolume;
    private float _waterJetSoundTargetVolume;

    private void Awake()
    {
        _modelBaseScale = _model.transform.localScale;

        _waterJetSoundBaseVolume = _waterJetSound.volume;
        _waterJetSound.volume = 0.0f;
    }

    public void StartPlayer()
    {
        _rigidBody.simulated = true;
        canMove = true;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (canMove == false)
            return;

        if (_jumpTimer < _jumpCooldown)
            return;

        if (_isGrounded == false)
            return;

        if(context.performed)
        {
            _jumpTimer = 0.0f;
            _rigidBody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            print("jump");
        }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed)
            _isFiring = true;
        else
            _isFiring = false;
    }

    public void HorizontalMovement(InputAction.CallbackContext context)
    {
        if (canMove == false)
            return;

        float v = context.ReadValue<float>();
        _horizontalAxis = v;

        _animator.SetBool("moving", v != 0.0f);

        if(v != 0.0f)
        {
            if(v > 0.0f)
            {

                _model.transform.localScale = new Vector3(_modelBaseScale.x, _modelBaseScale.y, _modelBaseScale.z);
            }
            else
            {

                _model.transform.localScale = new Vector3(-_modelBaseScale.x, _modelBaseScale.y, _modelBaseScale.z);
            }

        }
    }

    private void Update()
    {
        _jumpTimer += Time.deltaTime;

        if(_isGrounded == false)
        {
            _timerSinceNotGrounded += Time.deltaTime;
        }
        else
        {
            _timerSinceNotGrounded = 0.0f;
        }

        _rigidBody.velocity = new Vector2(_horizontalAxis * _moveSpeed, _rigidBody.velocity.y);

        foreach(ParticleSystem ps in _waterJet)
        {
            ParticleSystem.EmissionModule em = ps.emission;
            em.enabled = _isFiring;
        }

        if(_isGrounded == false && CheckGround())
        {
            if(_timerSinceNotGrounded >= _shakeMinimumNotGroundedDelay)
            {
                FloatPair f = new FloatPair();
                f.Item1 = _atterrissageShakeIntensity;
                f.Item2 = _atterrissageShakeDuration;

                _shakeCamera.Raise(f);
            }
        }

        _isGrounded = CheckGround();
        _animator.SetBool("inAir", !_isGrounded);

        _waterJetSoundTargetVolume = _isFiring ? _waterJetSoundBaseVolume : 0.0f;
        _waterJetSound.volume = Mathf.Lerp(_waterJetSound.volume, _waterJetSoundTargetVolume, Time.deltaTime * _waterJetSoundLerpSpeed);

    }

    private bool CheckGround()
    {
        if (Physics2D.Raycast(_groundedEmpty.position, -Vector2.up, _groundDistance, _layerMask, 0f, 0f))
        {
            return true;
        }

        return false;
    }
}
