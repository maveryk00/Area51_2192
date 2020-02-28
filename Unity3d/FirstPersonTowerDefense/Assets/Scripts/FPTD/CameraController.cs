using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class CameraController : MonoBehaviour {

        public bool invert = false;
        public float smooth = 10f;

        // Start is called before the first frame update
        void Start() {
            
            
        }

        void LateUpdate() {
            float angle = Input.GetAxis("Mouse Y");
            angle *= smooth * Time.deltaTime;

            if (invert)
                angle *= -1;

            transform.Rotate(
                Vector3.right, 
                angle
                );

            
        }
    }
}