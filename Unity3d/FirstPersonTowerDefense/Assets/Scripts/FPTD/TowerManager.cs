using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class TowerManager : MonoBehaviour {
        static private TowerManager instance;

        static public void Add(Tower tower) {
            instance.AddTower(tower);
        }

        static public void Remove(Tower tower) {
            instance.RemoveTower(tower);
        }

        static public Tower ClosestTo(Vector3 point) {
            return instance.Closest(point);
        }

        [SerializeField]
        private List<Tower> towers;

        
        void Awake() {
            instance = this;
        }

        // Update is called once per frame
        void Update() {

        }

        public void AddTower(Tower tower) {
            towers.Add(tower);
        }

        public void RemoveTower(Tower tower) {
            towers.Remove(tower);
        }

        public Tower Closest(Vector3 point) {
            float minDistance = Mathf.Infinity; //float.MaxValue;
            Tower tower = null;

            foreach (Tower t in towers) {
                float distance = Vector3.Distance(t.transform.position, point);
                if (distance < minDistance) {
                    minDistance = distance;
                    tower = t;
                }
            }

            return tower;
        }
    }
}