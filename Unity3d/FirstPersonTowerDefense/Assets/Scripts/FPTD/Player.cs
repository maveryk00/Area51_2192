using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class Player : MonoBehaviour {
        private float cooldown = 0;

        public float speed = 1f;
        public float torque = 100f;

        public Inventory inventory;
        public Resources resources;

        public Vector3 position {
            get {
                return transform.position;
            }
        }

        // Start is called before the first frame update
        void Start() {
            //inventory = new Inventory();

            inventory.SelectItem(0);

            resources = new Resources();
        }

        // Update is called once per frame
        void Update() {
            Movement();

            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                inventory.SelectItem(0);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2)) {
                inventory.SelectItem(1);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3)) {
                inventory.SelectItem(2);
            }

            //Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
            if (cooldown >= 1f) {
                if (Input.GetAxisRaw("Mouse ScrollWheel") >= 0.1f) {
                    inventory.Next();
                    inventory.SelectItem(inventory.currentItemIndex);
                    cooldown = 0;
                }
                else if (Input.GetAxis("Mouse ScrollWheel") <= -0.1f) {
                    inventory.Prev();
                    inventory.SelectItem(inventory.currentItemIndex);
                    cooldown = 0;
                }
            }
            else {
                cooldown += Time.deltaTime;
            }

        }

        public GUIStyle style = new GUIStyle();
        void OnGUI() {
            GUILayout.Label("GOLD: " + resources.gold, style);
            GUILayout.Label("METAL: " + resources.metal, style);
        }


        private void Movement() {
            Vector3 pos = (
                transform.forward * Input.GetAxisRaw("Vertical")
                ) + (
                transform.right * Input.GetAxisRaw("Horizontal")
                );

            pos *= speed * Time.deltaTime;


            float angle = Input.GetAxis("Mouse X");
            angle *= torque * Time.deltaTime;

            if (GameManager.currentState == GameManager.State.play)
                transform.Rotate(Vector3.up, angle);

            transform.position += pos;
        }

        public void AddGold(int amount) {
            resources.AddResource(Resources.Type.gold, amount);
        }

        public void AddMetal(int amount) {
            resources.AddResource(Resources.Type.metal, amount);
        }

        public void AddResource(Resources.Type type, int amount) {
            resources.AddResource(type, amount);
        }

        public bool ConsumeGold(int amount) {
            return resources.ConsumeResource(Resources.Type.gold, amount);
        }

        public bool Upgrade(int amount) {
            return resources.ConsumeResource(Resources.Type.gold, amount);
        }

    }
}