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

    private void OnCollisionTrigger2D(Collider2D other)
    {
        if (other.transform.TryGetComponent(out WormPart wormPart))
        {
            //점수 추가해줘야함
            WormManager.Instance.CreateTail(other.transform.position, other.transform.GetComponent<SpriteRenderer>().sprite);
            Destroy(gameObject);
        }
    }
}