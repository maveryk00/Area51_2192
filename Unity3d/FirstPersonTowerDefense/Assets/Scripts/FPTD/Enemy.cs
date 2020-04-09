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

        private Transform _targetable;
        private float maxLife;

        public States state = States.idle;
        public int life = 10;
        public float speed = 1f;
        public int minDmg = 1;
        public int maxDmg = 3;
        public Node origin = null;
        public Node target = null;
        public EnemyHealthBar healthBar;

        public Vector3 position {
            get {
                return transform.position;
            }
        }

        public Vector3 targetable {
            get {
                return _targetable.position;
            }
        }

        [SerializeField]
        private float t = 0;

        // Start is called before the first frame update
        void Start() {
            origin = Path.startNode;
            target = origin.GetRandomExit();

            _targetable = transform.Find("Targetable");
            transform.position = origin.position;

            maxLife = life;
            healthBar.UpdateHealth(life/maxLife);
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
            EnemyManager.instance.RemoveEnemy(this);
            Destroy(gameObject);
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
            life -= dmg;
            healthBar.UpdateHealth(life/maxLife);

            if (life <= 0)
                state = States.dead;
        }

        public void Attack() {

        }
    }
}