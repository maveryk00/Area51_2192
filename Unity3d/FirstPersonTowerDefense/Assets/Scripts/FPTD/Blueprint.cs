using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class Blueprint : Item {
        public enum Shape {
            sphere, cube
        }

        public Shape shape = Shape.sphere;
        public float range = 3f;
        public Vector3 offset;
        public Transform point;

        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                Debug.Log("Upgrade");
                Upgrade();
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1)) {
                Debug.Log("Sell");
                Sell();
            }
        }

        public void Upgrade() {
            Tower tower = TowerManager.ClosestTo(GameManager.player.position);

            if (Vector3.Distance(tower.transform.position, GameManager.player.position) <= range)
                tower.Upgrade();
        }

        public void Sell() {
            Tower tower = TowerManager.ClosestTo(GameManager.player.position);

            if (Vector3.Distance(tower.transform.position, point.position) <= range)
                tower.Sell();
        }

        void OnDrawGizmos() {
            Vector3 pos =  point.position;
            pos += offset;
            //pos = transform.parent.parent.rotation * pos;
            //Gizmos.matrix = transform.parent.parent.;
            Gizmos.color = Color.magenta;

            switch (shape) {
                case Shape.sphere:
                    Gizmos.DrawWireSphere(pos, range * 0.5f);
                    break;

                case Shape.cube:
                    Gizmos.DrawWireCube(pos, Vector3.one * range);
                    break;
            }

        }
    }
}