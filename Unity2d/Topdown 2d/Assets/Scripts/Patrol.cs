using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Topdown {
    public class Patrol : MonoBehaviour {

        public Vector2[] points;

        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        private void OnDrawGizmos() {
            Vector3 point = points[0];
            Debug.DrawLine(
                transform.position,
                transform.position + point,
                Color.cyan);

            for (int i = 1; i < points.Length; i++) {
                point = points[i-1];
                Vector3 start = transform.position + point;

                point = points[i];
                Vector3 end = transform.position + point;
                Debug.DrawLine(
                    start,
                    end,
                    Color.cyan);
            }

            point = points[points.Length-1];
            Debug.DrawLine(
                transform.position + point,
                transform.position,
                Color.cyan);
        }

    }
}