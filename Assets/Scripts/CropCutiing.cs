using System;
using UnityEngine;

public class CropCutiing : MonoBehaviour
{
    private Animation _animation = null;
    
    //Need to change the name of the event
    public static event Action CutOff = delegate {  };

    private void Awake()
    {
        _animation = GetComponentInChildren<Animation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            CutOff();
        }
    }
}
