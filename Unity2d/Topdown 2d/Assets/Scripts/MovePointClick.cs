using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Topdown {
    public class MovePointClick : MonoBehaviour {
        public enum State {
            idle, move
        }
        
        private Camera mainCamera;
        [SerializeField]
        private State state = State.idle;

        public float speed = 1f;

        // Start is called before the first frame update
        void Start() {
            mainCamera = Camera.main;
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetMouseButtonDown(0) &&
                state == State.idle) {
                Vector3 pos =
                mainCamera.ScreenToWorldPoint(
                    Input.mousePosition
                );
                pos.z = 0;

                StopAllCoroutines();
                StartCoroutine(Move(pos));
            }
        }

        IEnumerator Move(Vector3 target) {
            state = State.move;
            float distance = 
                Vector3.Distance(
                    transform.position,
                    target
                ) ;


            Vector3 direction = target - transform.position;
            direction.Normalize();

            while (distance > 0.05f) {
                transform.position +=
                    direction * speed * Time.deltaTime;

                distance = Vector3.Distance(
                    transform.position,
                    target
                );
                yield return new WaitForEndOfFrame();
            }

            transform.position = target;
            state = State.idle;
        }
    }
}