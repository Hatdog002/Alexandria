using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject Active;
    public GameObject Deactivate;


    public void AttackEnemy()
    {
        Active.gameObject.SetActive(true);
        Deactivate.gameObject.SetActive(false);
    }
    public void HealPlayer()
    {
        Active.gameObject.SetActive(true);
        Deactivate.gameObject.SetActive(false);
    }
}
