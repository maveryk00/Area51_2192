using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer { 
    public class Enemy : MonoBehaviour
    {
        private Animator animator;

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        void OnCollisionEnter2D(Collision2D collision) {
            BulletRock bullet =
                collision.gameObject.GetComponent<BulletRock>();

            if (bullet) {
                animator.SetBool("isdeath", true);
            }
        }

        public void OnDeath() {
            Spawner.Spawn();
            Destroy(gameObject);
        }
    }
}
