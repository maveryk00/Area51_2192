using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Image bar;
    public float maxLife = 50;
    public float currentLife;

    // Start is called before the first frame update
    void Start()
    {
        currentLife = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) {
            //bar.fillAmount -= 0.1f;
            currentLife--;
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            //bar.fillAmount += 0.1f;
            currentLife++;
        }

        currentLife = Mathf.Clamp(currentLife, 0, maxLife);
        bar.fillAmount = currentLife / maxLife;
    }
}
