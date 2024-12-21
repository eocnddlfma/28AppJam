using UnityEngine;

public class AddPickaxe : MonoBehaviour {
    private int target = 0;
    [SerializeField] private GameObject pickaxe;
    
    private void next() {

        target += 180;
    }
    void Update()
    {
        if (ScoreManager.Instance.Score >= target) {
            next();
            Instantiate(pickaxe);
        }
    }
}
