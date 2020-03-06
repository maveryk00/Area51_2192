using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class Player : MonoBehaviour {
        public float speed = 1f;
        public float torque = 100f;

        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            Vector3 pos = (
                transform.forward * Input.GetAxisRaw("Vertical")
                ) + (
                transform.right * Input.GetAxisRaw("Horizontal")
                );

            pos *= speed * Time.deltaTime;


            float angle = Input.GetAxis("Mouse X");
            angle *= torque * Time.deltaTime;

            transform.Rotate(
                Vector3.up,
                angle
                );

            transform.position +=  pos;
        }
    }
}