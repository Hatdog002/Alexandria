using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceScript : MonoBehaviour
{

    private Vector3 RigtPos;
    public bool InRightPos;
    // Start is called before the first frame update
    void Start()
    {
        RigtPos = transform.position;
        transform.position = new Vector3(Random.Range(1000f, 1500f), Random.Range(100f, 1000f));
    }

    // Update is called once per frame
    
}
