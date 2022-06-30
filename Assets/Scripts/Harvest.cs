using System;
using UnityEngine;


public class Harvest : MonoBehaviour
{
    private const int MaxContBlocks = 40;
    
    public static event Action TookTheGrass = delegate {  };

    [SerializeField] 
    private GameObject _blockContainer = null;
    [SerializeField] 
    private GameObject _grassBlock = null;

    public static int _countBlocks { get; private set; }

    private void OnEnable()
    {
        PlayerController.Sold += PlayerController_Sold;
    }

    private void OnDisable()
    {
        PlayerController.Sold -= PlayerController_Sold;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() && _countBlocks < MaxContBlocks)
        { 
            Destroy(gameObject);
            TookTheGrass();
            _countBlocks++;
        }
    }

    private void PlayerController_Sold()
    {
        _countBlocks = 0;
    }
}