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

            //Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
            if (cooldown >= 1f) {
                if (Input.GetAxisRaw("Mouse ScrollWheel") >= 0.1f) {
                    Debug.Log("Next");
                    inventory.Next();
                    inventory.SelectItem(inventory.currentItemIndex);
                    cooldown = 0;
                }
                else if (Input.GetAxis("Mouse ScrollWheel") <= -0.1f) {
                    Debug.Log("Prev");
                    inventory.Prev();
                    inventory.SelectItem(inventory.currentItemIndex);
                    cooldown = 0;
                }
            }
            else {
                cooldown += Time.deltaTime;
            }




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

        public bool Upgrade(int amount) {
            return resources.ConsumeResource(Resources.Type.gold, amount);
        }

    }
}