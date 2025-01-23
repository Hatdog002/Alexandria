using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HpPickUps : MonoBehaviour
{
    public Unit playerUnit;

    public bool heal;

    public TextMeshProUGUI txtInteract;

    public BattleHud Hud;

    public GameObject destroy;

    public float hp;

    public GameObject Heal;
    public QuestionUi states;
    // Start is called before the first frame update
    void Start()
    {
        heal = false;
        playerUnit = GetComponent<Unit>();
    }

    // Update is called once per frame
    void Update()
    {
        hp = playerUnit.currentHp;
        if (heal)
        {
            if(states.states == BattleStates.Start)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (hp < playerUnit.MaxHp)
                    {
                        heal = false;
                        txtInteract.text = "";
                        playerUnit.HealPlayer(playerUnit.Heal);
                        Hud.SetHp(playerUnit.currentHp);
                        Heal.gameObject.SetActive(true);
                        Invoke("Off", 1f);
                        Destroy(destroy.gameObject);
                    }
                    else if (hp == playerUnit.MaxHp)
                    {
                        txtInteract.text = "Health is full.";
                    }
                }
            }
        }
        
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Heal"))
        {
            txtInteract.text = "E";
            heal = true;
            destroy = other.gameObject;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Heal"))
        {
            txtInteract.text = "";
            heal = false;

            destroy = null;
        }
    }

    public void Off()
    {
        Heal.gameObject.SetActive(false);
    }
}
