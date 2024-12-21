using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace SSH.Snake
{  
    [RequireComponent(typeof(Rigidbody2D))]
    public class WormHead : WormMovement
    {
        [SerializeField] private InputSO _input;

        private Rigidbody2D _rigidCompo;
        private Vector2 _moveVector;
        [SerializeField] private float _moveSpeedPerSecond = 0.4f;

        public void Start()
        {
            _rigidCompo = GetComponent<Rigidbody2D>();
            _input.OnLeftButtonEvent += HandleLeftButtonEvent;
            _input.OnUpButtonEvent += HandleUpButtonEvent;
            _input.OnRightButtonEvent += HandleRightButtonEvent;
            _input.OnDownButtonEvent += HandleDownButtonEvent;

        }
        public override void Update()
        {
            base.Update();
            SetDirection();
            Move();
        }

        private void Move()
        {
            _rigidCompo.linearVelocity = _moveVector * _moveSpeedPerSecond;
            print($"time : {Time.time}, pos : {transform.position}");
        }
        
        public void SetDirection()
        {
            switch (_moveDirection)
            {
                case Enums.Direction.Left:
                    _moveVector.x = -1;
                    _moveVector.y = 0;
                    break;
                case Enums.Direction.Up:
                    _moveVector.x = 0;
                    _moveVector.y = 1;
                    break;
                case Enums.Direction.Right:
                    _moveVector.x = 1;
                    _moveVector.y = 0;
                    break;
                case Enums.Direction.Down:
                    _moveVector.x = 0;
                    _moveVector.y = -1;
                    break;
            }
        }


        private void HandleLeftButtonEvent()
        {
            _moveDirection = Enums.Direction.Left;
        }

        private void HandleUpButtonEvent()
        {
            _moveDirection = Enums.Direction.Up;
        }

        private void HandleRightButtonEvent()
        {
            _moveDirection = Enums.Direction.Right;
        }

        private void HandleDownButtonEvent()
        {
            _moveDirection = Enums.Direction.Down;
        }
    }
}
