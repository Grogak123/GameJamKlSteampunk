using UnityEngine;
using System;
using System.Collections;

public class Clock : MonoBehaviour
{



    public RectTransform pointer;


    float referenceTime;
    float test;
    
    public float seconds;

    float elapsed = 0f;

    // Update is called once per frame
    void Update()
    {

        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
            OutputTime();
        }

        referenceTime += Time.deltaTime;
        
        Debug.Log("refTime: " + Mathf.Round(referenceTime));
        pointer.rotation = Quaternion.Euler(0, 0, -test);
        Debug.Log(pointer.rotation);

        if(referenceTime > seconds)
        {
            Debug.Log("LOSER");
        }

    }

    void OutputTime()
    {
        test += (360 / seconds);
    }

}