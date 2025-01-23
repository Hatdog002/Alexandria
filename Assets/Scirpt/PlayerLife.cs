using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public BattleHud MainPlayer;

    public GameObject Player;

    Unit PlayerUnit;

    public void Start()
    {
        GameObject playerHp = Player;
        PlayerUnit = playerHp.GetComponent<Unit>();
        MainPlayer.SetHUD(PlayerUnit);
    }
    public void Update()
    {
        MainPlayer.SetHUD(PlayerUnit);
        MainPlayer.SetHp(PlayerUnit.currentHp);
    }
}
