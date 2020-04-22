using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class TowerMachineGun : Tower {
        private TowerTargetter targetter;
        private List<Transform> projectilePoints;
        private float nextAttack = 0f;

        public Transform turret;
        public float rate = 1f;
        public Bullet bullet;


        // Start is called before the first frame update
        protected override void Start() {
            base.Start();
            targetter = GetComponentInChildren<TowerTargetter>();

            GetProjectilePoints();
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

        private void GetProjectilePoints() {
            projectilePoints = new List<Transform>();

            foreach (Transform child in turret) {
                if (child.name.StartsWith("ProjectilePoint"))
                    projectilePoints.Add(child);
            }
        }

        public void Attack() {
            for (int i = 0; i < projectilePoints.Count; i++) {
                Instantiate<Bullet>(bullet, projectilePoints[i].position, projectilePoints[i].rotation);
                Debug.DrawLine(projectilePoints[i].position, targetter.target.targetable, Color.yellow);
                //Debug.Break();
            }
        }

        public void Aim() {
            if (targetter.target != null) {
                //turret.forward = (targetter.target.position - transform.position).normalized;
                turret.LookAt(targetter.target.targetable);
            }
        }
    }
}