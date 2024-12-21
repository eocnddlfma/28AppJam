using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class BallMovement : MonoBehaviour {
    private const int RandomDegreeRange = 5;
    
    Rigidbody2D player = null;
    [SerializeField] private float power = 30;
    [SerializeField] private Vector2 moveDirection = Vector2.zero;

    private Vector2 velo = Vector2.zero;
    private Quaternion currentView;
    
    private const int collisionDegree = 90;

    private readonly Vector2[] directions = new Vector2[] {
        Vector2.up,
        Vector2.down,
        Vector2.left,
        Vector2.right
    };

    void Awake() {

        float degree = moveDirection.ToDegree();
        currentView = Quaternion.Euler(0, 0, degree);
        
        if (player == null) {
            player = GetComponent<Rigidbody2D>();
            
            //first speed. it can delete
            velo = (power * (moveDirection.normalized));
            player.linearVelocity = velo;
        }
    }

    private Vector2 before = Vector2.zero;
    private void OnCollisionEnter2D(Collision2D other) {

        var ballToBlockDirection = FindDirection(transform.position, other.transform.position);
        if (before == ballToBlockDirection) return;

        before = ballToBlockDirection;
        Debug.Log($"{ballToBlockDirection}, velo: {velo}");
        
        //contect up or down
        if (Mathf.Approximately(ballToBlockDirection.x,0)) {
            velo.y *= -1;
        }
           
        //contect right or left
        else {
            velo.x *= -1;
        }

        //add random degree
        float random = (float)Random.Range(-RandomDegreeRange, RandomDegreeRange);
        velo = (velo.ToDegree() + random).Todirection() * power;
        player.linearVelocity = velo;
    }

    //detect collision direction
    // return to 4direction(up, down, left, right)
    private Vector2 FindDirection(Vector2 ball, Vector2 wall) {

        var collisionDir = (wall - ball).normalized;

        float best = 0;
        Vector2 ballToBlockDirection = Vector2.zero;

        //find by dot product's high value
        foreach (var direction in directions) {

            float value = direction.DotProduction(collisionDir);

            if (best < value) {

                ballToBlockDirection = direction;
                best = value;
            }
        }

        return ballToBlockDirection;
    }
}