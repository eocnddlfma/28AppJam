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
        public Quaternion PastRotation;
        public float PastTime;
    }
    
    public class WormPart : MonoBehaviour
    {
        public Queue<PositionAndTime> PastDataQueue = new Queue<PositionAndTime>();
        
        
        public virtual void FixedUpdate()
        {
            AddPastPositionToQueue();
        }

        private void AddPastPositionToQueue()
        {
            PositionAndTime posNTime;
            posNTime.PastTime = Time.time;
            posNTime.PastPosition = transform.position;
            posNTime.PastRotation = transform.rotation;

            PastDataQueue.Enqueue(posNTime);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.CompareTag("jewel"))
            {
                WormManager.Instance.CreateTail(other.transform.GetComponent<JuwelScriptable>().Image);
            }
        }
    }
}
