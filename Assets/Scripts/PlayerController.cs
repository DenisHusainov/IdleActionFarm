using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Joystick _joystick = null;
    [Header("Speed Player")] [Tooltip("Speed Player")] [SerializeField] [Range(1f, 7)]
    private float _speedWalk = default;
    [Header("Speed Player")][Tooltip("Speed Player")][SerializeField] [Range(8f, 15)]
    private float _speedRun = default;
    [Header("Camera sensitivity")][Tooltip("Camera sensitivity")][SerializeField] [Range(1f, 5)]
    private float _sensitivityCamera = default;
    
    private Rigidbody _rigidbody = null;
    public FloatingJoystick FloatingJoystick;
    private float _x =default;
    private float _z = default;
    private float mouseX = default;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _x = Joystick.Instance.Horizontal;
        _z = Joystick.Instance.Vertical;
        // mouseX = _vertical.Horizontal;
        transform.rotation *= new Quaternion(0,mouseX*Time.deltaTime*_sensitivityCamera,0,1);
    }
    
    private void FixedUpdate()
    {
        if(_x != 0 || _z != 0)
        {
            _rigidbody.AddRelativeForce(AplyNewVector(ref _x, ref _z, ref _speedWalk));
            // _animationController.SetSpeed_and_strafe(_z, _x);
            // _shakeCamera.SetShakeCamera(1.5f);
               
        }
        else
        {
            // _animationController.SetSpeed_and_strafe(0,0);
            // _shakeCamera.SetShakeCamera(0.75f);
        }
    }
    

    private Vector3 AplyNewVector(ref float x, ref float z, ref float speed)
    {
        return new Vector3(speed*Time.deltaTime*x*1000, 0, speed*Time.deltaTime*z*1000);
    }
}
