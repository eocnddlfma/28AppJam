using System;
using DG.Tweening;
using UnityEngine;

namespace SSH.Snake
{
        
    public class WormTail : WormMovement
    {
        [SerializeField]private WormMovement _parentPart;
        [SerializeField] private float _delayTime = 0.2f;
        private EdgeCollider2D _collider;

        public void SetParent(WormMovement parent)
        {
            _parentPart = parent;
            Vector3 point3 = _parentPart.Point3;
            point3 = transform.InverseTransformPoint(point3);
            _collider.points[3] = point3;
            Vector3 point4 = _parentPart.Point4;
            point4 = transform.InverseTransformPoint(point4);
            _collider.points[4] = point4;
        }

        private void Awake()
        {
            _collider.points = new[]
            {
                new Vector2(0, -0.5f),
                new Vector2(0, +0.5f),
                new Vector2(0, -0.5f),
                new Vector2(0, -0.5f),
                new Vector2(0, -0.5f)
            };
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            print(_parentPart.PastDataQueue.Count);
            if(_parentPart.PastDataQueue.Count == 0) return;
            CheckAndMove();
        }

        private bool CheckAndMove()
        {
            PositionAndTime lastData = _parentPart.PastDataQueue.Peek();
            if (lastData.PastTime + _delayTime/3 < Time.time)
            {// 0.5초라면     0.2초    현재 시간  6초
                _parentPart.PastDataQueue.Dequeue();
                if (!CheckAndMove())
                {
                    transform.DOMove(lastData.PastPosition, Time.time - lastData.PastTime);
                }
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
