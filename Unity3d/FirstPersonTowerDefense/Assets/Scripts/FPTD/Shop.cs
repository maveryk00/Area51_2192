using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class Shop : MonoBehaviour {
        private Camera mainCamera;
        private bool buy = false;

        public enum State {
            hide, show, place
        }
        public State state = State.hide;


        public GameObject mainPanel;
        public GameObject buyPanel;

        public GameObject ghost;
        
        // Start is called before the first frame update
        void Start() {
            mainPanel.SetActive(false);
            buyPanel.SetActive(false);

            mainCamera = Camera.main;
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetKeyDown(KeyCode.T))
                mainPanel.SetActive(true);


            switch (state) {
                case State.place:
                    buyPanel.SetActive(false);
                    PlaceTower();
                    break;
            }
            
        }

        private void PlaceTower() {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10f)) {
                Debug.DrawLine(ray.origin, hit.point, Color.green);

                if (!buy) {
                    ghost.transform.position = hit.point;

                    if (Input.GetKeyDown(KeyCode.Mouse0)) {
                        buy = true;
                        state = State.hide;
                    }
                }
            }
            else
                Debug.DrawLine(ray.origin, ray.origin + (ray.direction * 10f), Color.red);
        }

        public void ChangeState(int state) {
            this.state = (State)state;
        }
    }
}
