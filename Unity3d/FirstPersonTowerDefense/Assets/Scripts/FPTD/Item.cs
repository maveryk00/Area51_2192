using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class Item : MonoBehaviour {
        public string description;
        
        // Start is called before the first frame update
        void Start() {
        }

        // Update is called once per frame
        void Update() {

        }

        public void SetActive(bool value) {
            gameObject.SetActive(value);
        }

        virtual public void Use() { }
    }
}