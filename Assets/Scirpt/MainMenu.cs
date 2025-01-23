using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class MainMenu : MonoBehaviour
{
    public string currentSceneName;


    public int ScneIndex;

    public GameObject Activate;
    public GameObject Deactivate;
    public PlayerLevelAndHealth data;

    private string saveFilePath;
    public void Start()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "PlayerHealthData.json");
        //Time.timeScale = 1;
        int scene = PlayerPrefs.GetInt("LoadScene");
        ScneIndex = scene;
        Debug.LogError(ScneIndex);
    }
    public void LoadScene()
    {
        //PlayerPrefs.SetInt("LevelReached",8);
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneName);
    }

    public void Settings()
    {
        Activate.gameObject.SetActive(true);
        Deactivate.gameObject.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(ScneIndex);
    }

    public void SettingsBack()
    {
        Activate.gameObject.SetActive(false);
        Deactivate.gameObject.SetActive(true);
    }

    public void BtnQuit()
    {
        Application.Quit();
    }

    public void BtnQ()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneName);
    }

    public void newG()
    {
        save();
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneName);
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }


    void save()
    {
        data.PlayerMaxHP = 50;
        data.PlayerHeal = 15;
        data.PlayerDamage = 10;
        data.PlayerXp = 1;
        data.PlayerXpProgress = 0;
        data.level2 = false;
        data.level3 = false;
        data.level4 = false;
        data.level5 = false;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(saveFilePath, json);
    }
}
