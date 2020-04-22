using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class Gun : Item {
        private float nextAttack = 0f;

        public int dmg = 3;
        public float rate = 1f;
        public Transform muzzle;
        public Bullet bullet;

        // Start is called before the first frame update
        void Start() {
            nextAttack = Time.time + rate;
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetKey(KeyCode.Mouse0))
                Use();   
        }

        public override void Use() {
            if (Time.time >= nextAttack) {
                nextAttack = Time.time + rate;
                Instantiate<Bullet>(bullet, muzzle.position, muzzle.rotation);
            }
        }
    }
}