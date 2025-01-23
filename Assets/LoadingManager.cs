using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    private int Level;
    void Start()
    {
       Level = PlayerPrefs.GetInt("LoadingLevel");

        if(Level == 1)
        {
            Invoke("L1", 1f);
        }
        if (Level == 2)
        {
            Invoke("L2", 1f);
        }
        if (Level == 3)
        {
            Invoke("L3", 1f);
        }
        if (Level == 4)
        {
            Invoke("L4", 1f);
        }
        if (Level == 5)
        {
            Invoke("L5", 1f);
        }
        if (Level == 6)
        {
            Invoke("L6", 1f);
        }
        if (Level == 7)
        {
            Invoke("L7", 1f);
        }
    }


    void L1()
    {
        SceneManager.LoadScene("Level-0");
    }

    void L2()
    {
        SceneManager.LoadScene("Level1");
    }
    void L3()
    {
        SceneManager.LoadScene("Level2");
    }
    void L4()
    {
        SceneManager.LoadScene("Level3");
    }
    void L5()
    {
        SceneManager.LoadScene("Level4");
    }
    void L6()
    {
        SceneManager.LoadScene("Level5");
    }
    void L7()
    {
        SceneManager.LoadScene("Level6");
    }

}
