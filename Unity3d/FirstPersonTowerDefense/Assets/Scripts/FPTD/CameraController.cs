using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class CameraController : MonoBehaviour {

        public bool invert = false;
        public float smooth = 10f;

        private float angleX;

        // Start is called before the first frame update
        void Start() {
            
            
        }

        void LateUpdate() {
            if (GameManager.currentState == GameManager.State.shop)
                return;

            float angle = Input.GetAxis("Mouse Y");
            angle *= smooth * Time.deltaTime;

            if (invert)
                angle *= -1;

            angleX += angle;
            angleX = Mathf.Clamp(angleX, -60f, 60f);

            transform.localRotation = Quaternion.Euler(
                Vector3.right * angleX);

        }
    }
}