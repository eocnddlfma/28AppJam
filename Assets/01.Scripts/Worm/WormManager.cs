using System;
using SSH.Snake;
using UnityEngine;

public class WormManager : MonoBehaviour
{
    [SerializeField] private GameObject _currentHead;
    [SerializeField] private WormPart _currentTail;
    [SerializeField] private GameObject _tailObject;

    private void Start()
    {
        CreateTail();
    }

    public void CreateTail()
    {
        GameObject newTail = Instantiate(_tailObject);
        newTail.GetComponent<WormTail>().SetParent(_currentTail);
        _currentTail = newTail.GetComponent<WormPart>();
    }
    
    
}
