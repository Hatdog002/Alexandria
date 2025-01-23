using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;

public class ButtonHelp : MonoBehaviour
{
    public GameObject video;


    public void ontri()
    {
        video.gameObject.SetActive(true);
    }

    public void ontri2()
    {
        video.gameObject.SetActive(false);
    }

}
  
