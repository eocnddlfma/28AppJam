using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace SSH.Snake
{
    public struct PositionAndTime
    {
        public Vector3 pastPosition;
        public float pastTime;
    }
    
    [RequireComponent(typeof(Rigidbody2D))]
    public class WormMovement : MonoBehaviour
    {
        [SerializeField] private InputSO _input;

        private Rigidbody2D _rigidCompo;
        private Enums.Direction _moveDirection;

        public Queue<PositionAndTime> pastPosData;
        
        public virtual void Start()
        {
            _rigidCompo = GetComponent<Rigidbody2D>();

        }

        public virtual void Update()
        {
            AddPastPositionToQueue();
        }

        private void AddPastPositionToQueue()
        {
            PositionAndTime posNTime;
            posNTime.pastTime = Time.time;
            posNTime.pastPosition = transform.position;
            
            pastPosData.Enqueue(posNTime);
            
        }

        public void Move()
        {
            Vector2Int dir = Vector2Int.zero;
            dir = _moveDirection switch {
                Enums.Direction.Left    => Vector2Int.left,
                Enums.Direction.Up      => Vector2Int.up,
                Enums.Direction.Right   => Vector2Int.right,
                Enums.Direction.Down    => Vector2Int.down
            };
            
            _rigidCompo.linearVelocity = dir;
        }
    }
}
