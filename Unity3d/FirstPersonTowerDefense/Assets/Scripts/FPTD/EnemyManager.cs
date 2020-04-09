using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public enum EnemyType {
        Hoverbuggy,
        Hovercopter
    }

    public class EnemyManager : MonoBehaviour {

        static public EnemyManager instance;

        public Enemy[] prefabs;
        public List<Enemy> enemies;

        // Start is called before the first frame update
        void Start() {
            instance = this;
        }

        // Update is called once per frame
        void Update() {

        }

        public void SpawnEnemy(EnemyType type) {
            Enemy enemy = Instantiate(prefabs[(int)type]);
            enemies.Add(enemy);
        }

        public void RemoveEnemy(Enemy enemy) {
            enemies.Remove(enemy);
        }

    }
}
