using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera mainCamera;
    public Camera secondaryCamera;
    public Camera activeCamera;
    public CameraFade cameraFade;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera.enabled = true;
        secondaryCamera.enabled = false;
        activeCamera = mainCamera;

        
    }

   public void SwitchCameraBattle()
    {
        cameraFade = activeCamera.GetComponent<CameraFade>();
        Debug.Log("Switching camera...");
        
        activeCamera.enabled = false; // Disable the currently active camera

        // Toggle the active camera
        if (activeCamera == mainCamera)
        {
            Debug.Log("Switching to secondary camera...");
            
            activeCamera = secondaryCamera;
        }

        Invoke("fadeout", 1f);
        activeCamera.enabled = true;
        // Enable the new active camera
        Debug.Log("Camera switched.");
    }
    public void SwitchCameraBattle1()
    {
        cameraFade = activeCamera.GetComponent<CameraFade>();
        Debug.Log("Switching camera...");

        activeCamera.enabled = false; // Disable the currently active camera
        if (activeCamera == secondaryCamera)
        {
            Debug.Log("Switching to main camera...");
            
            activeCamera = mainCamera;
        }
        //cameraFade.FadeIn();
        activeCamera.enabled = true;
        //activeCamera.enabled = true; // Enable the new active camera
        Debug.Log("Camera switched.");
    }


    void fadeout()
    {
        cameraFade.FadeIn();
       
    }
    
}
