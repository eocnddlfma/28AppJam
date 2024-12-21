using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class BallMovement : MonoBehaviour {
    private const int alphaDegree = 5;
    
    Rigidbody2D player = null;
    [SerializeField] private float power = 30;
    [SerializeField] private Vector2 moveDirection = Vector2.zero;

    private const int collisionDegree = 90;
    private readonly Vector2[] directions = new Vector2[] {
        Vector2.up,
        Vector2.down,
        Vector2.left,
        Vector2.right
    };
    
    void Awake()
    {
        if (player == null) {
            player = GetComponent<Rigidbody2D>();
            player.AddForce(power * (moveDirection.normalized));
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {

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
        var addDegree = currentDegree.Add(UsualQuarternion.ZRotation(90 + Random.Range(0, alphaDegree + 1)));
        float result = Mathf.Sign(playerVelocity.DotProduction(ballToBlockDirection));
        var rotation = addDegree.Multiple(result);

        player.linearVelocity = rotation;
    }
}