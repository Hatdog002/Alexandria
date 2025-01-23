using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsSFX : MonoBehaviour
{
    public AudioSource Sfx;
    public AudioClip hover;
    public AudioClip click;

    public void Hover()
    {
        Sfx.PlayOneShot(hover);
    }

    public void Click()
    {
        Sfx.PlayOneShot(click);
    }
}
