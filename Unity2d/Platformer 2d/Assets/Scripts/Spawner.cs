using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer {
    public class Spawner : MonoBehaviour {
        static private Spawner instance;

        static public void Spawn(float delay) {
            instance.Create(delay);
        }

        private Coroutine coroutine;

        public Enemy enemy;

        void Awake() {
            instance = this;
        }

        public void Create(float delay) {
            coroutine = StartCoroutine(CreateEnemy(delay));
            //StopCoroutine(coroutine);
        }
        
        private IEnumerator CreateEnemy(float delay) {
            yield return new WaitForSecondsRealtime(delay);
            Instantiate<Enemy>(enemy);
        }
 
    }
}