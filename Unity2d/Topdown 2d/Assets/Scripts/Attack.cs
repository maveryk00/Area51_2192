using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject fire;
    public GameObject ice;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Shoot(1);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            Shoot(2);
    }

    public void Shoot(int type) {
        switch (type) {
            case 1:
                Instantiate(fire, transform.position, Quaternion.identity);
                break;

            case 2:
                Instantiate(ice, transform.position, Quaternion.identity);
                break;
        }
    }
}
