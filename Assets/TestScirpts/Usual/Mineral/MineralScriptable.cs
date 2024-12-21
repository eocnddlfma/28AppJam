using UnityEngine;

[CreateAssetMenu(menuName = "Mineral")]
public class MineralScriptable: ScriptableObject {
    
    [SerializeField] private GameObject image;

    public GameObject Image {
        get => image;
    }
    [SerializeField] private float percent;

    public float Percent {
        get => percent;
    }
    [SerializeField] private JuwelScriptable type;

    public JuwelScriptable Type {
        get => type;
    }
}