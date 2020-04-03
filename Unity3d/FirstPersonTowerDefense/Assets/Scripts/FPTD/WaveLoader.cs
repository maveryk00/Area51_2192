using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FPTD {
    public class WaveLoader : MonoBehaviour {
        [System.Serializable]
        public struct WaveData {
            public string[] enemies;
            public int[] spawnOrder;
            public float delay;
        }

        public TextAsset waveJson;
        public WaveData waveData;

        public Wave wave;

        // Start is called before the first frame update
        void Start() {


        }

        // Update is called once per frame
        void Update() {

        }

        public void LoadJson() {
            waveData = JsonUtility.FromJson<WaveData>(waveJson.text);

            wave = gameObject.AddComponent<Wave>();

            wave.enemies = new List<Enemy>();
            foreach (string enemy in waveData.enemies)
                wave.enemies.Add(UnityEngine.Resources.Load<Enemy>("Enemies/" + enemy));

            wave.spawnOrder = new EnemyType[waveData.spawnOrder.Length];
            for (int i = 0; i < waveData.spawnOrder.Length; i++) {
                wave.spawnOrder[i] = (EnemyType)waveData.spawnOrder[i];
            }

            wave.delay = waveData.delay;

            wave.AddListener(GetComponent<WaveManager>().StopWave);
            //wave.finishEvent += GetComponent<WaveManager>().StopWave;

        }

    }
}
