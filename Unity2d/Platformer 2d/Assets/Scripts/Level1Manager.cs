using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    public HealthBarController healthBar;

    // Start is called before the first frame update
    void Start()
    {
        Player.HealthBar = healthBar;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
