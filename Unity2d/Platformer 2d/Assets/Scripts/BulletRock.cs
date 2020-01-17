using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer {
    public class BulletRock : MonoBehaviour {
        public enum Direction {
            left = -1,
            right = 1
        }
        public Direction direction = Direction.right;

        public float speed = 5f;
        public float lifeTime = 3f;

        // Start is called before the first frame update
        void Start() {
            Destroy(gameObject, lifeTime);
        }

        // Update is called once per frame
        void Update() {
            Vector3 pos = ((int)direction * Vector3.right)
                * speed * Time.deltaTime;

            transform.position += pos;

        }

        public void Init(float speed) {
            this.speed = speed;
        }

        public void Init(Direction direction) {
            this.direction = direction;
            //spriteRenderer.flipX = direction == Direction.left
        }
    }
}
