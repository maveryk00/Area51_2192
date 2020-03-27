using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class GameManager : MonoBehaviour {
        static private GameManager instance;

        static public Player player;

        static public State currentState {
            get {
                return instance.state;
            }

            set {
                instance.state = value;

                switch (instance.state) {
                    case State.shop:
                        Cursor.lockState = CursorLockMode.None;
                        break;

                    default:
                        Cursor.lockState = CursorLockMode.Locked;
                        break;
                }
            }
        }

        public enum State {
            play,
            pause,
            win,
            lose,
            shop
        }

        public State state = State.play;

        // Start is called before the first frame update
        void Start() {
            instance = this;

            //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player = GameObject.FindObjectOfType<Player>();


            currentState = State.play;
        }

        // Update is called once per frame
        void Update() {

        }
    }
}
