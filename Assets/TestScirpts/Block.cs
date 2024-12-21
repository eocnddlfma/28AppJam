using UnityEngine;
using UnityEngine.InputSystem;

public class Block: MonoBehaviour {

    private MineralType type;
    public int Health { get; protected set; } = 1;
    
    public bool OnDameged(int power = 1) {

        Health -= power;
        if (Health <= 0) {
            Debug.Log("dead");  
            Health = 0;
            OnDead();
            return true;
        }

        return false;
    }

    private void OnDead() {
        //TODO: If this type isn't stone make jowel
        //TODO: Add score + 1
        Destroy(gameObject);
        
    }
}