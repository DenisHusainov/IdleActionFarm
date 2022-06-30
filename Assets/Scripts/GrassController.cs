using System;
using UnityEngine;

public class GrassController : MonoBehaviour
{
    [SerializeField] 
    private GameObject _grassBlock = null;
    [SerializeField]
    private GameObject _parentPrefab = null;
    [SerializeField] 
    private GameObject _blockContainer = null;

    private Animator _animator = null;
    
    //Need to change the name of the event
    public static event Action CutOff = delegate {  };

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _animator.SetTrigger("IsGrowing");
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            CutOff();
            _animator.SetTrigger("IsGrowing");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            _animator.SetTrigger("IsGrowing");
             Instantiate(_grassBlock, _parentPrefab.transform.position + Vector3.up,
                 _parentPrefab.transform.rotation);
        }
    }
}
