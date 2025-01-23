using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public float SceneAt;
    public float DialougeAt;
    public TextMeshProUGUI textquest;
    public TextMeshProUGUI textDialougePlayer;
    public TextMeshProUGUI textDialougePlayerConvo;
    public TextMeshProUGUI textDialougeNPC;

    public Animator[] targetAnimator;
    public float delayBetweenAnimations = 1.0f;


    // Start is called before the first frame update
    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneAt == 1)
        {
            textDialougePlayer.text = "I see smoke, there must be a camp nearby";
            textDialougeNPC.text = "Who Are you?";
            textquest.text = "Find the source of the smoke";
          
        }
        if (SceneAt ==2)
        {
          
            if (DialougeAt == 1)
            {
                textDialougePlayerConvo.text = "I come in peace! I’m searching for a group of people to join.";
            }
            if (DialougeAt == 2)
            {
                textDialougePlayerConvo.text = "I saw the smoke so I thought there’d be people over there, did you make that fire by any chance?";
            }
        }

        if (SceneAt == 3)
        {
            if (DialougeAt == 3)
            {
                textDialougeNPC.text = "Follow";
                textquest.text = "Follow other Survivor";
            }
            if (DialougeAt == 4)
            {
                StartCoroutine(PlayWithDelay());
            }
        }
    }


    IEnumerator PlayWithDelay()
    {
        // Loop through each Animator component in the array
        foreach (Animator animator in targetAnimator)
        {
            // Trigger the animation by setting a trigger parameter
            animator.SetTrigger("PlayWalk"); // Replace "TriggerName" with the name of your animation trigger

            // Wait for the specified delay
            yield return new WaitForSeconds(delayBetweenAnimations);
        }
    }
}
