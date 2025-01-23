using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "PlayerHealth", menuName = "PlayerLevelAndHealth")]
public class PlayerLevelAndHealth : ScriptableObject
{
    public int PlayerHeal;
    public int PlayerDamage;
    public int PlayerMaxHP;
    public float PlayerXpProgress;
    public float PlayerXp;


    public bool level2;
    public bool level3;
    public bool level4;
    public bool level5;
}
