using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public int LevelAt;

    public bool key1, key2, key3, key4, key5, key6, key7;
    public bool Ukey1, Ukey2, Ukey3, Ukey4, Ukey5, Ukey6, Ukey7;
    public bool turnOn;
    public GameObject Panel;
    public TextMeshProUGUI txt;

    public bool PlayerInside;

    public bool PlayerEnter;
    private bool messageDisplaying = false;
    private float messageCooldown = 5f; // Cooldown to prevent overwrites
    private float cooldownTimer = 0f; // Timer for the cooldown

    void Update()
    {
        if (messageDisplaying)
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer >= messageCooldown)
            {
                HidePanel();
            }
            return; // Exit if a message is still being displayed
        }

        // Handle level-specific messages
        switch (LevelAt)
        {
            case 1:
                DisplayLevel1Messages();
                break;
            case 2:
                DisplayLevel2Messages();
                break;
            case 3:
                DisplayLevel3Messages();
                break;
            case 4:
                DisplayLevel4Messages();
                break;
            case 5:
                DisplayLevel5Messages();
                break;
            case 6:
                DisplayLevel6Messages();
                break;
            case 7:
                DisplayLevel7Messages();
                break;
        }
    }

    void DisplayLevel1Messages()
    {
        if (PlayerEnter && turnOn)
        {
            Invoke("ShowLevel1Message", 2f);
        }
        else if (Ukey1 && turnOn)
        {
            ShowMessage("You’ve got access to Room 2.", 5f);
        }
        else if (Ukey2 && turnOn)
        {
            ShowMessage("You’ve got access to Room 1.", 5f);
        }
        else if (Ukey3 && turnOn)
        {
            ShowMessage("You’ve got access to Hallway Door", 5f);
        }
        else if (Ukey4 && turnOn)
        {
            ShowMessage("You’ve got access to Room 4", 5f);
        }
        else if (Ukey5 && turnOn)
        {
            ShowMessage("You’ve got access to Room 5.", 5f);
        }
        else if (Ukey6 && turnOn)
        {
            ShowMessage("You’ve got access to Room 6", 5f);
        }
    }

    void DisplayLevel2Messages()
    {
        if (PlayerEnter && turnOn)
        {
            Invoke("ShowLevel1Message", 2f);
        }
        else if (Ukey1 && turnOn)
        {
            ShowMessage("You found a key.", 5f);
        }
        else if (Ukey2 && turnOn)
        {
            ShowMessage("The door is unlocked.", 5f);
        }
        else if ((Ukey3 || Ukey4 || Ukey5 || Ukey6) && turnOn)
        {
            ShowMessage("You found a code sheet", 2f);
        }
    }

    void DisplayLevel3Messages()
    {
        if (PlayerEnter && turnOn)
        {
            Invoke("ShowLevel1Message", 2f);
        }
        else if (Ukey1 && turnOn)
        {
            ShowMessage("You’ve got access to Room 1", 5f);
        }
        else if (Ukey2 && turnOn)
        {
            ShowMessage("You’ve got access to Room 2.", 5f);
        }
        else if (Ukey6 && turnOn)
        {
            ShowMessage("You’ve got access to Storage Room", 5f);
        }
        else if ((Ukey3 || Ukey4 || Ukey5) && turnOn)
        {
            ShowMessage("You can cut the ropes now.", 5f);
        }
        else if (Ukey7 && turnOn)
        {
            ShowMessage("You can now decipher the vault", 5f);
        }
    }

    void DisplayLevel4Messages()
    {
        if (PlayerEnter && turnOn)
        {
            Invoke("ShowLevel1Message", 2f);
        }
        else if (Ukey1 && turnOn)
        {
            ShowMessage("You’ve got access to Security Room.", 5f);
        }
        else if (Ukey3 && turnOn)
        {
            ShowMessage("You can now open the drawer in the security room.", 5f);
        }
        else if (Ukey4 && turnOn)
        {
            ShowMessage("You found a car key", 5f);
        }
        else if (Ukey5 && turnOn)
        {
            ShowMessage("You’ve got access to Storage Room.", 5f);
        }
        else if (Ukey6 && turnOn)
        {
            ShowMessage("You found a key for the desk.", 5f);
        }
        else if (Ukey7 && turnOn)
        {
            ShowMessage("You’ve got access to Office Room.", 5f);
        }
    }

    void DisplayLevel5Messages()
    {
        if (PlayerEnter && turnOn)
        {
            Invoke("ShowLevel1Message", 2f);
        }
        else if (Ukey1 && Ukey2 && turnOn)
        {
            ShowMessage("You’ve got access to Restroom.", 5f);
        }
        else if (Ukey3 && turnOn)
        {
            ShowMessage("You can now open the kitchen door", 5f);
        }
        else if (Ukey4 && turnOn)
        {
            ShowMessage("You’ve got access to Storage Room.", 5f);
        }
        else if (Ukey5 && turnOn)
        {
            ShowMessage("You found a knife", 5f);
        }
        else if (Ukey6 && turnOn)
        {
            ShowMessage("You can now cut the ropes", 5f);
        }
        else if (Ukey7 && turnOn)
        {
            ShowMessage("This knife is too dull.", 5f);
        }
    }

    void DisplayLevel6Messages()
    {
        if (PlayerEnter && turnOn)
        {
            Invoke("ShowLevel1Message", 2f);
        }
        else if (Ukey1 && turnOn)
        {
            ShowMessage("You’ve got access to Shop.", 3f);
        }
        else if (Ukey2 && turnOn)
        {
            ShowMessage("You’ve got access to Office Room.", 3f);
        }
        else if (Ukey3 && turnOn)
        {
            ShowMessage("You found gun powder", 3f);
        }
        else if (Ukey4 && turnOn)
        {
            ShowMessage("You found a fuse", 3f);
        }
        else if (Ukey5 && turnOn)
        {
            ShowMessage("You found a lighter", 3f);
        }
        else if (Ukey6 && turnOn)
        {
            ShowMessage("You found tape", 3f);
        }
        else if (Ukey7 && turnOn)
        {
            ShowMessage("You can now blow up the storage door", 3f);
        }
    }
    void ShowLevel1Message()
    {
        ShowMessage("Look around for the item you need", 3f);
    }
    void DisplayLevel7Messages()
    {
        if (Ukey1 && turnOn)
        {
            ShowMessage("You found a knife.", 3f);
        }
        else if (Ukey2 && turnOn)
        {
            ShowMessage("You've heated the knife. You can now open the basement door.", 3f);
        }
        else if (Ukey6 && turnOn)
        {
            ShowMessage("You found a hammer. You can now open Room 1.", 3f);
        }
        else if (Ukey3 && turnOn)
        {
            ShowMessage("You found a key. You can now open the comfort room.", 3f);
        }
        else if (Ukey4 && turnOn)
        {
            ShowMessage("You found a jar. You can now fill it with acid.", 3f);
        }
        else if (Ukey5 && turnOn)
        {
            ShowMessage("You found acid. You can now open Room 2.", 3f);
        }
    }


    void ShowMessage(string message, float displayTime)
    {
        if (!messageDisplaying)
        {
            Panel.gameObject.SetActive(true);
            txt.text = message;
            messageDisplaying = true;
            cooldownTimer = 0f;
            messageCooldown = displayTime;
        }
    }

    void HidePanel()
    {
        Panel.gameObject.SetActive(false);
        txt.text = "";
        turnOn = false; // Reset turnOn if needed
        Ukey1 = false;
        Ukey2 = false;
        Ukey3 = false;
        Ukey4 = false;
        Ukey5 = false;
        Ukey6 = false;
        Ukey7 = false;
        PlayerEnter = false;
        messageDisplaying = false;
        cooldownTimer = 0f;
    }
}
