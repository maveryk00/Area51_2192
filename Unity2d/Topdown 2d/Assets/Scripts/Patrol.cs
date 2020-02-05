using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Topdown {
    public class Patrol : MonoBehaviour {
        float t = 0f;
        Vector3 startPos;

        public Vector2[] points;

        // Start is called before the first frame update
        void Start() {
            startPos = transform.position;
        }

        // Update is called once per frame
        void Update() {
            Vector3 point = points[0];
            transform.position = Vector3.Lerp(startPos, startPos + point, t);

            t += Time.deltaTime;

            if (t >= 1f)
                t = 0;
        }

        private void OnDrawGizmos() {
            if (!Application.isPlaying && startPos != transform.position)
                startPos = transform.position;

            Vector3 point = points[0];
            Debug.DrawLine(
                startPos,
                startPos + point,
                Color.cyan);

            for (int i = 1; i < points.Length; i++) {
                point = points[i-1];
                Vector3 start = startPos + point;

                point = points[i];
                Vector3 end = startPos + point;
                Debug.DrawLine(
                    start,
                    end,
                    Color.cyan);
            }

            point = points[points.Length-1];
            Debug.DrawLine(
                startPos + point,
                startPos,
                Color.cyan);
        }

    }
}