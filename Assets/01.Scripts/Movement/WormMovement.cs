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
            switch (_moveDirection)
            {
                case Enums.Direction.Left:
                    dir = new Vector2Int(-1, 0);
                    break;
                case Enums.Direction.Up:
                    dir = new Vector2Int(0, 1);
                    break;
                case Enums.Direction.Right:
                    dir = new Vector2Int(1, 0);
                    break;
                case Enums.Direction.Down:
                    dir = new Vector2Int(0, -1);
                    break;
            }
            _rigidCompo.linearVelocity = dir;
        }
    }
}
