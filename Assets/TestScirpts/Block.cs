using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Block: MonoBehaviour {


    private JuwelScriptable juwel;
    public int Health { get; protected set; } = 1;

    public void Set(Vector2 pos, JuwelScriptable type, MineralType mineralType) {

        transform.localPosition = pos;
        gameObject.isStatic = true;

        juwel = type;
        if (mineralType == MineralType.Stone)
            juwel = null;
    }

    private static GameObject folder = null;

    private void Awake() {

        if (folder != null) 
            return;

        folder = new();
        folder.name = "Juwels";
        folder.transform.position = Vector2.zero;
    }

    public bool OnDamaged(int power = 1) {

        Health -= power;
        if (Health <= 0) {
            Health = 0;
            OnDead();
            return true;
        }

        return false;
    }

    private void OnDead() {

        if(juwel != null) 
            Instantiate(juwel.Prefab, folder.transform)
                .GetComponent<Juwel>().Set(transform.position, juwel.Score);
        //TODO: Add score + 1
        Destroy(gameObject);
        
    }
}