using UnityEngine;
using System;
using System.Collections;

public class Clock : MonoBehaviour
{



    public RectTransform pointer;


    float referenceTime;

    
    public float seconds;


    // Update is called once per frame
    void Update()
    {
        referenceTime += Time.deltaTime;
        
        Debug.Log("refTime: " + Mathf.Round(referenceTime));
        pointer.rotation = Quaternion.Euler(0, 0, referenceTime / 360);
        Debug.Log(pointer.rotation);

        if(referenceTime > seconds)
        {
            Debug.Log("LOSER");
        }

    }

}