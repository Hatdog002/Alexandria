using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMChange : MonoBehaviour
{
    public LevelManager inside;

    public QuestionUi Battle;


    public AudioClip Bgm1;
    public AudioClip Bgm2;
    public AudioClip battle;


    public float fadeDuration = 2.0f;
    private float elapsedTime = 0f;
    public AudioSource Saudio;
    // Start is called before the first frame update
    void Start()
    {
        Saudio.clip = Bgm1;
        Saudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Saudio != null && Battle != null && inside != null)
        {
            AudioClip newClip = null;

            if (Battle.states == BattleStates.PlayerTurn || Battle.states == BattleStates.Question || Battle.states == BattleStates.EnemyTurn || Battle.states == BattleStates.Won || Battle.states == BattleStates.Lost)
            {
                newClip = battle;
            }
            else if (inside.PlayerInside)
            {
                newClip = Bgm2;
            }
            else if (!inside.PlayerInside)
            {
                newClip = Bgm1;
            }

            // Only change clip if it's different
            if (Saudio.clip != newClip)
            {
                Saudio.clip = newClip;
                float t = elapsedTime / fadeDuration;
                Saudio.volume = Mathf.Lerp(1, 0,t);
                Saudio.Play();
            }
        }
    }
}
