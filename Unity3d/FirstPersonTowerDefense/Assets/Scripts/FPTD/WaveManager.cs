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
        public Wave currentWave;
        public State state = State.stop;

        // Start is called before the first frame update
        void Start() {
            StartWave();
        }

        // Update is called once per frame
        void Update() {
            if (state == State.play) {
                timer += Time.deltaTime;

                if (timer >= currentWave.delay) {
                    currentWave.Spawn();
                    timer = 0f;
                }

            }

        }

        public void StartWave() {
            currentWave = waves[currentIndex];

            state = State.play;
        }

        public void StopWave() {
            Debug.Log("Stop");
            state = State.stop;
        }

        public void NextWave() {
            currentIndex++;

            if (currentIndex >= waves.Count)
                return;

        }
    }
}