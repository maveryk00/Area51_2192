using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Topdown {
    public class Move : MonoBehaviour {

        public float speed = 1f;

        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            transform.position += new Vector3(0, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0);
        }
    }
}