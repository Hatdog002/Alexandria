using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharctersDemo : MonoBehaviour
{
    public Animator animator1;

    public Animator animator2;

    public Animator animator3;

    void Start()
    {
       
    }

    void Update()
    {
        // Example: if the player presses the W key, set the isRunning bool to true
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator1.SetBool("IsWalking", true);
            animator2.SetBool("IsWalking", true);
            animator3.SetBool("IsWalking", true);
        }

        // Example: if the player releases the W key, set the isRunning bool to false
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator1.SetBool("IsWalking", false);
            animator2.SetBool("IsWalking", false);
            animator3.SetBool("IsWalking", false);
        }
    }
}
