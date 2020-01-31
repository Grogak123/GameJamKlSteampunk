using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public string GameSceneName;
    public void LoadGameScene()
        {

            if (GameSceneName != null)
            {
                SceneManager.LoadScene(GameSceneName);
            }
            else
            {
                Debug.Log("Please set the String for scene Name");
            }
        }
}
