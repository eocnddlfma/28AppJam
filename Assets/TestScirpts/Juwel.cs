using System;
using SSH.Snake;
using UnityEngine;

public class Juwel: MonoBehaviour {

    public int Value { get; protected set; }

    public void Set(Vector2 pos, int value) {

        transform.position = pos;
        Value = value;
        gameObject.isStatic = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.TryGetComponent(out WormPart wormPart)) {
            
            ScoreManager.Instance.AddScore(Value);
            WormManager.Instance.CreateTail(Vector3.zero, GetComponent<SpriteRenderer>().sprite);
            Destroy(gameObject);
        }
    }
}