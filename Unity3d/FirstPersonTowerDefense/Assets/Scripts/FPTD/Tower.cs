using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class Tower : MonoBehaviour {

        
        private int currentHP = 0;

        public int cost = 100;
        public int hp;
        
        public int upgradeCost = 300;
        
        public int level = 1;
        public Tower tower;

        // Start is called before the first frame update
        protected virtual void Start() {
            TowerManager.Add(this);
            
            currentHP = hp;
        }

        // Update is called once per frame
        void Update() {
            
            if (currentHP <= 0)
                Destroy();



            //if (Input.GetKeyDown(KeyCode.U)) {
            //    Upgrade();
            //}

            //if (Input.GetKeyDown(KeyCode.V))
            //    Sell();

            //if (Input.GetKeyDown(KeyCode.R))
            //    Repair();

            //if (Input.GetKeyDown(KeyCode.KeypadMinus))
            //    currentHP--;
        }



        public void Upgrade() {
            if (!GameManager.player.Upgrade(upgradeCost))
                return;

            level++;
            if (level > 3)
                return;

            Instantiate(tower, transform.position, transform.rotation);
            Destroy();
        }

        public void Sell() {
            GameManager.player.AddGold(cost / 2);
            Destroy();

        }

        public void Repair() {
            currentHP++;
            if (currentHP > hp)
                currentHP = hp;
        }

        public void Destroy() {
            TowerManager.Remove(this);
            Destroy(gameObject);

        }
    }
}
