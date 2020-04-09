using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class EnemyHealthBar : MonoBehaviour {

        private Transform mainCamera;

        public Transform healthBar;
        public Transform backgroundBar;

        // Start is called before the first frame update
        void Start() {
            mainCamera = Camera.main.transform;
        }

        // Update is called once per frame
        void Update() {
            Vector3 direction = mainCamera.forward;
            transform.forward = -direction;
        }

        public void UpdateHealth(float normalizedHealth) {
            Vector3 scale = Vector3.one;

            if (healthBar != null) {
                scale.x = normalizedHealth;
                healthBar.transform.localScale = scale;
            }

            if (backgroundBar != null) {
                scale.x = 1 - normalizedHealth;
                backgroundBar.transform.localScale = scale;
            }
        }
    }
}