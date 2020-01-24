using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer {
    public class SpawnController {
        static private SpawnController _instance;
        static public SpawnController instance {
            get {
                if (_instance == null)
                    _instance = new SpawnController();
                
                return _instance;
            }
        }

        static public void Create() {
            Spawner.Spawn(5f);
        }
        

       
    }
}