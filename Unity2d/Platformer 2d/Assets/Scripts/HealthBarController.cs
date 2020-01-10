using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    private float minScale = 0f;
    private float maxScale = 30f;

    public RectTransform barMiddle;
    public RectTransform barEnd;

    public float maxLife = 50;
    public float _currentLife;

    public float currentLife {
        set {
            _currentLife = Mathf.Clamp(value, 0, maxLife);
            UpdateBar();
        }

        get {
            return _currentLife;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentLife = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateBar() {
        float percentLife = _currentLife / maxLife;
        float percentScale = maxScale * percentLife;

        Vector3 scale = barMiddle.localScale;
        scale.x = Mathf.Clamp(percentScale, minScale, maxScale);
        Vector3 pos = barEnd.localPosition;
        pos.x = barMiddle.localPosition.x + 
                    (barMiddle.sizeDelta.x * scale.x);
        barEnd.localPosition = pos;
        
        barMiddle.localScale = scale;
    }

    //public void SetLife(float life) {
    //    _currentLife = life;
    //    UpdateBar();
    //}

}
