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
        maxValue = Mathf.Max(Mathf.Abs(_target.position.x - transform.position.x) * 0.7f,
            Mathf.Abs(_target.position.y- transform.position.y) * 1.3f, maxValue);
        _camera.Lens.OrthographicSize = maxValue;
    }
}
