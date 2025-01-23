using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorManager1 : MonoBehaviour
{
    public PlayerMovementTutorial movement;
    public CamHolder look;

    public void cantmove()
    {
        movement.canMove = false;
    }
    public void cantLook()
    {
        look.canLook = false;
    }


    public void move()
    {
        movement.canMove = transform;
    }
    public void Look()
    {
        look.canLook = true;
    }
    public  void cursorok()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void cursornok()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
