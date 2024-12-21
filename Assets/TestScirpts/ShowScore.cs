using System;
using TMPro;
using UnityEngine;

public class ShowScore : MonoBehaviour {
    private TMP_Text text;

    private void Awake() {

        text = transform.GetComponent<TMP_Text>();
    }

    void Update() {
        text.text = $"Score: {ScoreManager.Instance.Score}";
    }
}
