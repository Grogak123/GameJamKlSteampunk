using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPromptForCollectible : MonoBehaviour
{
    public GameObject Prompt;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Prompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Prompt.SetActive(false);
        }
    }
}
