using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHolder : MonoBehaviour
{
    public GameObject MainMenu1;
    public GameObject MainMenu2;
    public GameObject Debug;

    public int levelReached;
    // Start is called before the first frame update
    void Start()
    {
        levelReached = PlayerPrefs.GetInt("LevelReached");
    }

    // Update is called once per frame
    void Update()
    {
        levelReached = PlayerPrefs.GetInt("LevelReached");
        debug();
        if(levelReached == 0)
        {
            MainMenu1.gameObject.SetActive(true);
            MainMenu2.gameObject.SetActive(false);
        }
        else
        {
            MainMenu1.gameObject.SetActive(false);
            MainMenu2.gameObject.SetActive(true);
        }
    }


    public void debug()
    {
        if(Input.GetKeyDown(KeyCode.P) && Input.GetKeyDown(KeyCode.Z))
        {
            if (Debug.activeSelf)
            {
                Debug.gameObject.SetActive(false);
            }
            else
            {
                Debug.gameObject.SetActive(true);
            }
            
        }
    }

    public void levelUp()
    {
        PlayerPrefs.SetInt("LevelReached",8);
        PlayerPrefs.Save();
    }

    public void levelDown()
    {
        PlayerPrefs.SetInt("LevelReached",0);
        PlayerPrefs.Save();
    }
}
