using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Topdown {
    public class AttackController : MonoBehaviour {
        private AttackModel model;

        // Start is called before the first frame update
        void Awake() {
            model = GetComponent<AttackModel>();
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetKeyDown(KeyCode.KeypadMinus))
                model.currentAttack--;

            if (Input.GetKeyDown(KeyCode.KeypadPlus))
                model.currentAttack++;


            if (Input.GetKeyDown(KeyCode.Space))
                Shoot(model.currentAttack);
        }

        public void Shoot(int type) {
            ElementType t = (ElementType)type;
            Shoot(t);
        }

        public void Shoot(ElementType type) {
            Instantiate(model.attacks[type], transform.position, Quaternion.identity);
        }
    }
}
