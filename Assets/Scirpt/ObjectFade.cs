using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFade : MonoBehaviour
{
    public float fadespeed, fadeamount;
    float originalOpa;
    Material material;
    public bool FadeOccur = false;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        originalOpa = material.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (FadeOccur)
            Fade();
        else if(!FadeOccur)
            Resetfade();
    }

    void Fade()
    {
        Color currrentColor = material.color;
        Color smoothFade = new Color(currrentColor.r, currrentColor.g, currrentColor.b, Mathf.Lerp(currrentColor.a, fadeamount, fadespeed*Time.deltaTime));
        material.color = smoothFade;
    }

    void Resetfade()
    {
        Color currrentColor = material.color;
        Color smoothFade = new Color(currrentColor.r, currrentColor.g, currrentColor.b, Mathf.Lerp(currrentColor.a, originalOpa, fadespeed * Time.deltaTime));
        material.color = smoothFade;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FadeOccur = false;
        }
    }
}
