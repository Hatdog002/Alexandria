using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TriggerTimeline : MonoBehaviour
{

    public PlayableDirector director;

    public bool door1;
    public bool door2;

    public void Start()
    {
        if (door1)
        {
            director.Stop();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (door1)
            {
                director.Play();
            }
           

            if (door2)
            {
                SceneManager.LoadScene("CutS1");
            }
        }
    }
}
