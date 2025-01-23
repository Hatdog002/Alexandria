using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpSlider : MonoBehaviour
{
    int progress;
    public Slider slider;

    Unit PlayerHp;
    public GameObject Player;


    public Color backgroundColorRed;
    public Color fillColorRed;

    public Color backgroundColorGreen;
    public Color fillColorGreen;
    public void Start()
    {
        PlayerHp = Player.GetComponent<Unit>();
        slider.maxValue = PlayerHp.MaxHp;
        progress = PlayerHp.currentHp;
    }
    public void Update()
    {
        progress = PlayerHp.currentHp;
        slider.value = progress;

        if(progress <= 25)
        {
            Image backgroundImage = slider.GetComponentInChildren<Image>();
            backgroundImage.color = backgroundColorRed;

            Image fillImage = slider.fillRect.GetComponent<Image>();
            fillImage.color = fillColorRed;
        }
        else
        {
            Image backgroundImage = slider.GetComponentInChildren<Image>();
            backgroundImage.color = backgroundColorGreen;

            Image fillImage = slider.fillRect.GetComponent<Image>();
            fillImage.color = fillColorGreen;
        }
    }
    
}
