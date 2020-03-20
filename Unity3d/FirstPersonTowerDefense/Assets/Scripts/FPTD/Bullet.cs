using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class Bullet : MonoBehaviour {

        public float speed = 1f;
        public int dmg = 1;
        public float lifeTime = 1f;

        public ParticleSystem particle;

        // Start is called before the first frame update
        void Start() {
            Destroy(gameObject, lifeTime);
        }

        // Update is called once per frame
        void Update() {
            Move();
        }

        void OnCollisionEnter(Collision collision) {
            ParticleSystem p = Instantiate(particle, transform.position, transform.rotation);

            Destroy(gameObject);
        }

        public void Move() {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        public void Destroy() { }
    }
}
