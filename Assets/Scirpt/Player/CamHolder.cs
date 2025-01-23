using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamHolder : MonoBehaviour
{
    public bool canLook;
    public bool canLook2;
    public CinemachineFreeLook FreeLook;

    public bool lockXAxis = false;
    public bool lockYAxis = false;
    public bool lockZAxis = false;
    // Start is called before the first frame update
    void Start()
    {
        SetAxisConstraints();
    }

    // Update is called once per frame
    void Update()
    {
        if (canLook)
        {
            Cursor.lockState = CursorLockMode.Locked;
            FreeLook.enabled = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            FreeLook.enabled = false;
        }

        if (canLook2)
        {
          

        }
    }

    void SetAxisConstraints()
    {
      
    }
}
