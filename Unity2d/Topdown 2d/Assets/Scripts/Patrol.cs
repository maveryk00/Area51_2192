using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Topdown {
    public class Patrol : MonoBehaviour {
        int currentIndex;
        float t = 0f;
        Vector3 startPos;
        Vector3 endPos;
        Vector3 point;
        Vector3 origin;

        public Vector2[] points;
        public float speed = 1f;

        public ActionArea player;

        // Start is called before the first frame update
        void Start() {
            currentIndex = 0;
            point = points[currentIndex];
            origin = transform.position;
            startPos = origin;
            endPos = origin + point;
            
        }

        // Update is called once per frame
        void Update() {
            transform.position = Vector3.Lerp(startPos, endPos, t);

            t += Time.deltaTime * speed;

            if (Vector3.Distance(transform.position, player.transform.position) <= player.radius) {
                speed *= 2f;
            }
            else {
                float distance = Vector3.Distance(startPos, endPos);
                speed = 2f / distance;
            }


            if (t >= 1f) {
                startPos = endPos;
                currentIndex++;

                if (currentIndex >= points.Length) {
                    currentIndex = -1;
                    point = Vector3.zero;
                }
                else {
                    point = points[currentIndex];
                }

                endPos = origin + point;

                float distance = Vector3.Distance(startPos, endPos);
                speed = 2f /distance;

                t = 0;
            }

        }

        private void OnDrawGizmos() {
            if (!Application.isPlaying && origin != transform.position)
                origin = transform.position;

            Vector3 point = points[0];
            Debug.DrawLine(
                origin,
                origin + point,
                Color.cyan);

            for (int i = 1; i < points.Length; i++) {
                point = points[i - 1];
                Vector3 start = origin + point;

                point = points[i];
                Vector3 end = origin + point;
                Debug.DrawLine(
                    start,
                    end,
                    Color.cyan);
            }

            point = points[points.Length - 1];
            Debug.DrawLine(
                origin + point,
                origin,
                Color.cyan);
        }

    }
}