using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    private const int _amountToPool = 40;

    [SerializeField]
    private GameObject _objectToPool;
    [SerializeField]
    private GameObject _blockContainer = null;

    private List<GameObject> _poolObjects = new List<GameObject>();

    private void OnEnable()
    {
        PlayerController.Sold += PlayerController_Sold;
    }

    private void OnDisable()
    {
        PlayerController.Sold -= PlayerController_Sold;
    }

    private void Start()
    {
        GameObject tmp;

        for (int i = 0; i < _amountToPool; i++)
        {
            tmp = Instantiate(_objectToPool, Vector3.zero, Quaternion.identity, _blockContainer.transform);
            tmp.SetActive(false);
            _poolObjects.Add(tmp);
        }

    }

    public GameObject GetPooledObject(Vector3 position, Quaternion rotation)
    {
        for (int i = 0; i < _amountToPool; i++)
        {
            if (!_poolObjects[i].activeInHierarchy)
            {
                _poolObjects[i].transform.SetPositionAndRotation(position, rotation);

                return _poolObjects[i];
            }
        }
        return null;
    }

    private void PlayerController_Sold()
    {
        for (int i = 0; i < _amountToPool; i++)
        {
            if (_poolObjects[i].activeInHierarchy)
            {
                _poolObjects[i].gameObject.SetActive(false);
            }
        }
    }
}
