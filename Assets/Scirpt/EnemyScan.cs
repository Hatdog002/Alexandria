using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScan : MonoBehaviour
{
    public bool book;
    public bool Door;

    public ViewBook view;
    public Buildingcode Enemy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (Door)
            {
                Enemy.EnemyClose = true;
            }

            if (book)
            {
                view.EnemyIsClose = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (Door)
            {
                Enemy.EnemyClose = true;
            }

            if (book)
            {
                view.EnemyIsClose = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Door)
        {
            Enemy.EnemyClose = false;
        }

        if (book)
        {
            view.EnemyIsClose = false;
        }
    }
}
