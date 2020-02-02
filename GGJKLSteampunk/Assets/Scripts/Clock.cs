using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

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
        
        pointer.rotation = Quaternion.Euler(0, 0, -test);


        if(referenceTime > seconds)
        {
            SceneManager.LoadScene("lose");
        }

    }

    void OutputTime()
    {
        test += (360 / seconds);
    }

}