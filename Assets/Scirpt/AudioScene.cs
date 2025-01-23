using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class AudioScene : MonoBehaviour
{
    private static AudioScene instance;
    public AudioSource audioSource; // Reference your AudioSource in the Inspector
    public AudioClip bgm;

    void Awake()
    {
       
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        audioSource.clip = bgm;

        audioSource.Play();
    }

    public void Update()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (new[] { "Level-0", "Level1", "MainMenu", "LevelMenu", "Level2", "Level3", "Level4", "Level5", "Level6", "GameOver", "Loading", "TutorialLevel" }.Contains(sceneName))
        {
            Destroy(gameObject);
        }
    }


}
