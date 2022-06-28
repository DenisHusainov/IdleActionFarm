using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Speed Player")] [Tooltip("Speed Player")] [SerializeField] [Range(8f, 15)]
    private float _speedRun = default;
    
    private Rigidbody _rigidbody = null;
    private Animator _animator = null;
    private float _x =default;
    private float _z = default;

    private void OnEnable()
    {
        GlassController.CutOff+= CropCutiing_CutOff;
    }
    
    private void OnDisable()
    {
        GlassController.CutOff-= CropCutiing_CutOff;
    }
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        _x = Joystick.Instance.Horizontal;
        _z = Joystick.Instance.Vertical; 
    }
    
    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_x*_speedRun, _rigidbody.velocity.y, _z*_speedRun);
        
        if(_x != 0 || _z != 0)
        {
             _animator.SetBool("IsRun", true);
             transform.rotation = Quaternion.LookRotation( _rigidbody.velocity);
        }
        else
        {
             _animator.SetBool("IsRun", false);
        }
    }

    private void CropCutiing_CutOff()
    {
       _animator.SetTrigger("IsSlashed");
    }
}
