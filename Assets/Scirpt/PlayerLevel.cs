using System.IO;
using UnityEngine;
using TMPro;

public class PlayerLevel : MonoBehaviour
{
    public PlayerLevelAndHealth data;

    public float xpProg;
    public float xp;

    public BattleHud hud;

    public Unit unit;

    public GameObject Effect;

    public TextMeshProUGUI txtLevel;

    private string saveFilePath;

    void Start()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "PlayerHealthData.json");
        LoadData();

        xp = data.PlayerXp;
        xpProg = data.PlayerXpProgress;
    }

    void Update()
    {
        if (xpProg >= 0 && xpProg < 10)
        {
            data.PlayerDamage = 10;
            data.PlayerHeal = 15;
            data.PlayerMaxHP = 50;
            hud.SetHUD(unit);
            unit.LevelUp();
            xp = 1;
            SaveData();
        }
        else if (xpProg >= 10 && xpProg < 20)
        {
            data.PlayerDamage = 15;
            data.PlayerHeal = 15;
            data.PlayerMaxHP = 60;
            hud.SetHUD(unit);
            unit.LevelUp();
            xp = 2;
            SaveData();
            if (!data.level2)
            {
                OnEff();
                data.level2 = true;
            }
        }
        else if (xpProg >= 20 && xpProg < 30)
        {
            data.PlayerDamage = 20;
            data.PlayerHeal = 20;
            data.PlayerMaxHP = 60;
            hud.SetHUD(unit);
            unit.LevelUp();
            xp = 3;
            SaveData();
            if (!data.level3)
            {
                OnEff();
                data.level3 = true;
            }
        }
        else if (xpProg >= 30 && xpProg < 40)
        {
            data.PlayerDamage = 25;
            data.PlayerHeal = 20;
            data.PlayerMaxHP = 70;
            hud.SetHUD(unit);
            unit.LevelUp();
            xp = 4;
            SaveData();
            if (!data.level4)
            {
                OnEff();
                data.level4 = true;
            }
        }
        else if (xpProg >= 40 && xpProg < 50)
        {
            data.PlayerDamage = 25;
            data.PlayerHeal = 25;
            data.PlayerMaxHP = 75;
            hud.SetHUD(unit);
            unit.LevelUp();
            xp = 5;
            SaveData();
            if (!data.level5)
            {
                OnEff();
                data.level5 = true;
            }
        }

        txtLevel.text = "Level: " + xp.ToString();
        SaveProgress();
    }

    void SaveData()
    {
        data.PlayerXp = xp;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(saveFilePath, json);
    }

    void SaveProgress()
    {
        data.PlayerXpProgress = xpProg;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(saveFilePath, json);
    }

    void LoadData()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            JsonUtility.FromJsonOverwrite(json, data);
        }
    }

    void OnEff()
    {
        Effect.gameObject.SetActive(true);
        Invoke("eff", 2f);
    }

    void eff()
    {
        Effect.gameObject.SetActive(false);
    }
}
