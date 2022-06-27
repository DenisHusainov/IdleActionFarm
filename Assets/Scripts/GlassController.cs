using System;
using UnityEngine;

public class GlassController : MonoBehaviour
{
    [SerializeField] 
    private GameObject _grassBlock = null;

    private Animator _animator = null;
    
    //Need to change the name of the event
    public static event Action CutOff = delegate {  };

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _animator.SetBool("IsGrowing", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.gameObject.GetComponent<PlayerController>())
        {
            Instantiate(_grassBlock, transform.position, transform.rotation);
            CutOff();
            _animator.SetBool("IsGrowing", true);
        }
    }
}
