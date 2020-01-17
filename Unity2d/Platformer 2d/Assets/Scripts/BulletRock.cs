using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRock : MonoBehaviour
{
    public float speed = 5f;
    public float lifeTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    public void Init(float speed) {
        this.speed = speed;
    }
}
