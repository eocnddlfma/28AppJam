using UnityEngine;

[CreateAssetMenu(menuName = "Juwel")]
public class JuwelScriptable : ScriptableObject
{
    [Header("Juwel Properties")]
    [SerializeField] private Sprite image;
    [SerializeField] private GameObject prefab;
    [SerializeField] private int score;

    
    public Sprite Image => image;

    public GameObject Prefab => prefab;

    
    public int Score => score;
}