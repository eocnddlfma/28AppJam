using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class BallMovement : MonoBehaviour {
    private const int alphaDegree = 5;
    
    Rigidbody2D player = null;
    [SerializeField] private float power = 30;
    [SerializeField] private Vector2 moveDirection = Vector2.zero;
    private Vector2 before = Vector2.zero;

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
            player.AddForce(power * (moveDirection.normalized));
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {

        var ballToBlockDirection = FindDirection(transform.position, other.transform.position);
        var ballToBlockDegree = ballToBlockDirection.ToDegree();
        
        if (before == ballToBlockDirection) return;
        before = ballToBlockDirection;

        var playerVelocity = player.linearVelocity.normalized;
        var playerDegree = playerVelocity.ToDegree();
        
        var addDegree = UsualQuarternion.ZRotation(90);
        float result =  playerDegree > ballToBlockDegree ? -1 : 1;
        var rotation = addDegree.Multiple(result);
        currentView = currentView.Add(addDegree);
        Debug.Log(currentView.eulerAngles);
        player.linearVelocity = 10 * currentView.eulerAngles.z.Todirection().normalized;
    }

    private Vector2 FindDirection(Vector2 ball, Vector2 wall) {

        var collisionDir = (wall - ball).normalized;

        float best = 0;
        Vector2 ballToBlockDirection = Vector2.zero;

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