using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public PlayerMovementTutorial Movement;
    public bool playerCollided = false;
    public BattleStates states;
    private GameObject battlePanel; // Reference to the BattlePanel GameObject
    public FollowManager Can;
    public CameraManager cameraManager;
    public Animator playerAnimator;

    public string lastCollidedObjectName;
    public GameObject EnemytoDestroy;
    public QuestionUi ui;
    public EnemyPchecks EnemyBattle;
    public GameObject MainHp;

    public CameraFade fade;

    public Collider Collider;

    public int enemyCollide;

    public bool cantCollide = true;

    public void Start()
    {
        cantCollide = true;
        //states = ui.GetComponent<BattleStates>();
    }

    public void OnTriggerEnter(Collider collision)
    {
       
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (cantCollide)
            {
                if (enemyCollide <= 1)
                {
                    lastCollidedObjectName = collision.gameObject.name;
                    cantCollide = false;
                    playerAnimator.SetBool("IsWalking", false);
                    playerAnimator.SetBool("IsRunning", false);
                    Debug.Log("Player");
                    ui.states = BattleStates.PlayerTurn;
                    //fade.Fade();
                    
                    Movement.movement();
                    Can.canFollow = false;
                    playerCollided = true;


                    enemyCollide += 1;
                    EnemytoDestroy = GameObject.Find(lastCollidedObjectName);
                    if (EnemytoDestroy != null)
                    {
                        EnemyBattle = EnemytoDestroy.GetComponent<EnemyPchecks>();
                        Collider = EnemytoDestroy.GetComponent<Collider>();
                        Movement.EnemyLastpos = collision.transform.position;
                        // Invoke("delayEnemy", 1f);
                    }

                    if (EnemyBattle.CEnemy[0])
                    {
                        ui.Enemy1 = true;
                        ui.Enemy2 = false;
                        ui.Enemy3 = false;
                    }
                    else if (EnemyBattle.CEnemy[1])
                    {
                        ui.Enemy1 = false;
                        ui.Enemy2 = true;
                        ui.Enemy3 = false;
                    }
                    else if (EnemyBattle.CEnemy[2])
                    {
                        ui.Enemy1 = false;
                        ui.Enemy2 = false;
                        ui.Enemy3 = true;
                    }


                    if (EnemyBattle.KeyEnemy)
                    {
                        Movement.EnemyDrop = true;
                    }
                    else
                    {
                        Movement.EnemyDrop = false;
                    }

                    if (EnemyBattle.heal)
                    {
                        Movement.HealDrop = true;
                    }
                    else
                    {
                        Movement.HealDrop = false;
                    }

                    fade.FadeOut();
                    Invoke("delay", 1f);
                    Setup();
                }
                else
                {
                    cantCollide = false;
                }
            }
          
           
          
        }
    }

    public void Update()
    {
        if(ui.states == BattleStates.Start) 
        {
                Invoke("delayCounter", 2f);
        }
    }

    void delay()
    {
     
        if (playerCollided)
        {
            cameraManager.SwitchCameraBattle();
            Debug.Log("Switch");
        }
        else
        {
            Debug.Log("NotSwitch");
        }
       
        if (battlePanel != null)
        {
            //battlePanel.SetActive(true);
        }
    }
    void Setup()
    {
        if(enemyCollide == 1)
        {
            Can.EnemyCounter += 1;
            MainHp.gameObject.SetActive(false);
            ui.SetupBattle();
        }
    }

    void delayCounter()
    {
        Can.CounterENEMY = 0;
        ui.Enemy1 = false;
        ui.Enemy2 = false;
        ui.Enemy3 = false;
    }

    void delayEnemy()
    {
       // Collider.enabled = false;
    }
    
}
