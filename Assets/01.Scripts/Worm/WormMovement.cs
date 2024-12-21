using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;


namespace SSH.Snake
{
    public struct PositionAndTime
    {
        public Vector3 PastPosition;
        public float PastTime;
    }
    
    public class WormMovement : MonoBehaviour
    {
        protected Enums.Direction _moveDirection;
        public Queue<PositionAndTime> PastDataQueue = new Queue<PositionAndTime>();
        
        public virtual void Update()
        {
            AddPastPositionToQueue();
        }

        private void AddPastPositionToQueue()
        {
            PositionAndTime posNTime;
            posNTime.PastTime = Time.time;
            posNTime.PastPosition = transform.position;

            PastDataQueue.Enqueue(posNTime);
        }
    }
}
