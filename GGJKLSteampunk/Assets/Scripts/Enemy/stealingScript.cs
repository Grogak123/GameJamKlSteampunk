using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stealingScript : MonoBehaviour
{
    public GameObject mainCharacter;
    public GameObject mainCharacterWithAnimator;
    private bool gotHit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collider2D)
    {

        if (collider2D.gameObject.CompareTag("Player") && !gotHit)
        {
            gotHit = true;
                mainCharacter.GetComponent<inventarScript>().itemSteal();
            mainCharacterWithAnimator.GetComponent<Animator>().SetBool("isHit", true);
            StartCoroutine(wait());

        }

    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        mainCharacterWithAnimator.GetComponent<Animator>().SetBool("isHit", false);
        gotHit = false;

    }
}
