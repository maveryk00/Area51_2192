using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    private float width;

    public RectTransform bar;
    public RectTransform barPoint;

    public float maxLife = 10;
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
        width = barPoint.sizeDelta.x;
        _currentLife = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void UpdateBar() {
        ClearLife();
        AddLife();
    }

    void ClearLife() {
        for (int i = 0; i < bar.childCount; i++)
            Destroy(bar.GetChild(i).gameObject);
    }

    void AddLife() {
        for (int i = 0; i < currentLife; i++) {
            RectTransform point = Instantiate<RectTransform>(barPoint);
            point.parent = bar;
            point.localScale = Vector3.one;
            point.localPosition = new Vector3(
                width * i,
                0,
                0);
        }
    }

    void RemoveLife() {
        Destroy(bar.GetChild(bar.childCount-1).gameObject);
    }

}
