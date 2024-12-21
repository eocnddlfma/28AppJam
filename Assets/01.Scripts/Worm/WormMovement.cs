using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using DG.Tweening;

namespace SSH.Snake
{
    public struct PositionAndTime
    {
        public Vector3 PastPosition;
        public float PastTime;
    }
    
    public class WormMovement : MonoBehaviour
    {
        public Vector3 Point3;
        public Vector3 Point4;
        
        public Queue<PositionAndTime> PastDataQueue = new Queue<PositionAndTime>();
        
        public virtual void FixedUpdate()
        {
            Point3 = transform.position + transform.right; 
            Point4 = transform.position - transform.right; 
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
