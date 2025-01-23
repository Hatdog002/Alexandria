using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovementTutorial : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float walkingSpeed;
    public float runningSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public Animator animator;

    public bool canMove =true;

    public string lastCollidedObjectName;

    public GameObject EnemytoDestroy;

    public EnemyPchecks EnemyBattle;
    public QuestionUi Enemy;

    public CameraFade fade;

    public CamHolder cam;

    public TutorialManager managerTut;

    public LevelManager LevelAt;

    public GameObject Mission;

    public EnemyTrigger can;

    public Collider PlayerCollider;

    public GameObject HealPrefab;
    public GameObject keyPrefab;

    public Vector3 EnemyLastpos;

    public int healspawn = 0;

    public bool EnemyDrop;
    public bool HealDrop;
    private void Start()
    {
        PlayerCollider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;
        canMove = true;
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        if (canMove)
        {
            MyInput();
            SpeedControl();
        }
        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        if (LevelAt.LevelAt >= 1)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (Enemy.states == BattleStates.Start)
                {
                    MisisonOn();
                }
            }
            else if (Input.GetKeyUp(KeyCode.Tab))
            {
                if (Enemy.states == BattleStates.Start)
                {
                    MisisonOff();
                }
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                if (canMove)
                {
                    movement();
                }
                else
                {
                    Movement1();
                }

            }


        }
        else
        {
            if (managerTut.EndTutorial)
            {
                if (canMove)
                {
                    if (Input.GetKeyDown(KeyCode.Tab))
                    {
                        if (Enemy.states == BattleStates.Start)
                        {
                            MisisonOn();
                        }
                    }
                    else if (Input.GetKeyUp(KeyCode.Tab))
                    {
                        if (Enemy.states == BattleStates.Start)
                        {
                            MisisonOff();
                        }
                    }
                }
            }
        }

        EnemytoDestroy = GameObject.Find(lastCollidedObjectName);
        if (EnemytoDestroy != null)
        {
            EnemyBattle = EnemytoDestroy.GetComponent<EnemyPchecks>();
        }

        if (Enemy.states == BattleStates.PlayerTurn)
        {
            Enemy.Enemy = false;
            Destroy(EnemytoDestroy);
        }


        if(Enemy.states == BattleStates.Won)
        {
            if (HealDrop)
            {
                if (healspawn == 0)
                {
                    healspawn += 1;
                    Instantiate(HealPrefab, EnemyLastpos, Quaternion.identity);
                }

            }
            
            if (EnemyDrop)
            {
                EnemyDrop = false;
                Instantiate(keyPrefab, EnemyLastpos, Quaternion.identity);
            }

        }
        else if (Enemy.states == BattleStates.Start)
        {
            EnemyDrop = false;
            healspawn = 0;
        }


        if (Enemy.states == BattleStates.Start)
        {
            can.cantCollide = true;
            can.enemyCollide = 0;
            PlayerCollider.enabled = true;
            can.enabled = true;
        }
        else
        {
            can.cantCollide = false;
            PlayerCollider.enabled = false;
            can.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            MovePlayer();
        }
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        bool isWalking = (horizontalInput != 0f || verticalInput != 0f);

        bool isRunning = (isWalking && Input.GetKey(KeyCode.LeftShift));

        // when to jump

        if (isRunning)
        {
            animator.SetBool("IsRunning", true);
            animator.SetBool("IsWalking", true);  // Turn off walking when running
            moveSpeed = runningSpeed; // Set to running speed
        }
        else if (isWalking)
        {
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsRunning", false);  // Turn off running when walking
            moveSpeed = walkingSpeed; // Set to walking speed
        }
        else
        {
            // If no movement, turn off both walking and running animations
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", false);
        }

        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            //Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // Normalize the movement direction and multiply by move speed
        Vector3 velocity = moveDirection.normalized * moveSpeed * 10f;

        // Check if any movement key is pressed
        if (horizontalInput != 0f || verticalInput != 0f)
        {
            if (grounded)
            {
                // Apply movement when grounded
                rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
            }
            else if (!grounded)
            {
                // Apply movement when in air with air multiplier
                rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
            }
        }
        else
        {
            // If no movement keys are pressed, stop the player's movement completely
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            
        }
        
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            lastCollidedObjectName = collision.gameObject.name;
        }
    }

    public void movement()
    {
        canMove = false;
        cam.canLook = false;
        //fade.FadeOut();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Movement1()
    {
        canMove = true;
        cam.canLook = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void MisisonOn()
    {
        Mission.gameObject.SetActive(true);
    }
    public void MisisonOff()
    {
        Mission.gameObject.SetActive(false);
    }
}