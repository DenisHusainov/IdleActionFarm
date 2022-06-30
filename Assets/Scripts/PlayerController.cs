using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static event Action Sold = delegate {  };
    
    [Header("Speed Player")] [Tooltip("Speed Player")] [SerializeField] [Range(8f, 15)]
    private float _speedRun = default;
    [SerializeField] 
    private GameObject _sickle = null;
    [SerializeField] 
    private GameObject _blockContainer = null;
    [SerializeField] 
    private GameObject _grassBlock = null;

    private Animation _runAnimation = null;

    private Rigidbody _rigidbody = null;
    private Animator _animator = null;
    private float _x =default;
    private float _z = default;
    private bool _isAnimationActive = default;


    private void OnEnable()
    {
        GrassController.CutOff+= CropCutiing_CutOff;
        Harvest.TookTheGrass += Harvest_TookTheGrass;
    }

    private void OnDisable()
    {
        GrassController.CutOff-= CropCutiing_CutOff;
    }
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
        _sickle.SetActive(false);
    }

    private void Update()
    {
        _x = Joystick.Instance.Horizontal;
        _z = Joystick.Instance.Vertical; 
    }
    
    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_x*_speedRun, _rigidbody.velocity.y, _z*_speedRun);
        
        if(_x != 0 || _z != 0 && !_isAnimationActive)
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
        StartCoroutine(Cut()); 
        _sickle.SetActive(false);
    }

    private IEnumerator Cut()
    {
        _sickle.SetActive(true);
        _isAnimationActive = true;
        _animator.SetTrigger("IsSlashed");
        yield return new WaitForSeconds(2.1f);
        _sickle.SetActive(false);
        _isAnimationActive = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Shop"))
        {
            Sold();
        }
    }
    
    private void Harvest_TookTheGrass()
    {
        Instantiate(_grassBlock, _blockContainer.transform.position, _blockContainer.transform.rotation,
            _blockContainer.transform);
    }
}
