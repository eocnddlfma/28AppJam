using System;
using DG.Tweening;
using UnityEngine;

namespace SSH.Snake
{
        
    public class WormTail : WormPart
    {
        [SerializeField]private WormPart _parentPart;
        [SerializeField] private float _delayTime = 0.2f;
        private EdgeCollider2D _collider;

        public void SetParent(WormPart parent)
        {
            _parentPart = parent;
        }

        private void Awake()
        {
            WormManager.Instance.OnDeadEvent += () =>
            {
                Destroy(gameObject);
            };
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if(_parentPart.PastDataQueue.Count == 0) return;
            CheckAndMove();
        }

        private bool CheckAndMove()
        {
            PositionAndTime lastData = _parentPart.PastDataQueue.Peek();
            if (lastData.PastTime + _delayTime/2 < Time.time)
            {// 0.5초라면     0.2초    현재 시간  6초
                _parentPart.PastDataQueue.Dequeue();
                if (!CheckAndMove())
                {
                    transform.DOMove(lastData.PastPosition, Time.time - lastData.PastTime);
                    transform.DORotateQuaternion(lastData.PastRotation, Time.time - lastData.PastTime);
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
