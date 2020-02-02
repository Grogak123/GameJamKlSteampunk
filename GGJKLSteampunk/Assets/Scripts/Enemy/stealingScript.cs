using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stealingScript : MonoBehaviour
{
    public GameObject mainCharacter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Player"))
        {
            Debug.Log("Try Stealing!!!!!!!!!!!");
          
                Debug.Log("Stoooooooooooooooooooolen");
                mainCharacter.GetComponent<inventarScript>().itemSteal();
      

        }

    }
}
