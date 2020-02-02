using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToWhite : MonoBehaviour
{
    public static Texture2D Fade;
    public bool fadingOut = false;
    public float alphaFadeValue = 0;
    public float fadeSpeed = 1;

    void Start()
    {
        if (Fade == null)
        {
            Fade = new Texture2D(1, 1);
            Fade.SetPixel(0, 0, new Color(1, 1, 1, 1));

        }
    }

    // Update is called once per frame
    void OnGUI()
    {
        alphaFadeValue = Mathf.Clamp01(alphaFadeValue + ((Time.deltaTime / fadeSpeed) * (fadingOut ? 1 : -1)));
        if (alphaFadeValue != 0)
        {
            GUI.color = new Color(1, 1, 1, alphaFadeValue);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Fade);
        }
    }

}