using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyTxtDamage : MonoBehaviour
{

    public Unit enemyUnit;

    public TextMeshProUGUI txt;
    // Start is called before the first frame update
    void Start()
    {
        enemyUnit = GetComponent<Unit>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = enemyUnit.damage.ToString();
    }
}
