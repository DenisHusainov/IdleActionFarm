using System;
using UnityEngine;

public class Harvest : MonoBehaviour
{
    private const int MaxBlocks = 40;

    public static event Action TookTheGrass = delegate {  };

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() && GameWindow._countBlocks < MaxBlocks)
        { 
            Destroy(gameObject);
            TookTheGrass();
        }
    }
}