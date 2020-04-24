using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    [RequireComponent(typeof(LineRenderer))]
    public class Laser : MonoBehaviour {
        [SerializeField]
        private LineRenderer line;

        [SerializeField]
        [Range(0f, 1f)]
        private float t = 0f;

        private Enemy enemy;
        private float nextAttack = 0f;

        public Transform origin;
        public Transform target;

        public float speed = 1f;

        public int dmg = 1;
        public float rate = 0.1f;

        public Vector3 end {
            get {
                return Vector3.forward * distance;
            }
        }

        public Vector3 start {
            get {
                return line.GetPosition(0);
            }
        }

        public float distance {
            get {
                if (target == null)
                    return 0;

                return Vector3.Distance(origin.position, target.position);
            }
        }

        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            //if (Input.GetKeyDown(KeyCode.P))
            //    Play();



            transform.position = origin.position;
            transform.rotation = origin.rotation;

            if (target == null) return;

            enemy = target.GetComponent<Enemy>();
            if (enemy == null) return;

            if (Time.time >= nextAttack) {
                nextAttack = Time.time + rate;
                enemy.Damage(dmg);
            }
        }

        //void OnDrawGizmos() {
        //    //Vector3 end = line.GetPosition(1);
        //    //end.z = distance;
        //    line.SetPosition(1, Vector3.Lerp(start, end, t));
        //}

        public void Play() {
            StopAllCoroutines();
            StartCoroutine(Animation());
        }

        public void Stop() {
            StopAllCoroutines();
            line.SetPosition(0, Vector3.zero);
            line.SetPosition(1, Vector3.zero);
        }

        public void Init() {
            line = GetComponent<LineRenderer>();
            line.SetPosition(0, Vector3.zero);
            line.SetPosition(1, Vector3.zero);

            t = 0;

            Play();
        }

        IEnumerator Animation() {
            t = 0f;

            while (t < 1f) {
                line.SetPosition(1, Vector3.Lerp(start, end, t));

                t += speed * Time.deltaTime;

                yield return new WaitForEndOfFrame();
            }

            while (true) {
                line.SetPosition(1, end);
                yield return new WaitForEndOfFrame();
            }

        }

    }
}