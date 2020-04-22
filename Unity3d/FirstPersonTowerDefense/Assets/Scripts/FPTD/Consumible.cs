using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class Consumible : Item {

        public Resources.Type type;
        public int amount;


        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        void OnTriggerEnter(Collider other) {
            if (other.tag == "Player") {
                Use();
                Destroy(gameObject);
            }
        }

        public override void Use() {
            GameManager.player.AddResource(type, amount);
        }
    }
}