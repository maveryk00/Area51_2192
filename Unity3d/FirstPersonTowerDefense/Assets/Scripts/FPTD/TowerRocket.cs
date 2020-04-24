using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class TowerRocket : Tower {
        private TowerTargetter targetter;
        private List<Transform> projectilePoints;
        private float nextAttack = 0f;
        private int currentPoint = 0;
        private bool canShoot = true;

        public Transform turret;
        public float rate = 1f;
        public float reload = 5f;
        public Rocket rocket;

        // Start is called before the first frame update
        protected override void Start() {
            base.Start();
            targetter = GetComponentInChildren<TowerTargetter>();

            GetProjectilePoints();
            nextAttack = Time.time + rate;
        }

        // Update is called once per frame
        void Update() {
           

            if (targetter.target != null) {
                if (canShoot) {
                    Aim();

                    if (Time.time >= nextAttack) {
                        nextAttack = Time.time + rate;
                        Attack();
                    }
                }
                else {
                    if (Time.time >= nextAttack - rate + reload) {
                        nextAttack = Time.time + rate;
                        canShoot = true;
                    }
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
            Rocket clone = Instantiate(rocket, projectilePoints[currentPoint].position, projectilePoints[currentPoint].rotation);
            clone.start = projectilePoints[currentPoint].position;
            clone.end = targetter.target.targetable;

            Debug.DrawLine(projectilePoints[currentPoint].position, targetter.target.targetable, Color.yellow);

            currentPoint++;

            if (currentPoint >= projectilePoints.Count) {
                currentPoint = 0;
                canShoot = false;
            }
                
        }

        public void Aim() {
            Vector3 pos = targetter.target.targetable;
            pos.y = turret.position.y;
            turret.LookAt(pos);
        }
    }
}