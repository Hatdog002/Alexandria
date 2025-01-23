using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BattleHud : MonoBehaviour
{
    private float progress;
    public Slider slider;

    public TextMeshProUGUI Hp;

    public Sprite newFillSpriteGreen;
    public Sprite newFillSprite;
   
    public void SetHUD(Unit unit)
    {
        Hp.text = unit.currentHp.ToString();
        slider.maxValue = unit.MaxHp;
        progress = unit.currentHp;
        slider.value = progress;
    }

    public void SetHp(int Health)
    {
        Hp.text = Health.ToString();
        progress = Health;
        slider.value = progress;
        Debug.Log("CurrentHp" + progress);
    }

    public void Update()
    {
       
        Debug.Log(slider.value);
        if (slider.value <= 15)
        {
            Image fillImage = slider.fillRect.GetComponent<Image>();
            fillImage.sprite = newFillSprite;
        }
        else
        {
            Image fillImage = slider.fillRect.GetComponent<Image>();
            fillImage.sprite = newFillSpriteGreen;
        }
    }
}
