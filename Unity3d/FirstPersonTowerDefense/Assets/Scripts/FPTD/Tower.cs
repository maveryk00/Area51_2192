using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class Tower : MonoBehaviour {

        private TowerTargetter targetter;
        private Transform projectilePoint;

        private float nextAttack = 0f;

        public int cost = 100;
        public Transform turret;
        public int hp;
        public float rate = 1f;
        public int upgradeCost = 300;
        public Bullet bullet;
        public int level = 1;

        // Start is called before the first frame update
        void Start() {
            targetter = GetComponentInChildren<TowerTargetter>();

            projectilePoint = turret.Find("ProjectilePoint");

            nextAttack = Time.time + rate;
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
        }

        public void Attack() {
            Instantiate<Bullet>(bullet, projectilePoint.position, projectilePoint.rotation);
        }

        public void Aim() {
            if (targetter.target != null) {
                turret.forward = (targetter.target.position - transform.position).normalized;
                //turret.LookAt(targetter.target.transform);
            }
        }

        public void Upgrade() { }

        public void Sell() { }

        public void Repair() { }
    }
}
