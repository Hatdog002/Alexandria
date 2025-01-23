using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public enum BattleStates {Start,PlayerTurn, Question, EnemyTurn, Won, Lost }

public class ChoiceButtonData
{
    public Button button;
    public int correctAnswerIndex;
}
public class QuestionUi : MonoBehaviour
{
    [Header("Battle System")]
    public BattleStates states;
    public PlayerMovementTutorial movement;
    public GameObject PlayerLife;
    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;
    public GameObject Enemy1Prefab;
    public GameObject Enemy2Prefab;

    public Transform PlayerStation;
    public Transform EnemyStation;

    Unit PlayerUnit;
    Unit EnemyUnit;

    public BattleHud playerHud;
    public BattleHud MainPlayer;
    public BattleHud EnemyHud;

    public GameObject Txt;
    public TextMeshProUGUI txtintro;
    public GameObject ActivatePanel;
    public GameObject DeactivatePanel;

    public bool Heal;
    public bool Attack;

    [Header("Question Var")]
    public TextMeshProUGUI questionText;
    public Button[] choiceButtons;
    public Button buttHeal;
    private List<ChoiceButtonData> choiceButtonDataList = new List<ChoiceButtonData>();
    public RandomQuestionGenerator questionGenerator;
    public bool correctAns;

    [Header("Player and Enemy")]
    public GameObject Deactivate;
    public bool Enemy;
    public FollowManager Can;
    public CameraManager cameraManager;
    public CameraFade cameraFade;
    public TextMeshProUGUI txtMiss;

    [Header("Enemy Spawnner")]
    public bool Enemy1;
    public bool Enemy2;
    public bool Enemy3;

    private GameObject EnemyGo;
    private GameObject EnemyGo1;
    private GameObject EnemyGo2;
    private Animator Enemyanimator;

    [Header("Panels")]
    public string currentSceneName;
    public GameObject MissionPanel;
    public GameObject MissionAnim;
    public Animator AnimMiss;

    public GameObject MainHp;
    public GameObject txtAlert;
    public GameObject MiniMap;

    public GameObject todestroy;

    [Header("Player Animation")]
    public Animator animator;
    public string boolName = "IsAttack";

    [Header("Book interact")]
    public GameObject txtulet;
    public Buildingcode B1;
    public Buildingcode B2;
    public ViewBook Book1;

