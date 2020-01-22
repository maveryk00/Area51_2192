using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer;

public class Level2Manager : MonoBehaviour
{
    public Transform startPos;


    // Start is called before the first frame update
    void Start()
    {
        //Player.instance.transform.position = startPos.position;
        //Player.setPosition = startPos.position;
        Player.setPosition2 = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
