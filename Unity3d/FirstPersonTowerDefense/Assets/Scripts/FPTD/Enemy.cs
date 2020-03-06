using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class Enemy : MonoBehaviour {
        public int life = 10;
        public float speed = 1f;
        public int minDmg = 1;
        public int maxDmg = 3;
        public Node origin = null;
        public Node target = null;

        [SerializeField]
        private float t = 0;

        // Start is called before the first frame update
        void Start() {
            origin = Path.startNode;
            target = origin.GetRandomExit();

            transform.position = origin.position;
        }

        // Update is called once per frame
        void Update() {
            Move();
        }

        public void Move() {
            t += speed * Time.deltaTime;
            transform.position =
                Path.GetPositionAt(origin, target, t);

            transform.forward =
                (origin.position - target.position).normalized;

            if (t > 1f)
                t = 0;
        }

        public void Death() {

        }

        public void Drop() {

        }

        public void Damage(int dmg) {

        }

        public void Attack() {

        }
    }
}