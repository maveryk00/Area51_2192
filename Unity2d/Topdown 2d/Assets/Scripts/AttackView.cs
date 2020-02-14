using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Topdown {
    public class AttackView : MonoBehaviour {
        private AttackModel model;

        void Awake() {
            model = GetComponent<AttackModel>();
        }
        void Start() {
            //UpdateIcon(model.currentAttack);
        }

        public void UpdateIcon(int type) {
            ElementType t = (ElementType)type;
            model.icon.sprite = model.sprites[t];
        }
    }
}
