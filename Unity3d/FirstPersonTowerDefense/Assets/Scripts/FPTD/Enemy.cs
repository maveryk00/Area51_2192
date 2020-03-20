using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class Enemy : MonoBehaviour {
        public enum States {
            idle,
            walk,
            dead
        }

        public States state = States.idle;
        public int life = 10;
        public float speed = 1f;
        public int minDmg = 1;
        public int maxDmg = 3;
        public Node origin = null;
        public Node target = null;

        public Vector3 position {
            get {
                return transform.position;
            }
        }

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
            switch (state) {
                case States.idle:
                    Idle();
                    break;

                case States.walk:
                    Move();
                    break;

                case States.dead:
                    Dead();
                    break;
            }

        }

        public void Idle() {
            state = States.walk;
        }

        public void Dead() {

        }

        public void Move() {
            t += speed * Time.deltaTime;
            transform.position =
                Path.GetPositionAt(origin, target, t);
            
            transform.forward =
                -(origin.position - target.position).normalized;

            if (t > 1f) {
                t = 0;
                NextNodes();
            }
                
        }

        public void NextNodes() {
            origin = target;
            target = origin.GetRandomExit();

            //if (target == null)
            //    state = States.dead;

            if (origin == Path.finishNode)
                state = States.dead;
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