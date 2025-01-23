using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxInanim : MonoBehaviour
{
    public AudioSource source;

    public AudioClip clipWalk;

    public AudioClip clipHit;

    public AudioClip clipHeal;

    public AudioClip clipDodge;

    public AudioClip clipOpen;

    public AudioClip clipClose;


    public void Hit()
    {
        source = GetComponent<AudioSource>();
        float randomVolume = Random.Range(0.5f, 0.7f);
        source.PlayOneShot(clipHit,randomVolume);
    }

    public void walk()
    {
        float randomVolume = Random.Range(0.05f, 0.2f);

        source.PlayOneShot(clipWalk, randomVolume);
    }
    public void Heal()
    {
        float randomVolume = Random.Range(0.1f, 0.3f);

        source.PlayOneShot(clipHeal, randomVolume);
    }

    public void Dodge()
    {
        float randomVolume = Random.Range(0.1f, 0.3f);

        source.PlayOneShot(clipDodge, randomVolume);
    }

    public void Open()
    {
        float randomVolume = Random.Range(0.2f, 0.5f);

        source.PlayOneShot(clipOpen, randomVolume);
    }

    public void Close()
    {
        float randomVolume = Random.Range(0.05f, 0.2f);

        source.PlayOneShot(clipClose, randomVolume);
    }
}
