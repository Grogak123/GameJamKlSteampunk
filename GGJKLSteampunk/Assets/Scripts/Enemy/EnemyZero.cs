using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZero : MonoBehaviour
{

    Vector3 position;
    Boolean isAttacking = false;

    public float timeUntilArrived = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        position = gameObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (!isAttacking)
        {
            isAttacking = true;
            StartCoroutine(attack());
        }

    }


    IEnumerator attack()
    {

        yield return new WaitForSeconds(1);

        /*
         * Einfügen Sprunganimation
         */

        Vector3 targetPosition = new Vector3(GameObject.Find("MainCharacter").transform.position.x, GameObject.Find("MainCharacter").transform.position.y, GameObject.Find("MainCharacter").transform.position.z);
        Rigidbody2D rb = GameObject.Find("MainCharacter").GetComponent<Rigidbody2D>();

        Vector3 targetExpPos = new Vector3(targetPosition.x + ((float)rb.velocity.x * timeUntilArrived), targetPosition.y + ((float)rb.velocity.y * timeUntilArrived), targetPosition.z);
        float speed = Vector3.Distance(targetExpPos, position) / timeUntilArrived;
        while (Vector3.Distance(transform.position, targetExpPos) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetExpPos, speed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(1);
        speed = Vector3.Distance(transform.position, position) / timeUntilArrived;
        while (Vector3.Distance(transform.position, position) > 0.1f)
        {

            transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);
            yield return null;
        }
        isAttacking = false;       
        
    }
}
