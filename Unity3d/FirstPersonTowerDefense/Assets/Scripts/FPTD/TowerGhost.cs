using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class TowerGhost : MonoBehaviour {
        [SerializeField]
        private List<MeshRenderer> renderers;
        
        public Tower tower;

        public Material valid;
        public Material invalid;

        // Start is called before the first frame update
        void Start() {
            foreach(Transform child in transform) {
                MeshRenderer renderer = child.GetComponent<MeshRenderer>();
                if (renderer != null) {
                    renderers.Add(renderer);
                }
            }
        }

        // Update is called once per frame
        void Update() {

        }

        public void UpdateMaterial(bool valid) {
            foreach (MeshRenderer renderer in renderers) {
                renderer.material = valid ? this.valid : this.invalid;
            }
        }

    }
}
