using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSave : MonoBehaviour
{
    public void Level0()
    {
        PlayerPrefs.SetInt("LoadingLevel", 1);
        PlayerPrefs.Save();
    }
    public void Level1()
    {
        PlayerPrefs.SetInt("LoadingLevel", 2);
        PlayerPrefs.Save();
    }
    public void Level2()
    {
        PlayerPrefs.SetInt("LoadingLevel", 3);
        PlayerPrefs.Save();
    }
    public void Level3()
    {
        PlayerPrefs.SetInt("LoadingLevel", 4);
        PlayerPrefs.Save();
    }
    public void Level4()
    {
        PlayerPrefs.SetInt("LoadingLevel", 5);
        PlayerPrefs.Save();
    }
    public void Level5()
    {
        PlayerPrefs.SetInt("LoadingLevel", 6);
        PlayerPrefs.Save();
    }
    public void Level6()
    {
        PlayerPrefs.SetInt("LoadingLevel", 7);
        PlayerPrefs.Save();
    }
}
