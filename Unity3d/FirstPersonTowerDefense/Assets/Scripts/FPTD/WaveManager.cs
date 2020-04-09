using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class WaveManager : MonoBehaviour {

        public enum State {
            play, stop
        }

        private float timer;

        public List<Wave> waves;
        public int currentIndex;
        public State state = State.stop;

        public Wave currentWave {
            get {
                return waves[currentIndex];
            }
        }

        // Start is called before the first frame update
        void Start() {
            StartWave();
        }

        // Update is called once per frame
        void Update() {
            if (state == State.play) {
                timer += Time.deltaTime;

                if (timer >= currentWave.spawnDelay) {
                    currentWave.Spawn();
                    timer = 0f;
                }

            }

        }

        public void StartWave() {

            StartCoroutine(StartDelay());
            
        }

        public void StopWave() {
            state = State.stop;

            NextWave();
        }

        public void NextWave() {
            currentIndex++;

            if (currentIndex >= waves.Count)
                return;

            StartWave();
        }

        private IEnumerator StartDelay() {
            yield return new WaitForSecondsRealtime(currentWave.spawnDelay);
            state = State.play;
        }
    }
}