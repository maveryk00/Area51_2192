using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FPTD {
    public class WaveLoader : MonoBehaviour {
        [System.Serializable]
        public struct WaveData {
            public WaveInfo[] waves;
        }
        [System.Serializable]
        public struct WaveInfo {
            public string[] enemies;
            public int[] spawnOrder;
            public float spawnDelay;
            public float startDelay;
        }


        public TextAsset waveJson;
        public WaveData waveData;



        // Start is called before the first frame update
        void Start() {


        }

        // Update is called once per frame
        void Update() {

        }

        public void LoadJson() {
            waveData = JsonUtility.FromJson<WaveData>(waveJson.text);

            WaveManager manager = GetComponent<WaveManager>();
            manager.waves = new List<Wave>();

            DeleteAllWaves();

            for (int i = 0; i < waveData.waves.Length; i++)
                manager.waves.Add(CreateWave(waveData.waves[i], manager));

        }

        private Wave CreateWave(WaveInfo info, WaveManager manager) {
            Wave wave = gameObject.AddComponent<Wave>();

            wave.enemies = new List<Enemy>();
            foreach (string enemy in info.enemies)
                wave.enemies.Add(UnityEngine.Resources.Load<Enemy>("Enemies/" + enemy));

            wave.spawnOrder = new EnemyType[info.spawnOrder.Length];
            for (int i = 0; i < info.spawnOrder.Length; i++) {
                wave.spawnOrder[i] = (EnemyType)Enum.Parse(typeof(EnemyType), info.enemies[info.spawnOrder[i]]);
            }

            wave.spawnDelay = info.spawnDelay;
            wave.startDelay = info.startDelay;

            wave.AddWaveManager(manager);

            return wave;
        }

        private void DeleteAllWaves() {
            Wave[] waves = GetComponents<Wave>();

            foreach (Wave w in waves)
                DestroyImmediate(w);
        }

    }
}
