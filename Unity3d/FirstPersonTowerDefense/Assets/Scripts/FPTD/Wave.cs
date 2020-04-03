using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FPTD {
    public class Wave : MonoBehaviour {
        private int currentIndex = -1;
        private FinishEvent call;

        public List<Enemy> enemies;
        public EnemyType[] spawnOrder;
        public float delay;

        //public UnityEvent finishEvent;
        public delegate void FinishEvent();
        public FinishEvent finishEvent;

        // Start is called before the first frame update
        void Start() {
            //finishEvent = new UnityEvent();
            //finishEvent.AddListener(call);
            finishEvent += call;
        }

        // Update is called once per frame
        void Update() {

        }

        public void Spawn() {
            currentIndex++;
            if (currentIndex >= spawnOrder.Length) {
                //if (finishEvent != null)
                //    finishEvent.Invoke();
                if (finishEvent != null)
                    finishEvent();

                return;
            }

            EnemyManager.instance.SpawnEnemy(spawnOrder[currentIndex]);
        }

        public void AddListener(FinishEvent call) {
            this.call = call;

        }

    }
}