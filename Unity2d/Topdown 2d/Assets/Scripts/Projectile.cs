using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Topdown {
    public class Projectile : MonoBehaviour {

        public ElementType type = ElementType.fire;

        public float speed = 1f;

        // Start is called before the first frame update
        void Start() {
            Destroy(gameObject, 5f);
        }

        // Update is called once per frame
        void Update() {
            transform.position += new Vector3(speed * Time.deltaTime,0,0);
        }
    }
}