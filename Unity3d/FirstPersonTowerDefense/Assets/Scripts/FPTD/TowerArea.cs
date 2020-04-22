using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    [RequireComponent(typeof(CapsuleCollider))]
    public class TowerArea : MonoBehaviour {

        private Collider area;

        public event Action<Enemy> enemyEntersRange;
        public event Action<Enemy> enemyExitsRange;

        // Start is called before the first frame update
        void Start() {
            area = GetComponent<Collider>();
            area.isTrigger = true;
        }

        // Update is called once per frame
        void Update() {

        }

        void OnTriggerEnter(Collider other) {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            if (enemy != null && enemyEntersRange != null)
                enemyEntersRange(enemy);
        }

        void OnTriggerExit(Collider other) {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            if (enemy != null && enemyExitsRange != null)
                enemyExitsRange(enemy);
        }
    }
}