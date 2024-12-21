using UnityEngine;

[CreateAssetMenu(menuName = "Juwel")]
public class JuwelScriptable : ScriptableObject {

    [SerializeField] private Sprite image;
    [SerializeField] private int score;
}