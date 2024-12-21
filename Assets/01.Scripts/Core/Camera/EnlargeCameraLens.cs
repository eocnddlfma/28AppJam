using System;
using Unity.Cinemachine;
using UnityEngine;

public class EnlargeCameraLens : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private CinemachineCamera _camera;

    private void Start()
    {
        _camera = GetComponent<CinemachineCamera>();
    }

    [SerializeField ]private float maxValue = 8f;
    void Update()
    {
        print(Mathf.Abs(_target.position.x - transform.position.x));
        print(Mathf.Abs(_target.position.y - transform.position.y));
        maxValue = Mathf.Max(Mathf.Abs(_target.position.x - transform.position.x), Mathf.Abs(_target.position.y- transform.position.y), maxValue);
        _camera.Lens.OrthographicSize = maxValue;
    }
}
