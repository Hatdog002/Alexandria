using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DebugSettings : MonoBehaviour
{
    public PlayerMovementTutorial movement;

    public TextMeshProUGUI txtrun;
    public TextMeshProUGUI txtwalk;
    public TextMeshProUGUI txtdmg;
    public TextMeshProUGUI txthp;

    public GameObject Player;
    public BattleHud MainHud;
    Unit PlayerUnit;

    public void Start()
    {
        PlayerUnit = Player.GetComponent<Unit>();
    }

    public void Update()
    {
        MainHud.SetHp(PlayerUnit.currentHp);
        txtrun.text = movement.runningSpeed.ToString();
        txtwalk.text = movement.walkingSpeed.ToString();
        txtdmg.text = PlayerUnit.damage.ToString();
        txthp.text = PlayerUnit.currentHp.ToString();
    }
    public void Run()
    {
        movement.runningSpeed += 1;
    }

    public void Walk()
    {
        movement.walkingSpeed += 1;
    }


    public void DMG()
    {
        PlayerUnit.adddamage += 10;
    }

    public void HP()
    {
        PlayerUnit.currentHp += 10;
    }

    public void MRun()
    {
        movement.runningSpeed -= 1;
    }

    public void MWalk()
    {
        movement.walkingSpeed -= 1;
    }


    public void MDMG()
    {
        PlayerUnit.adddamage -= 10;
    }

    public void MHP()
    {
        PlayerUnit.currentHp -= 10;
    }
}
