 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{

    public Vector2 turn;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X");

        transform.localRotation = Quaternion.Euler(50, turn.x, 0);
    }
}
