using UnityEngine;

public class ScoreManager: MonoBehaviour {

    public static ScoreManager Instance { get; private set; } = null;
    public int Score { get; private set; } = 0;

    public void AddScore(int point) {
        Score += point;
    }
    
    private void Awake() {

        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(this);
    }
    
    
}