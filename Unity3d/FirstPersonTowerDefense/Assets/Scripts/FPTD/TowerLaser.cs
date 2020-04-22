using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class TowerLaser : Tower {
        private TowerArea area;
        private List<Transform> projectilePoints;
        [SerializeField]
        private bool isActive = false;
        private Laser clon = null;

        [SerializeField]
        private Enemy target = null;
        [SerializeField]
        private Enemy nextTarget = null;

        public Transform turret;
        public Laser laser;

        // Start is called before the first frame update
        protected override void Start() {
            base.Start();

            GetProjectilePoints();


            area = GetComponentInChildren<TowerArea>();

            area.enemyEntersRange += OnEnemyEntersRange;
            area.enemyExitsRange += OnEnemyExitsRange;
        }

        // Update is called once per frame
        void Update() {
            if (target != null) {
                Aim();
            }
            else
                isActive = false;
        }


        void OnDrawGizmos() {
            if (target != null)
                Debug.DrawLine(transform.position, target.position, Color.green);
        }

        void OnDestroy() {
            area.enemyEntersRange -= OnEnemyEntersRange;
            area.enemyExitsRange -= OnEnemyExitsRange;
        }

        private void OnEnemyEntersRange(Enemy enemy) {
            if (target == null)
                target = enemy;
            else
                nextTarget = enemy;

            
        }

        private void OnEnemyExitsRange(Enemy enemy) {
            if (target == enemy)
                target = null;
            else if (nextTarget == enemy)
                nextTarget = null;


            if (nextTarget != null && target == null) {
                target = nextTarget;
                nextTarget = null;
                isActive = false;
            }


            if (target == null) {
                clon.Stop();
                isActive = false;
            }
            isActive = false;
        }


        private void GetProjectilePoints() {
            projectilePoints = new List<Transform>();

            foreach (Transform child in turret) {
                if (child.name.StartsWith("ProjectilePoint"))
                    projectilePoints.Add(child);
            }
        }

        public void Attack() {
            if (isActive) return;

            foreach (Transform projectilePoint in projectilePoints) {
                Debug.DrawLine(projectilePoint.position, target.targetable, Color.cyan);

                if (clon == null)
                    clon = Instantiate(laser, projectilePoint.position, projectilePoint.rotation);

                clon.origin = projectilePoint;
                clon.target = target.transform;
                clon.Init();
            }

            isActive = true;
        }

        public void Aim() {
            turret.LookAt(target.targetable);

            Attack();
        }

    }
}