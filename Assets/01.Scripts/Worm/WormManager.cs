using System;
using SSH.Snake;
using UnityEngine;
using UnityEngine.InputSystem;

public class WormManager : MonoBehaviour
{
    [SerializeField] private GameObject _currentHead;
    [SerializeField] private WormPart _currentTail;
    [SerializeField] private GameObject _tailObject;

    private void Start()
    {
        CreateTail();
    }

    private void Update()
    {
    }

    public void CreateTail(Sprite sprite = null)
    {
        GameObject newTail = Instantiate(_tailObject, _currentTail.transform.position, Quaternion.identity);
        newTail.GetComponent<WormTail>().SetParent(_currentTail);
        newTail.GetComponent<SpriteRenderer>().sprite = sprite;
        _currentTail = newTail.GetComponent<WormPart>();
    }
    
    
}