    [Header("Level Timer")]
    public PlayerLUnderstand playerL;
    public GameObject Timer;
    public TextMeshProUGUI txttimer;
    public float timer;
    public bool timerIsRunning;
    public PlayerLevel xp;
    void Start()
    {
      
        states = BattleStates.Start;
        //SetupBattle();
        Enemy1 = false;
        Enemy2 = false;
        Enemy3 = false;

        timer = PlayerPrefs.GetFloat("QuestionTimer");

        Debug.LogError(timer);
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                // Optionally update a UI element to display the remaining time
                txttimer.text = Mathf.CeilToInt(timer).ToString();
            }
            else
            {
                timer = 0;
                timerIsRunning = false;

                // Handle the timeout (e.g., automatically switch to the enemy's turn)
                states = BattleStates.EnemyTurn;
                DelayEnemyChoice();
            }
        }

    }
    public void DisplayRandomQuestion()
    {
        Question randomQuestion = questionGenerator.GetRandomQuestion();

        if (randomQuestion != null)
        {
            // Display the randomly selected question
            questionText.text = randomQuestion.questionText;

            foreach (ChoiceButtonData buttonData in choiceButtonDataList)
            {
                buttonData.button.onClick.RemoveAllListeners();
            }
            choiceButtonDataList.Clear();
            // Display the choices
            for (int i = 0; i < choiceButtons.Length; i++)
            {
                if (i < randomQuestion.choices.Length)
                {
                    // Set the choice text
                    choiceButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = randomQuestion.choices[i];

                    // Add listener to the button to check if it's the correct answer
                    int correctAnswerIndex = randomQuestion.correctAnswerIndex;
                    choiceButtons[i].onClick.AddListener(() => CheckAnswer(correctAnswerIndex));
                    
                   
                    

                    ChoiceButtonData buttonData = new ChoiceButtonData();
                    buttonData.button = choiceButtons[i];
                    buttonData.correctAnswerIndex = correctAnswerIndex;
                    choiceButtonDataList.Add(buttonData);
                }
                else
                {
                    // Clear any extra choice texts
                    choiceButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
                }
                

            }

            if(timerIsRunning != true)
            {
                timer = PlayerPrefs.GetFloat("QuestionTimer");
            }
                // Reset the timer
        }
    }
    void CheckAnswer(int correctAnswerIndex)
    {
        // Ensure the list is initialized
        if (choiceButtonDataList == null || choiceButtonDataList.Count == 0)
        {
            Debug.LogError("choiceButtonDataList is null or empty!");
            return;
        }

        // Ensure EventSystem is active
        if (UnityEngine.EventSystems.EventSystem.current == null)
        {
            Debug.LogError("EventSystem.current is null!");
            return;
        }

        GameObject selectedGameObject = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;

        // Ensure a GameObject is selected
        if (selectedGameObject == null)
        {
            Debug.LogError("No GameObject is currently selected!");
            return;
        }

        Button selectedButton = selectedGameObject.GetComponent<Button>();

        // Ensure the selected GameObject has a Button component
        if (selectedButton == null)
        {
            Debug.LogError("Selected GameObject does not have a Button component!");
            return;
        }

        // Check if the selected button matches any in the list
        int selectedChoiceIndex = -1;
        for (int i = 0; i < choiceButtonDataList.Count; i++)
        {
            if (choiceButtonDataList[i].button == selectedButton)
            {
                selectedChoiceIndex = i;
                break;
            }
        }

        // Ensure a valid choice was made
        if (selectedChoiceIndex == -1)
        {
            Debug.LogError("Selected button does not match any choice in choiceButtonDataList!");
            return;
        }

        // Compare selected choice with the correct answer
        if (selectedChoiceIndex == correctAnswerIndex)
        {
            HandleCorrectAnswer();
        }
        else
        {
            HandleIncorrectAnswer();
        }
    }

    // Extracted methods for clarity
    void HandleCorrectAnswer()
    {
        if (Attack)
        {
            if (states != BattleStates.Question)
                return;

            timerIsRunning = false;
            correctAns = true;
            PlayerAttack();
            txtMiss.text = PlayerUnit.damage.ToString();
            Debug.Log("Correct!"); // Handle correct answer
        }

        if (Heal)
        {
            if (states != BattleStates.Question)
                return;

            correctAns = true;
            PlayerHeal();
            timerIsRunning = false;
            Debug.Log("Correct!"); // Handle correct answer
        }
    }

    void HandleIncorrectAnswer()
    {
        states = BattleStates.EnemyTurn;
        correctAns = false;

        if (Attack)
        {
            timerIsRunning = false;
            txtMiss.text = "Miss";
            PlayerAttack();
        }
        else if (Heal)
        {
            timerIsRunning = false;
            txtMiss.text = "0";
            PlayerHeal();
        }

        Debug.Log("Incorrect!"); // Handle incorrect answer
    }

    public void SetupBattle()
    {
        Debug.LogError("SetUp");
        GameObject playerHp = PlayerLife;
        PlayerUnit = playerHp.GetComponent<Unit>();
        playerHud.SetHUD(PlayerUnit);

        if (PlayerUnit.currentHp < PlayerUnit.MaxHp)
        {
            Debug.LogError(PlayerUnit.currentHp);
            buttHeal.interactable = true;
        }
        else if(PlayerUnit.currentHp == PlayerUnit.MaxHp)
        {
            buttHeal.interactable = false;
        }

        if (Enemy1 == true)
        {
            EnemyGo = Instantiate(EnemyPrefab, EnemyStation);
            EnemyUnit = EnemyGo.GetComponent<Unit>();
            Enemyanimator = EnemyGo.GetComponent<Animator>();
            EnemyHud.SetHUD(EnemyUnit);
            //Invoke("Tutorial", 1f);
        }
        else
        {
            if (EnemyGo != null)
            {
                EnemyGo.SetActive(false);
            }
        }
        if (Enemy2 == true)
        {
            EnemyGo1 = Instantiate(Enemy1Prefab, EnemyStation);
            EnemyUnit = EnemyGo1.GetComponent<Unit>();
            Enemyanimator = EnemyGo1.GetComponent<Animator>();
            EnemyHud.SetHUD(EnemyUnit);
            //Invoke("PlayerTurn", 1f);
        }
        else
        {
            if (EnemyGo1 != null)
            {
                EnemyGo1.SetActive(false);
            }
        }
        if ( Enemy3 == true)
        {
            EnemyGo2 = Instantiate(Enemy2Prefab, EnemyStation);
            EnemyUnit = EnemyGo2.GetComponent<Unit>(); 
            EnemyHud.SetHUD(EnemyUnit);
            Enemyanimator = EnemyGo2.GetComponent<Animator>();
            //Invoke("PlayerTurn", 1f);
        }
        else
        {
            if (EnemyGo2 != null)
            {
                EnemyGo2.SetActive(false);
            }
        }

        if(Can.EnemyCounter == 1)
        {
            states = BattleStates.PlayerTurn;
            //cameraFade.Fade();
            Invoke("Tutorial", 1f);
        }
        else
        {
            states = BattleStates.PlayerTurn;
            //cameraFade.Fade();
            Invoke("PlayerTurn", 1f);
        }
      
    }
    void Tutorial()
    {
        if (txtAlert.gameObject.activeSelf)
        {
            txtAlert.gameObject.SetActive(false);
        }
        offPanel1();
        Text1();
        Invoke("PlayerTurn", 11f);
    }

    void PlayerTurn()
    {
        if (PlayerUnit.currentHp == PlayerUnit.MaxHp)
        {
            buttHeal.interactable = false;
        }
        else
        {
            buttHeal.interactable = true;
        }

        if (txtAlert.gameObject.activeSelf)
        {
            txtAlert.gameObject.SetActive(false);
        }
        movement.movement();
        offPanel();

        correctAns = false;
        Heal = false;
        Attack = false;
        
    }
   
    public void OnAttackPanel()
    {
        if (states != BattleStates.PlayerTurn)
            return;
        DisplayRandomQuestion();
        AttackPanel();
    }
    public void OnHealPanel()
    {
        if (states != BattleStates.PlayerTurn)
            return;
        DisplayRandomQuestion();
        HealPanel();
    }

    void AttackPanel()
    {
        timerIsRunning = true;
        Attack = true;
        Timer.gameObject.SetActive(true);
        ActivatePanel.gameObject.SetActive(true);
        DeactivatePanel.gameObject.SetActive(false);
        states = BattleStates.Question;
    }
    void HealPanel()
    {
        timerIsRunning = true;
        Heal = true;
        Timer.gameObject.SetActive(true);
        ActivatePanel.gameObject.SetActive(true);
        DeactivatePanel.gameObject.SetActive(false);
        states = BattleStates.Question;
    }

    public void Back()
    {
        Attack = false;
        Heal = false;
        states = BattleStates.PlayerTurn;
        ActivatePanel.gameObject.SetActive(false);
        DeactivatePanel.gameObject.SetActive(true);
    }

    void PlayerAttack()
    {
        bool isDead;
        if (correctAns)
        {
            isDead = EnemyUnit.TakeDamage(PlayerUnit.damage);
            Debug.Log("Hit");
        }
        else
        {
            isDead = EnemyUnit.TakeDamage(0);
            Debug.Log("Miss");
        }

        if (isDead)
        {
            //endBattle
            states = BattleStates.Won;
            animator.SetBool(boolName, true);
            StartCoroutine(TriggerAnimationBool());
            StartCoroutine(TriggerEnemyDamageAnimationBool());
            StartCoroutine(TriggerEnemyAnimationBoolfalse());
            PlayerNotif();
            Invoke("EndBattle", 5f);
        }
        else
        {
            //EnemyTurn
            states = BattleStates.EnemyTurn;

            animator.SetBool(boolName, true);
            //playerAttack

            StartCoroutine(TriggerEnemyDamageAnimationBool());
            //Enemy Damage


            StartCoroutine(TriggerAnimationBool());
            //Idle player

            
            //idle Enemy
            PlayerNotif();
            Invoke("DelayEnemyChoice",6f);
        }
    }

    
    void PlayerHeal()
    {
        bool isDead;
        if (correctAns)
        {
            isDead = PlayerUnit.HealPlayer(PlayerUnit.Heal);
        }
        else
        {
            isDead = PlayerUnit.HealPlayer(0);
        }

        if (isDead)
        {
            //endBattle
            states = BattleStates.Lost;
            EndBattle();
        }
        else
        {
            //EnemyTurn
            states = BattleStates.EnemyTurn;
            PlayerNotif();
           
            animator.SetBool("IsHeal", true);
            Invoke("Healupdate", 1.5f);
            StartCoroutine(HealAnimFalse());
            Invoke("DelayEnemyChoice", 3f);
        }
    }

    public void EndBattle()
    {
        if(states == BattleStates.Won)
        {
            //Destry Prefab
            Enemy = true;
            Destryo();
            EnemyClose();

            //fade camera
            cameraFade.FadeOut();

            //uitrue
            Deactivate.gameObject.SetActive(false);
            MainPlayer.SetHp(PlayerUnit.currentHp);
            MissionPanel.gameObject.SetActive(true);
            MissionAnim.gameObject.SetActive(true);
            AnimMiss.SetBool("IsOpen", false);
            MiniMap.gameObject.SetActive(true);
            if(txtulet.activeSelf == true)
            {
                txtulet.gameObject.SetActive(true);
            }
            else
            {
                txtulet.gameObject.SetActive(false);
            }
           

            //Enemy reset and ans
            EnemyUnit.Reset();
            correctAns = false;

            //Reset Hud
            ActivatePanel.gameObject.SetActive(false);
            DeactivatePanel.gameObject.SetActive(true);

            //PlayerMovement
            Invoke("delay", 1f);

            //reset battleState
            Invoke("DelayStart", 1.5f);
            Debug.Log("won");

            LevelUp();
            //EnemyCloseBookB
        }
        else if (states == BattleStates.Lost)
        {
            EnemyClose();
            PlayerPrefs.SetInt("LoadScene", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.Save();
            Debug.Log(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(currentSceneName);
        }
    }
    IEnumerator TriggerAnimationBool()
    {
        //yield return new WaitForSeconds(3f);
        Debug.Log("call");
        float animationLength = 0.3f;
        Debug.Log(animationLength);
        // Wait for the specified delay
        yield return new WaitForSeconds(animationLength);
        // Set the animator bool
        if (animator.GetBool(boolName) == true)
        {
            animator.SetBool(boolName, false);
            Debug.Log("call2");
        }
        else
        {
            Debug.Log("NotDone2");
        }

        if (animator.GetBool("IsDamage") == true)
        {
            animator.SetBool("IsDamage", false);
            Debug.Log("done");
        }
        else
        {
            Debug.Log("NotDone");
        }

    }
    IEnumerator HealAnimFalse()
    {
        Debug.Log("call");
        float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
        Debug.Log(animationLength);
        // Wait for the specified delay
        yield return new WaitForSeconds(animationLength);

        if (animator.GetBool("IsHeal") == true)
        {
            animator.SetBool("IsHeal", false);
            Debug.Log("doneHeal");
        }
        else
        {
            Debug.Log("NotDoneHeal");
        }
    }
    void Healupdate()
    {
        playerHud.SetHp(PlayerUnit.currentHp);
    }
    IEnumerator TriggerEnemyAnimationBoolfalse()
    {
        //yield return new WaitForSeconds(3f);
        Debug.Log("Enemyfalse");
        float animationLength = 0f;
        // Wait for the specified delay
        yield return new WaitForSeconds(animationLength);
        // Set the animator bool

        if(Enemyanimator.GetBool("IsDamage")== true)
        {
            Enemyanimator.SetBool("IsDamage", false);
            Debug.Log("EnemyDone");
        }

        if(Enemyanimator.GetBool("IsHeal") == true)
        {
            Enemyanimator.SetBool("IsHeal", false);
        }

        if (Enemyanimator.GetBool("IsDodge") == true)
        {
            Enemyanimator.SetBool("IsDodge", false);
        }

    }
    IEnumerator TriggerEnemyAnimationBoolfalse1()
    {
        //yield return new WaitForSeconds(3f);
        Debug.Log("Enemyfalse");
        float animationLength = 1.8f;
        // Wait for the specified delay
        yield return new WaitForSeconds(animationLength);
        // Set the animator bool
        if (Enemyanimator.GetBool(boolName) == true)
        {
            Enemyanimator.SetBool(boolName, false);
        }
    }
    IEnumerator TriggerEnemyDamageAnimationBool()
    {
       
        float animationLength = 4.7f;
        // Wait for the specified delay
        yield return new WaitForSeconds(animationLength);
        // Set the animator bool
        if (correctAns)
        {
            Enemyanimator.SetBool("IsDamage", true);
        }
        else
        {
            Debug.LogWarning("Dodge");
            Enemyanimator.SetBool("IsDodge", true);
        }
        
        EnemyHud.SetHp(EnemyUnit.currentHp);
        StartCoroutine(TriggerEnemyAnimationBoolfalse());

    }
    IEnumerator TriggerPlayerDamageAnimationBool()
    {
      
        float animationLength = 2f;
        // Wait for the specified delay
        yield return new WaitForSeconds(animationLength);
        // Set the animator bool
        animator.SetBool("IsDamage", true);
        playerHud.SetHp(PlayerUnit.currentHp);

        StartCoroutine(TriggerAnimationBool());
    }
    IEnumerator EnemyAttack()
    {
        bool isDead = PlayerUnit.TakeDamage(EnemyUnit.damage);
        EnemyChoose();
        Invoke("EnemyChoice", 3f);

        yield return new WaitForSeconds(3f);

        if (isDead)
        {
            //endBattle
            states = BattleStates.Lost;
            Enemyanimator.SetBool(boolName, true);
            StartCoroutine(TriggerPlayerDamageAnimationBool());
            StartCoroutine(TriggerEnemyAnimationBoolfalse());
            StartCoroutine(TriggerAnimationBool());
            Invoke("EndBattle", 5f);
        }
        else
        {
            Enemyanimator.SetBool(boolName, true);
            //attack anim

            StartCoroutine(TriggerEnemyAnimationBoolfalse1());
            StartCoroutine(TriggerPlayerDamageAnimationBool());
            // Damage player

            //idle Enemy

            //idle player

            states = BattleStates.PlayerTurn;
            Invoke("PlayerTurn", 7f);
        }
    }

    IEnumerator EnemyHeal()
    {
        bool isDead = EnemyUnit.HealPlayer(EnemyUnit.Heal);
        EnemyChoose();
        Invoke("EnemyChoiceHeal", 3f);

        yield return new WaitForSeconds(3f);

        if (isDead)
        {
            //endBattle
            states = BattleStates.Lost;
            EndBattle();
        }
        else
        {
            states = BattleStates.PlayerTurn;
            //Player Turn
            Enemyanimator.SetBool("IsHeal", true);
            Invoke("EnemyHealupdate", 1.5f);
            StartCoroutine(TriggerEnemyAnimationBoolfalse());
            Invoke("PlayerTurn", 3f);
        }
    }
    void EnemyHealupdate()
    {
        EnemyHud.SetHp(EnemyUnit.currentHp);
    }
    void PlayerNotif()
    {
        if (Attack) {
            txtintro.text = "Player is Attacking";
        }
        else if(Heal)
        {
            if (correctAns)
            {
                txtintro.text = "Player is Healing";
            }
            else
            {
                txtintro.text = "Heal doesn't work";
            }
        }
        panel2Off();
    }

    void EnemyChoose()
    {
        panel2Off();
        txtintro.text = "Enemy is thinking";
    }
    void EnemyChoice()
    {
        panel2Off();
        txtintro.text = "Enemy uses attack";
    }
    void EnemyChoiceHeal()
    {
        panel2Off();
        txtintro.text = "Enemy uses heal";
    }
    void DelayEnemyChoice()
    {
        float randomValue = Random.value; // Generate a random float value between 0.0 and 1.0
        if(EnemyUnit.currentHp == EnemyUnit.MaxHp)
        {
            StartCoroutine(EnemyAttack());
        }
        else
        {
            if (randomValue < 0.5f)
            {
                StartCoroutine(EnemyAttack());
            }
            else
            {
                StartCoroutine(EnemyHeal());
            }
        }
       
    }

    void offEnemyBattle()
    {
        if (Enemy1)
        {
            Destroy(EnemyGo.gameObject);
        }

        if (Enemy2)
        {
            Destroy(EnemyGo1.gameObject);
        }
        if (Enemy3)
        {
            Destroy(EnemyGo2.gameObject);
        }

    }
    void delay()
    {
        offEnemyBattle();
        cameraManager.SwitchCameraBattle1();
        movement.Movement1();
        Can.canFollow = true;
        MainHp.gameObject.SetActive(true);
        cameraFade.FadeIn();
    }

    void Text1()
    {
        txtintro.text = "Welcome to your first battle";
        Invoke("Text2", 3f);
        Invoke("Text3", 6f);
    }

    void Text2()
    {
        txtintro.text = "Your decision can cause your life";
    }

    void Text3()
    {
        txtintro.text = "Choose wisely";
    }

    void Destryo()
    {
        if (Enemy1 == false)
        {
            Destroy(EnemyGo);
        }

        if (Enemy2 == false)
        {
            Destroy(EnemyGo1);
        }

        if (Enemy3 == false)
        {
            Destroy(EnemyGo2);
        }
    }

    void offPanel()
    {
        Timer.gameObject.SetActive(false);
        txtulet.gameObject.SetActive(false);
        Txt.gameObject.SetActive(false);
        MissionAnim.gameObject.SetActive(false);
        Deactivate.gameObject.SetActive(true);
        MissionPanel.gameObject.SetActive(false);
        ActivatePanel.gameObject.SetActive(false);
        DeactivatePanel.gameObject.SetActive(true);
        MiniMap.gameObject.SetActive(false);
    }


    void offPanel1()
    {
        Timer.gameObject.SetActive(false);
        txtulet.gameObject.SetActive(false);
        //Txt.gameObject.SetActive(false);
        MissionAnim.gameObject.SetActive(false);
        Deactivate.gameObject.SetActive(true);
        MissionPanel.gameObject.SetActive(false);
        ActivatePanel.gameObject.SetActive(false);
        DeactivatePanel.gameObject.SetActive(false);
        MiniMap.gameObject.SetActive(false);
    }

    void panel2Off()
    {
        Timer.gameObject.SetActive(false);
        DeactivatePanel.gameObject.SetActive(false);
        ActivatePanel.gameObject.SetActive(false);
        Txt.gameObject.SetActive(true);
    }

    void DelayStart()
    {
        states = BattleStates.Start;
    }

    void EnemyClose()
    {
        B1.EnemyClose = false;
        B2.EnemyClose = false;
        Book1.EnemyIsClose = false;
    }

    void LevelUp()
    {
        xp.xpProg += Random.Range(2f, 5f);
    }

   
}           
