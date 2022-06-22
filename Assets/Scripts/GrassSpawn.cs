using UnityEngine;

public class GrassSpawn : MonoBehaviour
{
    private const float _startPosX = -3.9f;
    private const float _startPosZ = 30f;
    private const float _startPosY = 0.9f;
    private const float _stepX = 1f;
    private const float _stepZ = 2f;
    
    [SerializeField] 
    private GameObject _grassPrefab = null;
    [SerializeField] 
    private GameObject _parentObject = null;
    
    
    void Start()
    {
        for (var i = 0; i < 4; i++)
        {
            Instantiate(_grassPrefab, new Vector3(_startPosX + i * _stepX, _startPosY, _startPosZ),
                Quaternion.identity, _parentObject.transform);
            Instantiate(_grassPrefab, new Vector3(_startPosX + i * _stepX, _startPosY, _startPosZ - _stepZ),
                Quaternion.identity, _parentObject.transform);
        }
    }
}
