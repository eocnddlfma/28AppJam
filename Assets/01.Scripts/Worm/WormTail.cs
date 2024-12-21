using UnityEngine;

namespace SSH.Snake
{
        
    public class WormTail : WormMovement
    {
        [SerializeField]private WormMovement _parentPart;
        [SerializeField] private float _delayTime = 0.4f;
        
        public void SetParent(WormMovement parent)
        {
            _parentPart = parent;
        }
        

        public override void Update()
        {
            base.Update();
            print(_parentPart.PastDataQueue.Count);
            if(_parentPart.PastDataQueue.Count == 0) return;
            PositionAndTime lastData = _parentPart.PastDataQueue.Peek();
            if (lastData.PastTime + _delayTime < Time.time)
            {
                transform.position = lastData.PastPosition;
                _parentPart.PastDataQueue.Dequeue();
            }
            
        }
    }
}
