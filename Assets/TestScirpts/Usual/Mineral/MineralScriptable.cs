using UnityEngine;

[CreateAssetMenu(menuName = "Mineral")]
public class MineralScriptable: ScriptableObject {
    
    [SerializeField] private Sprite image;
    public Sprite Image => image;
    
    [SerializeField] private float percent;

    public float Percent => percent;
    [SerializeField] private JuwelScriptable type;

    public JuwelScriptable Type => type;
}