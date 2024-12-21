using System;
using SSH.Snake;
using UnityEngine;
using UnityEngine.InputSystem;

public class WormManager : MonoBehaviour
{
    public static WormManager Instance { get; private set; } // 싱글톤 인스턴스
    [SerializeField] private GameObject _currentHead;
    [SerializeField] private WormPart _currentTail;
    [SerializeField] private GameObject _tailObject;
    [SerializeField] private Sprite _startTailSprite;

    private void Awake()
    {
        // 싱글톤 인스턴스 설정
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning($"Duplicate WormManager instance detected! Destroying {gameObject.name}.");
            Destroy(gameObject); // 중복된 인스턴스 삭제
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // 씬 전환 시 삭제되지 않도록 설정
    }

    private void Start()
    {
        CreateTail(Vector3.zero, _startTailSprite);
        CreateTail(Vector3.zero, _startTailSprite);
        CreateTail(Vector3.zero, _startTailSprite);
        CreateTail(Vector3.zero, _startTailSprite);
    }

    private void Update()
    {
        
    }

    public void CreateTail(Vector3 pos, Sprite sprite = null)
    {
        GameObject newTail = Instantiate(_tailObject, pos, Quaternion.identity);
        newTail.GetComponent<WormTail>().SetParent(_currentTail);
        newTail.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
        _currentTail = newTail.GetComponent<WormPart>();
    }
}