using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class EnemyManager : MonoBehaviour {

        static public EnemyManager instance;

        public List<Enemy> enemies;

        // Start is called before the first frame update
        void Start() {
            instance = this;
        }

        // Update is called once per frame
        void Update() {

        }
    }
}
