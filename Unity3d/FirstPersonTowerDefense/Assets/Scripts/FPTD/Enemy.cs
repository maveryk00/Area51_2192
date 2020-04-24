using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class Enemy : MonoBehaviour {
        public enum States {
            idle,
            walk,
            dead,
            finish
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
        public Consumible drop;
        public GameObject explosion;

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

        private float _speedMult = 1f;
        public float speedMult {
            set {
                _speedMult = value;
            }
        }


        [SerializeField]
        private float t = 0;

        // Start is called before the first frame update
        void Start() {
            
            maxLife = life;
            healthBar.UpdateHealth(life / maxLife);

            _targetable = transform.Find("Targetable");


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
                    Drop();
                    state = States.finish;
                    //Dead();
                    break;

                case States.finish:
                    Finish();
                    break;
            }

        }

        public void Idle() {
            state = States.walk;
        }

        public void Dead() {
            EnemyManager.instance.RemoveEnemy(this);

            Instantiate(explosion, targetable, transform.rotation);
            Destroy(gameObject);

        }

        public void Move() {
            if (target == null)
                return;

            t += speed * _speedMult * Time.deltaTime;
            transform.position =
                Path.GetPositionAt(origin, target, t);

            transform.forward =
                -(origin.position - target.position).normalized;

            if (t > 1f) {
                t = 0;
                NextNodes();
            }

        }

        public void Finish() {
            Dead();
        }

        public void NextNodes() {
            origin = target;
            target = origin.GetRandomExit();

            //if (target == null)
            //    state = States.dead;

            if (origin == Path.finishNode)
                state = States.finish;
        }

        public void Death() {

        }

        public void Drop() {
            Instantiate(drop, transform.position, transform.rotation);
        }

        public void Damage(int dmg) {
            if (life <= 0) return;

            life -= dmg;
            healthBar.UpdateHealth(life / maxLife);

            if (life <= 0)
                state = States.dead;
        }

        public void Attack() {

        }


    }
}