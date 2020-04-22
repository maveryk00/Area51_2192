using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class Tool : Item {

        public int level = 1;
        public float range = 3f;


        // Start is called before the first frame update
        void Start() {
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                Shop.OpenShop();
            }

            if (Input.GetKey(KeyCode.Mouse1) && !Shop.isOpen)
                Use();
        }

        void OnDrawGizmos() {
            Gizmos.DrawWireSphere(transform.parent.parent.position, range);
        }

        override public void Use() {
            Repair();
        }

        public void Repair() {
            Tower tower = TowerManager.ClosestTo(GameManager.player.transform.position);

            if (Vector3.Distance(tower.transform.position, GameManager.player.transform.position) <= range)
                tower.Repair();
        }

    }
}