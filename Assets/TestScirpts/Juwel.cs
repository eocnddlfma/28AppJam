using System;
using SSH.Snake;
using UnityEngine;

public class Juwel: MonoBehaviour {

    private int value;
    private float _gravity = 9.8f;

    public void Set(Vector2 pos, int value) {

        transform.position = pos;
        this.value = value;
        gameObject.isStatic = true;
    }
    public int Value { get; protected set; }


    private void Update()
    {
        transform.Translate(Vector3.down * _gravity);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.TryGetComponent(out WormPart wormPart))
        {
            //점수 추가해줘야함
            WormManager.Instance.CreateTail(transform.position, other.transform.GetComponent<JuwelScriptable>().Image);
            Destroy(gameObject);
        }
    }
}