using System.IO;
using UnityEngine;

public class UnderstandCheck : MonoBehaviour
{
    [Header("References")]
    public PlayerLUnderstand levelCheck; // Reference to the ScriptableObject
    public TutorialManager done;


    // Set difficulty to Low
    public void Low()
    {
        done.checkingDone();
        PlayerPrefs.SetFloat("QuestionTimer", 10f);
        PlayerPrefs.SetFloat("MissionTimer", 10f);
        PlayerPrefs.Save();

    }

    // Set difficulty to Mid
    public void Mid()
    {
        done.checkingDone();

        PlayerPrefs.SetFloat("QuestionTimer", 7f);
        PlayerPrefs.SetFloat("MissionTimer", 5f);
        PlayerPrefs.Save();
    }

    // Set difficulty to High
    public void High()
    {
        done.checkingDone();
        PlayerPrefs.SetFloat("QuestionTimer", 5f);
        PlayerPrefs.SetFloat("MissionTimer", 3f);
        PlayerPrefs.Save();

    }

   
   
}
