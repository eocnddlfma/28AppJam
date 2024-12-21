using System;
using UnityEngine;

namespace SSH.Snake
{
    //만약 0.4초에 1칸을 이동한다고 가정하면
    [RequireComponent(typeof(Rigidbody2D))]
    public class WormHead : WormMovement
    {
        [SerializeField] private InputSO _input;

        private Rigidbody2D _rigidCompo;
        private Enums.Direction _moveDirection;

        public override void Start()
        {
            base.Start();
            _rigidCompo = GetComponent<Rigidbody2D>();
            _input.OnLeftButtonEvent    += HandleLeftButtonEvent;
            _input.OnUpButtonEvent      += HandleUpButtonEvent;
            _input.OnRightButtonEvent   += HandleRightButtonEvent;
            _input.OnDownButtonEvent    += HandleDownButtonEvent;

        }

        private void OnCollisionEnter2D(Collision2D other)
        {
        }

        public override void Update()
        {
            Move();
        }



        private void HandleLeftButtonEvent()
            => _moveDirection = Enums.Direction.Left;

        private void HandleUpButtonEvent()
            => _moveDirection = Enums.Direction.Up;

        private void HandleRightButtonEvent()
            => _moveDirection = Enums.Direction.Right;

        private void HandleDownButtonEvent()
            => _moveDirection = Enums.Direction.Down;
    }
}
