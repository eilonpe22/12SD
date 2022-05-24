using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    private Image bar;
    private float currentValue;
    private float maxValue;
    [SerializeField]
    private float offset;
    [SerializeField]
    private Color color;
    ShootScript shootScript;
    [SerializeField]
    private float ColorChangeSpeed;
    void Start()
    {

        bar = GetComponent<Image>();
        shootScript = FindObjectOfType<ShootScript>();
        maxValue = shootScript.timeToOverHeat;
    }

    // Update is called once per frame
    void Update()
    {
        currentValue = shootScript.overHeatTimer;
        bar.fillAmount = currentValue / maxValue;
        ColorChange();
    }
    void ColorChange()
    {
        if (currentValue / maxValue >= offset)
        {
            bar.color = Color.Lerp(bar.color, color, Time.deltaTime);
        }
        else
        {
            bar.color = Color.white;
        }
    }
}
