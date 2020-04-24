using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class Rocket : MonoBehaviour {

        public Vector3 start;
        public Vector3 end;

        [Range(0f, 1f)]
        public float t;

        [Range(0f, 10f)]
        public float height = 5f;

        public float speed = 1f;
        public int dmg = 1;

        public AnimationCurve curve;
        public Explotion explotion;

        public float distance {
            get {
                return Vector3.Distance(start, end);
            }
        }


        // Start is called before the first frame update
        void Start() {
            t = 0;
        }

        // Update is called once per frame
        void Update() {
            if (t > 1f) {
                Explotion();
                return;
            }

            t += (speed * Time.deltaTime) / distance;
            Move();

        }



        void OnDrawGizmos() {
            Gizmos.DrawWireSphere(start, 0.2f);
            Gizmos.DrawWireSphere(end, 0.2f);

            if (!Application.isPlaying)
                Move();

        }

        private void Explotion() {
            Explotion clone = Instantiate(explotion, transform.position, Quaternion.identity);
            clone.dmg = dmg;

            Destroy(gameObject);
        }

        public void Move() {
            Vector3 pos = Vector3.Lerp(start, end, t);
            //pos.y = Mathf.Lerp(0f, height, t);
            //pos.y = Lerp(0, height, Spike(t));

            pos.y += curve.Evaluate(t) * height;

            Vector3 forward = (pos - transform.position).normalized;
            if (forward != Vector3.zero)
                transform.forward = forward;

            transform.position = pos;
        }


        private float Lerp(float a, float b, float t) {
            //return (1 - t) * a + t * b;
            return (a + t * (b - a));
        }

        private float Spike(float t) {
            if (t <= .5f)
                return EaseIn(t / .5f);

            return EaseIn(Flip(t) / .5f);
        }

        private float Flip(float x) {
            return 1 - x;
        }

        private float EaseIn(float t) {
            return t * t;
        }
    }
}