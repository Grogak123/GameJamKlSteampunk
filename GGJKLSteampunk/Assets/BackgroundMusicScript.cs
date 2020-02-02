using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundMusicScript : MonoBehaviour
{

    public AudioSource StartClip;
    public AudioSource LoopClip;
    // Start is called before the first frame update
    void Start()
    {
        StartClip.Play();
        LoopClip.PlayDelayed(11.0f);
    }


}
