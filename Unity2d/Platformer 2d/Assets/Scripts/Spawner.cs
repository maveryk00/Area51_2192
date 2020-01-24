using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer {
    public class Spawner : MonoBehaviour {
        static private Spawner instance;

        static public void Spawn() {
            instance.Create();
        }


        public Enemy enemy;

        void Awake() {
            instance = this;
        }

        public void Create() {
            Instantiate<Enemy>(enemy);
        }
        
 
    }
}