using UnityEngine;

[CreateAssetMenu(menuName = "Juwel")]
public class JuwelScriptable : ScriptableObject {

    [SerializeField] private GameObject prefab;

    public GameObject Prefab => prefab;

    [SerializeField] private int score;
    public int Score => score;
}