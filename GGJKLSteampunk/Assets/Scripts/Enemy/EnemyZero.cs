using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZero : MonoBehaviour
{

    Vector3 position;
    Quaternion rotation;
    Boolean isAttacking = false;
    Animator animator;
    public float timeUntilArrived = 0.7f;
    public int direction = 0;

    public GameObject mainCharacter;
    // Start is called before the first frame update
    void Start()
    {
        position = gameObject.transform.position;
        animator = GetComponent<Animator>();
        rotation = gameObject.transform.rotation;

        /*
         * 0 = Right
         * 1 = Top
         * 2 = Left
         * 3 = Bottom
         */
        switch (direction)
        {
            case 0:
                animator.SetFloat("horrizontal", 1);
                break;
            case 1:
                animator.SetFloat("vertical", 1);
                break;
            case 2:
                animator.SetFloat("horrizontal", -1);
                break;
            case 3:
                animator.SetFloat("vertical", -1);
                break;
            default:
                Debug.Log("NUR WERTE ZWISCHEN 0 und 3!! Lies die Kommentare im Script Noob!");
                break;
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (!isAttacking)
        {
            isAttacking = true;
            StartCoroutine(attack());
        }

    }
    private void OnTriggerEnter2D(BoxCollider2D collider)
    {
        mainCharacter.GetComponent<inventarScript>().itemSteal();
    }

    IEnumerator attack()
    {

        yield return new WaitForSeconds(1);


        Vector3 targetPosition = new Vector3(GameObject.Find("MainCharacter").transform.position.x, GameObject.Find("MainCharacter").transform.position.y, GameObject.Find("MainCharacter").transform.position.z);
        Rigidbody2D rb = GameObject.Find("MainCharacter").GetComponent<Rigidbody2D>();

        Vector3 targetExpPos = new Vector3(targetPosition.x + ((float)rb.velocity.x * timeUntilArrived), targetPosition.y + ((float)rb.velocity.y * timeUntilArrived), targetPosition.z);
        float speed = Vector3.Distance(targetExpPos, position) / timeUntilArrived;

        /*
         * Um die Bewegungsrichtung zu bestimmen für die Animation
         */
        Vector3 directionVector = targetPosition - position;
        float directionAngle = Mathf.Atan2(directionVector.y, directionVector.x) * Mathf.Rad2Deg ;
        
        /*
         * 0 = Right
         * 1 = Top
         * 2 = Left
         * 3 = Bottom
         */
        int directionInDegree = (int)((Mathf.Round(directionAngle / 90f) + 4) % 4);

        /*
         * Callt den Animator und lässt so die entsprechende Animation laufen
         */
        Debug.Log(directionInDegree);
        switch (directionInDegree)
        {
            case 0:
                animator.SetFloat("horrizontal", 1);
                break;
            case 1:
                animator.SetFloat("vertical", 1);
                break;
            case 2:
                animator.SetFloat("horrizontal", -1);
                break;
            case 3:
                animator.SetFloat("vertical", -1);
                break;
            default:
                Debug.Log("Unmöglicher Fall im switch-DirectionAngle Block des EnemyZero Scriptes");
                break;
        }
        animator.SetFloat("speed", 1);
        while (Vector3.Distance(transform.position, targetExpPos) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetExpPos, speed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(1);
        speed = Vector3.Distance(transform.position, position) / timeUntilArrived;
        switch (directionInDegree)
        {
            case 0:
                animator.SetFloat("horrizontal", -1);
                break;
            case 1:
                animator.SetFloat("vertical", -1);
                break;
            case 2:
                animator.SetFloat("horrizontal", 1);
                break;
            case 3:
                animator.SetFloat("vertical", 1);
                break;
            default:
                Debug.Log("Unmöglicher Fall im switch-DirectionAngle Block des EnemyZero Scriptes beim Zurückgehen");
                break;
        }
        while (Vector3.Distance(transform.position, position) > 0.1f)
        {

            transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);
            yield return null;
        }
        isAttacking = false;
        animator.SetFloat("speed", 0);
        switch (directionInDegree)
        {
            case 0:
                animator.SetFloat("horrizontal", 1);
                break;
            case 1:
                animator.SetFloat("vertical", 1);
                break;
            case 2:
                animator.SetFloat("horrizontal", -1);
                break;
            case 3:
                animator.SetFloat("vertical", -1);
                break;
            default:
                Debug.Log("Unmöglicher Fall im switch-DirectionAngle Block des EnemyZero Scriptes");
                break;
        }

    }
}
