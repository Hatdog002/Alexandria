using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController1 : MonoBehaviour
{
    //move variable
    public float speed;
    private Vector2 move;
    public float rotationSpeed;

    // jump variable
    public float jumpForce = 5.0f;
    public Transform groundCheck;
    public LayerMask groundMask;

    private Rigidbody rb;
    private bool isGrounded;

    public bool canMove = true;

    public QuestionUi Enemy;
    public GameObject EnemytoDestroy;
    public int index;
    public string lastCollidedObjectName;

    public Animator animator;
    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            moveSpeed();
            if(isGrounded)
            {
                //movementJump();
            }
            else
            {

            }
           
        }
        else
        {

        }

        EnemytoDestroy = GameObject.Find(lastCollidedObjectName);

        if (Enemy.Enemy)
        {
            Enemy.Enemy = false;
            Destroy(EnemytoDestroy);
        }

    }

    public void moveSpeed()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            animator.SetBool("isMoving", true);
        }
        else animator.SetBool("isMoving", false);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
        Debug.Log("Moving");
    }

    /*public void movementJump()
    {
        if (isGrounded && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    */

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            lastCollidedObjectName = collision.gameObject.name;
        }
       


    }

        void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = false;
            }
        }

}
