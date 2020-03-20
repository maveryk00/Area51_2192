using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class TowerTargetter : MonoBehaviour {

        public float range = 5f;

        public Enemy target;

        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            target = GetTarget();

            if (target != null)
                Debug.DrawLine(transform.position, target.position, Color.green);

        }

        void OnDrawGizmosSelected() {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, range);
        }

        Enemy GetTarget() {
            Enemy enemy = null;

            foreach (Enemy e in EnemyManager.instance.enemies) {
                float distance = Vector3.Distance(transform.position, e.position);
                if (distance <= range) {
                    enemy = e;
                    break;
                }
                   
            }

            return enemy;
        }

    }
}