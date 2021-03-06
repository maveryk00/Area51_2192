﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class Shop : MonoBehaviour {
        static private Shop instance;

        static public void OpenShop() {
            if (instance.canOpen)
                instance.Open();
        }

        static public bool isOpen {
            get {
                return !instance.canOpen;
            }
        }

        private Camera mainCamera;
        private bool buy = false;
        private GameObject ghost;

        private bool canOpen = true;

        public enum State {
            hide, show, place
        }
        public State state = State.hide;


        public GameObject mainPanel;
        public GameObject buyPanel;

        // Start is called before the first frame update
        void Start() {
            instance = this;

            Close();

            mainCamera = Camera.main;
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetKeyDown(KeyCode.T)) {
                Open();

            }



            switch (state) {
                case State.place:
                    buyPanel.SetActive(false);
                    PlaceTower();
                    break;
            }

        }

        private void PlaceTower() {
            if (Input.GetKeyDown(KeyCode.Mouse1)) {
                state = State.hide;
                Destroy(ghost);
                ghost = null;
                buyPanel.SetActive(true);
                return;
            }


            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10f)) {
                Debug.DrawLine(ray.origin, hit.point, Color.green);
                //ghost.GetComponent<TowerGhost>().UpdateMaterial(true);

                if (!buy) {
                    ghost.transform.position = hit.point;
                    //ghost.transform.LookAt(GameManager.player.transform);

                    float rot = Time.deltaTime * 100f;
                    ghost.transform.Rotate(Vector3.up * rot);


                    if (Input.GetKeyDown(KeyCode.Mouse0)) {
                        BuildTower();
                        GameManager.currentState = GameManager.State.play;
                    }
                }
            }
            else {
                Debug.DrawLine(ray.origin, ray.origin + (ray.direction * 10f), Color.red);
                //ghost.GetComponent<TowerGhost>().UpdateMaterial(false);
            }
        }

        private void BuildTower() {
            TowerGhost towerGhost = ghost.GetComponent<TowerGhost>();
            Tower tower = towerGhost.tower;
            if (towerGhost.isValid && GameManager.player.ConsumeGold(tower.cost))
                Instantiate(tower, ghost.transform.position, ghost.transform.rotation);


            buy = true;
            state = State.hide;
            Destroy(ghost);
            ghost = null;
            Close();
        }

        public void SelectTower(GameObject ghost) {
            this.ghost = Instantiate(ghost);

            ChangeState(2);
        }

        public void ChangeState(int state) {
            ChangeState((State)state);
        }

        public void ChangeState(State state) {
            this.state = state;

            switch (this.state) {
                case State.place:
                    buy = false;
                    break;
            }
        }

        public void Open() {
            mainPanel.SetActive(true);
            buyPanel.SetActive(false);

            state = State.show;
            canOpen = false;
            GameManager.currentState = GameManager.State.shop;
        }

        public void Close() {
            mainPanel.SetActive(false);
            buyPanel.SetActive(false);

            state = State.hide;

            StartCoroutine(DelayClose());

            GameManager.currentState = GameManager.State.play;
        }

        IEnumerator DelayClose() {
            yield return new WaitForEndOfFrame();
            canOpen = true;
        }
    }
}
