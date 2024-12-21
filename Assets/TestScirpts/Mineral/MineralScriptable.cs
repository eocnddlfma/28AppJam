using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
[CreateAssetMenu(menuName = "Mineral")]
public class MineralScriptable: ScriptableObject {
    
    [SerializeField] private GameObject prefab;

    public GameObject Prefab {
        get => prefab;
    }
    [SerializeField] private float percent;

    public float Percent {
        get => percent;
    }
    [SerializeField] private JuwelScriptable juwelType;

    public JuwelScriptable JuwelType {
        get => juwelType;
    }
}