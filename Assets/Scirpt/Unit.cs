using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int adddamage;
    public int Heal;
    public int MaxHp;
    public int currentHp;

    public int damage;
  
    public PlayerLevelAndHealth data;
    public void Start()
    {
        adddamage = 0;
        MaxHp = data.PlayerMaxHP;
        Heal = data.PlayerHeal;
        currentHp = MaxHp;
        damage = data.PlayerDamage;
    }

    public void LevelUp()
    {
        damage = data.PlayerDamage + adddamage;
        MaxHp = data.PlayerMaxHP;
        Heal = data.PlayerHeal;
    }
    public bool TakeDamage(int dmg)
    {
        currentHp -= dmg;

        if (currentHp <= 0)
        {
            currentHp = 0;
            return true;
        }
        else
            return false;
    }

    public void Reset()
    {
        currentHp = MaxHp;
    }

    public bool HealPlayer(int heal)
    {
        currentHp += heal;

        // Ensure currentHp does not exceed 50
        if (currentHp > MaxHp)
        {
            currentHp = MaxHp;
        }

        // Check if currentHp is 0 or less (death condition)
        if (currentHp <= 0)
        {
            return true; // Player is dead
        }

        return false; // Player is alive
    }
}