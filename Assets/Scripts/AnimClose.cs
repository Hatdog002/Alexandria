using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimClose : MonoBehaviour
{
    public GameObject objctToClose;
    public void Close()
    {
        objctToClose.gameObject.SetActive(false);
    }
}
