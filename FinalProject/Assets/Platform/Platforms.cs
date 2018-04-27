﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Spawn
{
    public class Platforms : MonoBehaviour
    {

        public Transform prefab;
        public int numberOfObj;
        [SerializeField]
        private Vector3 start;
        [SerializeField]
        private Vector3 nextPosition;
        [SerializeField]
        private float recycle;
        private Queue<Transform> objQueue;

        public Vector3 min, max, minDist, maxDist;
        public float minY, maxY;


        void Start()
        {

            objQueue = new Queue<Transform>(numberOfObj);
            for (int i = 0; i < numberOfObj; i++)
            {
                objQueue.Enqueue((Transform)Instantiate(prefab));
            }
            nextPosition = start;
            for (int i = 0; i < numberOfObj; i++)
            {
                Recycle();
            }
        }
        private void Update()
        {
            if (objQueue.Peek().localPosition.x + recycle < Runner_Controller.distanceTraveled)
            {
                Recycle();
            }
        }

        private void Recycle()
        {
            Vector3 scale = new Vector3(
                Random.Range(min.x, max.x),
                Random.Range(min.y, min.y),
                Random.Range(min.z, max.z));

            Vector3 pos = nextPosition;
            pos.x += scale.x * 0.5f;
            nextPosition.y += scale.y * 0.5f;

            Transform obj = (Transform)Instantiate(prefab);
            obj.localScale = scale;
            obj.localPosition = pos;
            nextPosition.x += scale.x;
            objQueue.Enqueue(obj);

            nextPosition += new Vector3
                (
                    Random.Range(minDist.x, maxDist.x) + scale.x,
                    Random.Range(minDist.y, maxDist.y),
                    Random.Range(minDist.z, maxDist.z));
            if (nextPosition.y < minY)
            {
                nextPosition.y = minY + maxDist.y;
            }
            else if (nextPosition.y > maxY)
            {
                nextPosition.y = maxY - maxDist.y;
            }
        }
    }
}
