using UnityEngine;

public class Juwel: MonoBehaviour {

    private int value;

    public void Set(Vector2 pos, int value) {

        transform.position = pos;
        this.value = value;
        gameObject.isStatic = true;
    }
    public int Value { get; protected set; } 
}