using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Topdown.AI;

namespace Topdown {
    public class Patrol : MonoBehaviour {
        int currentIndex;
        float t = 0f;
        Vector3 startPos;
        Vector3 endPos;
        List<Vector3> points;

        public float speed = 1f;

        public ActionArea player;

        public Path path;

        // Start is called before the first frame update
        void Start() {
            currentIndex = 0;
            points = path.points;

            startPos = points[0];
            endPos = points[1];

            if (path.type == PathType.pingpong && path.isClose)
                points.Add(points[0]);
        }

        // Update is called once per frame
        void Update() {
            transform.position = Vector3.Lerp(startPos, endPos, t);

            t += Time.deltaTime * speed;


            if (t >= 1f) {
                currentIndex++;

                if (currentIndex >= points.Count)
                    OnFinishPath();


                startPos = endPos;
                endPos = points[currentIndex];

                float distance = Vector3.Distance(startPos, endPos);
                speed = 2f / distance;

                t = 0;
            }

        }

        private void OnFinishPath() {
            switch (path.type) {
                case PathType.loop:
                    currentIndex = 0;

                    if (!path.isClose) {
                        endPos = points[currentIndex];
                        transform.position = endPos;
                    }
                    break;

                case PathType.pingpong:
                    
                        points.Reverse();
                        currentIndex = 0;
                    
                    break;
            }
        }
    }
}