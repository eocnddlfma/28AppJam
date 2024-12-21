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

        private Enums.Direction _inputMoveDirection;
        private Enums.Direction _currentMoveDirection;
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
        public void Update()
        {
            SetDirection();
            Move();
        }

        private void Move()
        {
            _rigidCompo.linearVelocity = _moveVector * _moveSpeedPerSecond;
            //_rigidCompo.MovePosition(transform.position + (Vector3)_moveVector * _moveSpeedPerSecond * Time.deltaTime );
            print($"time : {Time.time}, pos : {transform.position}");
        }
        
        public void SetDirection()
        {
            switch (_inputMoveDirection)
            {
                case Enums.Direction.Left:
                    if (_currentMoveDirection == Enums.Direction.Right) break;
                    _moveVector.x = -1;
                    _moveVector.y = 0;
                    _currentMoveDirection = _inputMoveDirection;
                    break;
                case Enums.Direction.Up:
                    if (_currentMoveDirection == Enums.Direction.Down) break;
                    _moveVector.x = 0;
                    _moveVector.y = 1;
                    _currentMoveDirection = _inputMoveDirection;
                    break;
                case Enums.Direction.Right:
                    if (_currentMoveDirection == Enums.Direction.Left) break;
                    _moveVector.x = 1;
                    _moveVector.y = 0;
                    _currentMoveDirection = _inputMoveDirection;
                    break;
                case Enums.Direction.Down:
                    if (_currentMoveDirection == Enums.Direction.Up) break;
                    _moveVector.x = 0;
                    _moveVector.y = -1;
                    _currentMoveDirection = _inputMoveDirection;
                    break;
            }
        }


        private void HandleLeftButtonEvent()
        {
            _inputMoveDirection = Enums.Direction.Left;
        }

        private void HandleUpButtonEvent()
        {
            _inputMoveDirection = Enums.Direction.Up;
        }

        private void HandleRightButtonEvent()
        {
            _inputMoveDirection = Enums.Direction.Right;
        }

        private void HandleDownButtonEvent()
        {
            _inputMoveDirection = Enums.Direction.Down;
        }
    }
}
