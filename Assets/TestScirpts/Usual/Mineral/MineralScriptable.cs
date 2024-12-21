using UnityEngine;

[CreateAssetMenu(menuName = "Mineral")]
public class MineralScriptable: ScriptableObject {
    
    [SerializeField] private Sprite image;
    [SerializeField] private float percent;
    [SerializeField] private JuwelScriptable type;
}