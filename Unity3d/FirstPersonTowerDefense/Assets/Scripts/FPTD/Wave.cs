using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FPTD {
    public class Wave : MonoBehaviour {
        private int currentIndex = -1;
        public WaveManager manager;

        public List<Enemy> enemies;
        public EnemyType[] spawnOrder;
        public float spawnDelay;
        public float startDelay;

        private UnityEvent finishEvent;

        // Start is called before the first frame update
        void Start() {
            finishEvent = new UnityEvent();
            finishEvent.AddListener(Stop);
        }
        
        void Stop() {
            manager.StopWave();
        }

        // Update is called once per frame
        void Update() {

        }

        public void Spawn() {
            currentIndex++;
            if (currentIndex >= spawnOrder.Length) {
                if (finishEvent != null)
                    finishEvent.Invoke();

                return;
            }

            EnemyManager.instance.SpawnEnemy(spawnOrder[currentIndex]);
        }

        public void AddWaveManager(WaveManager manager) {
            this.manager = manager;
        }

    }
}