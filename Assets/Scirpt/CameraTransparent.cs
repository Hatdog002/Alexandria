using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransparent : MonoBehaviour
{
    private ObjectFade fader;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            Vector3 dir = player.transform.position - transform.position;
            Ray ray = new Ray(transform.position, dir);
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);

            if (Physics.Raycast(ray, out hit))
            {
                 
                if (hit.collider == null)
                    return;

                if (hit.collider.gameObject == player)
                {
                    if (fader != null)
                    {
                        fader.FadeOccur = false;
                        Debug.Log("fade  false");
                    }
                }

                else
                {
                    fader = hit.collider.gameObject.GetComponent<ObjectFade>();
                    if (fader != null)
                    {
                        fader.FadeOccur = true;
                        Debug.Log("fade  true");
                    }
                }
            }
        
        }
    }

    
}
