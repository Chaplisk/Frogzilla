using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Custom_CharacterController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private GameObject _model;
    [SerializeField] private Animator _animator;

    private float _horizontalAxis;
    private Vector3 _modelBaseScale;

    private void Awake()
    {
        _modelBaseScale = _model.transform.localScale;
    }

    public void HorizontalMovement(InputAction.CallbackContext context)
    {
        float v = context.ReadValue<float>();
        _horizontalAxis = v;

        _animator.SetBool("moving", v != 0.0f);

        if(v != 0.0f)
        {
            if(v > 0.0f)
            {

                _model.transform.localScale = new Vector3(-_modelBaseScale.x, _modelBaseScale.y, _modelBaseScale.z);
            }
            else
            {

                _model.transform.localScale = new Vector3(_modelBaseScale.x, _modelBaseScale.y, _modelBaseScale.z);
            }

        }
    }

    private void Update()
    {
        _rigidBody.velocity = new Vector2(_horizontalAxis * _moveSpeed, _rigidBody.velocity.y);
    }
}
