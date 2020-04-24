using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    [RequireComponent(typeof(SphereCollider))]
    public class Explotion : MonoBehaviour {

        private SphereCollider sphere;

        [Range(0, 1f)]
        public float t = 0;

        public float speed = 1f;
        public float maxRadius = 5f;

        // Start is called before the first frame update
        void Start() {
            sphere = GetComponent<SphereCollider>();

            StartCoroutine(Exploit());
        }

        void OnDrawGizmos() {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, sphere.radius);
        }

        void OnTriggerEnter(Collider other) {
            Debug.Log(other.name);    
        }

        IEnumerator Exploit() {
            t = 0;
            while (t < 1f) {
                sphere.radius = Mathf.Lerp(0, maxRadius, t);

                t += speed;

                yield return new WaitForEndOfFrame();
            }

            sphere.radius = maxRadius;

        }
    }
}