using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class Tower : MonoBehaviour {

        private TowerTargetter targetter;
        private List<Transform> projectilePoints;


        private float nextAttack = 0f;
        [SerializeField]
        private int currentHP = 0;

        public int cost = 100;
        public Transform turret;
        public int hp;
        public float rate = 1f;
        public int upgradeCost = 300;
        public Bullet bullet;
        public int level = 1;
        public Tower tower;

        // Start is called before the first frame update
        void Start() {
            targetter = GetComponentInChildren<TowerTargetter>();

            GetProjectilePoints();

            nextAttack = Time.time + rate;
            currentHP = hp;
        }

        // Update is called once per frame
        void Update() {
            Aim();

            if (targetter.target != null) {
                if (Time.time >= nextAttack) {
                    nextAttack = Time.time + rate;
                    Attack();
                }
            }

            if (currentHP <= 0)
                Destroy();



            if (Input.GetKeyDown(KeyCode.U)) {
                Upgrade();
            }

            if (Input.GetKeyDown(KeyCode.V))
                Sell();

            if (Input.GetKeyDown(KeyCode.R))
                Repair();

            if (Input.GetKeyDown(KeyCode.KeypadMinus))
                currentHP--;
        }


        private void GetProjectilePoints() {
            projectilePoints = new List<Transform>();

            foreach(Transform child in turret) {
                if (child.name.StartsWith("ProjectilePoint"))
                    projectilePoints.Add(child);
            }
        }

        public void Attack() {
            for (int i = 0; i < projectilePoints.Count; i++)
                Instantiate<Bullet>(bullet, projectilePoints[i].position, projectilePoints[i].rotation);
        }

        public void Aim() {
            if (targetter.target != null) {
                turret.forward = (targetter.target.position - transform.position).normalized;
                //turret.LookAt(targetter.target.transform);
            }
        }

        public void Upgrade() {
            level++;
            if (level > 3)
                return;

            Instantiate(tower, transform.position, transform.rotation);
            Destroy();
        }

        public void Sell() {
            Destroy();

        }

        public void Repair() {
            currentHP++;
            if (currentHP > hp)
                currentHP = hp;
        }

        public void Destroy() {
            Destroy(gameObject);

        }
    }
}
