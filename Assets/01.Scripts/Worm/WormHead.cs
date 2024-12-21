using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace SSH.Snake
{  
    [RequireComponent(typeof(Rigidbody2D))]
    public class WormHead : WormPart
    {
        [SerializeField] private InputSO _input;

        private Direction _inputMoveDirection;
        private Direction _currentMoveDirection = Direction.Up;
        
        private Rigidbody2D _rigidCompo;
        private Animator _animatorCompo;
        private SpriteRenderer _rendererCompo;
        
        private Vector2 _moveVector;
        [SerializeField] private float _moveSpeedPerSecond = 0.4f;
        [SerializeField]private float _inputInterval = 0.2f;

        [SerializeField] private GameObject _deadEffect;
        
        private bool isDead = false;
        private bool isBeforeStart;

        public void Start()
        {
            _rigidCompo = GetComponent<Rigidbody2D>();
            _animatorCompo = GetComponentInChildren<Animator>();
            _rendererCompo = GetComponentInChildren<SpriteRenderer>();
            _input.OnLeftButtonEvent += HandleLeftButtonEvent;
            _input.OnUpButtonEvent += HandleUpButtonEvent;
            _input.OnRightButtonEvent += HandleRightButtonEvent;
            _input.OnDownButtonEvent += HandleDownButtonEvent;

            _animatorCompo.SetBool("Idle", true);
            isBeforeStart = true;//나중에 이거를 풀어주는게 있어야함.
            DoStart();
        }
        public void Update()
        {
            if (isDead) return;
            if (isBeforeStart) return;
            
            SetDirection();
            Move();
        }

        private void Move()
        {
            _rigidCompo.linearVelocity = _moveVector * _moveSpeedPerSecond;
            _rigidCompo.MoveRotation(Quaternion.Euler(0f, 0f, Mathf.Atan2(_moveVector.y, _moveVector.x) * Mathf.Rad2Deg - 90f));
            //_rigidCompo.MovePosition(transform.position + (Vector3)_moveVector * _moveSpeedPerSecond * Time.deltaTime );
            //print($"time : {Time.time}, pos : {transform.position}");
        }
        
        public void SetDirection()
        {
            (_moveVector, _currentMoveDirection) = _inputMoveDirection switch
            {
                Direction.Left  when _currentMoveDirection != Direction.Right => (Vector2Int.left, Direction.Left),
                Direction.Up    when _currentMoveDirection != Direction.Down  => (Vector2Int.up, Direction.Up),
                Direction.Right when _currentMoveDirection != Direction.Left  => (Vector2Int.right, Direction.Right),
                Direction.Down  when _currentMoveDirection != Direction.Up    => (Vector2Int.down, Direction.Down),
                _ => (_moveVector, _currentMoveDirection)
            };

            _rendererCompo.flipX = _moveVector is { x: >= 0, y: >= 0 };

            // switch (_inputMoveDirection)
            // {
            //     case Enums.Direction.Left:
            //         if (_currentMoveDirection == Enums.Direction.Right) break;
            //         _moveVector.x = -1;
            //         _moveVector.y = 0;
            //         _currentMoveDirection = _inputMoveDirection;
            //         break;
            //     case Enums.Direction.Up:
            //         if (_currentMoveDirection == Enums.Direction.Down) break;
            //         _moveVector.x = 0;
            //         _moveVector.y = 1;
            //         _currentMoveDirection = _inputMoveDirection;
            //         break;
            //     case Enums.Direction.Right:
            //         if (_currentMoveDirection == Enums.Direction.Left) break;
            //         _moveVector.x = 1;
            //         _moveVector.y = 0;
            //         _currentMoveDirection = _inputMoveDirection;
            //         break;
            //     case Enums.Direction.Down:
            //         if (_currentMoveDirection == Enums.Direction.Up) break;
            //         _moveVector.x = 0;
            //         _moveVector.y = -1;
            //         _currentMoveDirection = _inputMoveDirection;
            //         break;
            // }
        }

        public void DoStart()
        {
            isBeforeStart = false;
            _animatorCompo.SetBool("Idle", false);
            _animatorCompo.SetBool("Move", true);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.CompareTag("Tail") || other.transform.CompareTag("Mineral") || other.transform.CompareTag("Weapon"))
            {
                isDead = true;
                
                _animatorCompo.SetBool("Move", false);
                _animatorCompo.SetBool("Die", true);

                _rigidCompo.linearVelocity = Vector3.zero;

                Instantiate(_deadEffect, transform.position, Quaternion.identity);
                
                WormManager.Instance.InvokeDeadEvent();

                Destroy(gameObject);
            }
        }
        
        
        
        private void OnDrawGizmos()
        {
            
            Gizmos.DrawLine(transform.position, transform.position + transform.up);
            Gizmos.DrawLine(transform.position, transform.position + transform.right);
            Gizmos.DrawLine(transform.position, transform.position + -transform.right);
            
        }

        
        #region Input

        private float _lastInput = 0f;
        private bool IsAbleInput()
        {
            if (Time.time > _lastInput + _inputInterval)
            {
                _lastInput = Time.time;
                return true;
            }
            return false;
        }
        private void HandleLeftButtonEvent()
        {
            if (IsAbleInput())
                _inputMoveDirection = Direction.Left;
        }

        private void HandleUpButtonEvent()
        {
            if (IsAbleInput())
                _inputMoveDirection = Direction.Up;
        }

        private void HandleRightButtonEvent()
        {
            if (IsAbleInput())
                _inputMoveDirection = Direction.Right;
        }

        private void HandleDownButtonEvent()
        {
            if (IsAbleInput())
                _inputMoveDirection = Direction.Down;
        }
        #endregion
    }
}
