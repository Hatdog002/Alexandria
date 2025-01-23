using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelMenuScript : MonoBehaviour
{
    public Button level1Button;
    public Button level2Button;
    public Button level3Button;
    public Button level4Button;
    public Button level5Button;
    public Button level6Button;
    public Button level7Button;

    public int levelReached;
    public string Scene;

    void Start()
    {
        // Load saved level progress (if any), defaults to level 1 unlocked
         levelReached = PlayerPrefs.GetInt("LevelReached");

        // Disable level 2 and 3 buttons by default
        
        level2Button.interactable = false;
        level3Button.interactable = false;
        level4Button.interactable = false;
        level5Button.interactable = false;
        level6Button.interactable = false;
        level7Button.interactable = false;


        /*
        level2Button.interactable = true;
        level3Button.interactable = true;
        level4Button.interactable = true;
        level5Button.interactable = true;
        level6Button.interactable = true;
        level7Button.interactable = true;
        */

        // Unlock levels based on saved progress
        if (levelReached >= 0)
        {
            level1Button.gameObject.SetActive(true); // Enable the GameObject
            level1Button.interactable = true; // Enable button interactivity
            SetRaycastTarget(level1Button, true); // Enable raycast target
        }
        else
        {
            level1Button.gameObject.SetActive(false); // Disable the GameObject
            level1Button.interactable = false; // Disable button interactivity
            SetRaycastTarget(level1Button, false); // Disable raycast target
        }

        // Level 2
        if (levelReached >= 1)
        {
            level2Button.gameObject.SetActive(true);
            level2Button.interactable = true;
            SetRaycastTarget(level2Button, true);
        }
        else
        {
            level2Button.gameObject.SetActive(false);
            level2Button.interactable = false;
            SetRaycastTarget(level2Button, false);
        }

        // Level 3
        if (levelReached >= 2)
        {
            level3Button.gameObject.SetActive(true);
            level3Button.interactable = true;
            SetRaycastTarget(level3Button, true);
        }
        else
        {
            level3Button.gameObject.SetActive(false);
            level3Button.interactable = false;
            SetRaycastTarget(level3Button, false);
        }

        // Level 4
        if (levelReached >= 3)
        {
            level4Button.gameObject.SetActive(true);
            level4Button.interactable = true;
            SetRaycastTarget(level4Button, true);
        }
        else
        {
            level4Button.gameObject.SetActive(false);
            level4Button.interactable = false;
            SetRaycastTarget(level4Button, false);
        }

        // Level 5
        if (levelReached >= 4)
        {
            level5Button.gameObject.SetActive(true);
            level5Button.interactable = true;
            SetRaycastTarget(level5Button, true);
        }
        else
        {
            level5Button.gameObject.SetActive(false);
            level5Button.interactable = false;
            SetRaycastTarget(level5Button, false);
        }

        // Level 6
        if (levelReached >= 5)
        {
            level6Button.gameObject.SetActive(true);
            level6Button.interactable = true;
            SetRaycastTarget(level6Button, true);
        }
        else
        {
            level6Button.gameObject.SetActive(false);
            level6Button.interactable = false;
            SetRaycastTarget(level6Button, false);
        }

        // Level 7
        if (levelReached >= 6)
        {
            level7Button.gameObject.SetActive(true);
            level7Button.interactable = true;
            SetRaycastTarget(level7Button, true);
        }
        else
        {
            level7Button.gameObject.SetActive(false);
            level7Button.interactable = false;
            SetRaycastTarget(level7Button, false);
        }
    }

    private void SetRaycastTarget(Button button, bool enabled)
    {
        // Access the Image component attached to the button
        Image buttonImage = button.GetComponent<Image>();

        if (buttonImage != null)
        {
            buttonImage.raycastTarget = enabled;
        }
    }

    public void NXT()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene(Scene);
    }
}
