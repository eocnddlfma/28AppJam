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

        private Enums.Direction _inputMoveDirection;
        private Enums.Direction _currentMoveDirection = Enums.Direction.Up;
        
        private Rigidbody2D _rigidCompo;
        private Animator _animatorCompo;
        private SpriteRenderer _rendererCompo;
        
        private Vector2 _moveVector;
        [SerializeField] private float _moveSpeedPerSecond = 0.4f;

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
                Enums.Direction.Left  when _currentMoveDirection != Enums.Direction.Right => (Vector2Int.left, Enums.Direction.Left),
                Enums.Direction.Up    when _currentMoveDirection != Enums.Direction.Down  => (Vector2Int.up, Enums.Direction.Up),
                Enums.Direction.Right when _currentMoveDirection != Enums.Direction.Left  => (Vector2Int.right, Enums.Direction.Right),
                Enums.Direction.Down  when _currentMoveDirection != Enums.Direction.Up    => (Vector2Int.down, Enums.Direction.Down),
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
            isDead = true;
            
            _animatorCompo.SetBool("Move", false);
            _animatorCompo.SetBool("Die", false);
            //죽으면 발생하는 이벤트 발생해주기.
        }


        private void OnDrawGizmos()
        {
            
            Gizmos.DrawLine(transform.position, transform.position + transform.up);
            Gizmos.DrawLine(transform.position, transform.position + transform.right);
            Gizmos.DrawLine(transform.position, transform.position + -transform.right);
            
        }

        
        #region Input
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
        #endregion
    }
}
