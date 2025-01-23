using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPchecks : MonoBehaviour
{
    public EnemyChecker enemy;

    public bool[] CEnemy;

    public bool KeyEnemy;

    public bool heal;
    // Start is called before the first frame update
    void Start()
    {
        if (enemy.Enemy1)
        {
            CEnemy[0] = true;
            KeyEnemy = false;
            heal = false;
        }
        if (enemy.Enemy2)
        {
            CEnemy[1] = true;
            KeyEnemy = false;
            heal = false;
        }
        if (enemy.Enemy3)
        {
            CEnemy[2] = true;
            KeyEnemy = false;
            heal = false;
        }

        if (enemy.Enemy1 && enemy.EnemyKey)
        {
            CEnemy[0] = true;
            KeyEnemy = true;
        }

        if (enemy.Enemy2 && enemy.EnemyKey)
        {
            CEnemy[1] = true;
            KeyEnemy = true;
        }

        if (enemy.Enemy3 && enemy.EnemyKey)
        {
            CEnemy[2] = true;
            KeyEnemy = true;
        }


        if (enemy.Enemy1 && enemy.heal)
        {
            CEnemy[0] = true;
            heal = true;
        }

        if (enemy.Enemy2 && enemy.heal)
        {
            CEnemy[1] = true;
            heal = true;
        }

        if (enemy.Enemy3 && enemy.heal)
        {
            CEnemy[2] = true;
            heal = true;
        }
    }

    
}
