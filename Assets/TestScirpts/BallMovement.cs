using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class BallMovement : MonoBehaviour {
    private const int alphaDegree = 5;
    
    Rigidbody2D player = null;
    [SerializeField] private float power = 30;
    [SerializeField] private Vector2 moveDirection = Vector2.zero;
    private GameObject before = null;
    
    
    private const int collisionDegree = 90;
    private readonly Vector2[] directions = new Vector2[] {
        Vector2.up,
        Vector2.down,
        Vector2.left,
        Vector2.right
    };
    
    void Awake() {

        float tempDegree = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        Debug.Log(tempDegree);
        transform.Rotate(new Vector3(0, 0, tempDegree));
        
        if (player == null) {
            player = GetComponent<Rigidbody2D>();
            player.AddForce(power * (moveDirection.normalized));
        }
    }


    private void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject == before) return;
        before = other.gameObject;
        
        var collisionDir = (other.transform.position - transform.position).normalized;

        float best = 0;
        Vector2 ballToBlockDirection = Vector2.zero;

        foreach (var direction in directions) {

            float value = direction.DotProduction(collisionDir); 
           
            if (best < value) {

                ballToBlockDirection = direction;
                best = value;
            }
        }

        var playerVelocity = player.linearVelocity.normalized;

        var currentDegree = transform.rotation;
        Debug.Log(currentDegree.eulerAngles);
        var addDegree = currentDegree.Add(UsualQuarternion.ZRotation(90));
        float result = playerVelocity.DotProduction(ballToBlockDirection) > 0 ? 1 : -1;
        var rotation = addDegree.Multiple(result);
        transform.Rotate(rotation.eulerAngles);

        player.linearVelocity = 10 * rotation.eulerAngles.z.Todirection().normalized;
    }
}