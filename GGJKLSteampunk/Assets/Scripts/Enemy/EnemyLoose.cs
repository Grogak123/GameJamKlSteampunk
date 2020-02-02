using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoose : MonoBehaviour
{
    Vector3 position;
    Animator animator;
    public float timeUntilArrived = 1.5f;
    bool isAttacking = false;
    // Start is called before the first frame update
    void Start()
    {
        position = gameObject.transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       if(!isAttacking)
        {
            isAttacking = true;
            StartCoroutine(attack());
        }
        
    }

    IEnumerator attack()
    {

        yield return new WaitForSeconds(1);


        Vector3 targetPosition = new Vector3(-11, -2.42f, 0);
        
        float speed = Vector3.Distance(targetPosition, position) / timeUntilArrived;

        /*
         * Um die Bewegungsrichtung zu bestimmen für die Animation
         */
        Vector3 directionVector = targetPosition - position;
        float directionAngle = Mathf.Atan2(directionVector.y, directionVector.x) * Mathf.Rad2Deg;

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
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
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
