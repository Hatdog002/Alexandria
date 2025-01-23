using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleTriggerNextScene : MonoBehaviour
{
    public string currentSceneName;
    public PuzzleManager puzzle;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (puzzle.thePuzzleOver == true)
            {
                SceneManager.LoadScene(currentSceneName);
            }
            else
            {
                Debug.Log("Finish the Puzzle");
            }
           
        }

    }
}

