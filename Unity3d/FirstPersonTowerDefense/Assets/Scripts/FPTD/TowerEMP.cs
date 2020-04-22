using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class TowerEMP : Tower {
        private TowerArea area;

        [Range(0.1f, 1f)]
        public float slowFactor = 1f;

        public GameObject slowFX;

        // Start is called before the first frame update
        protected override void Start() {
            base.Start();

            area = GetComponentInChildren<TowerArea>();

            area.enemyEntersRange += OnEnemyEntersRange;
            area.enemyExitsRange += OnEnemyExitsRange;
        }

        // Update is called once per frame
        void Update() {

        }

        void OnDestroy() {
            area.enemyEntersRange -= OnEnemyEntersRange;
            area.enemyExitsRange -= OnEnemyExitsRange;
        }

        private void OnEnemyEntersRange(Enemy enemy) {
            enemy.speedMult = slowFactor;

            GameObject fx = Instantiate(slowFX, enemy.transform);
            fx.name = "SlowFX";
            fx.transform.localPosition = Vector3.zero;

            Vector3 scale = fx.transform.localScale;
            scale.x /= enemy.transform.localScale.x;
            scale.y /= enemy.transform.localScale.y;
            scale.z /= enemy.transform.localScale.z;

            fx.transform.localScale = scale; 
        }

        private void OnEnemyExitsRange(Enemy enemy) {
            enemy.speedMult = 1f;

            GameObject fx = enemy.transform.Find("SlowFX").gameObject;
            Destroy(fx);
        }
    }
}