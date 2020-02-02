using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamejam
{
    public class MainCharacterMovement : MonoBehaviour
    {

        private Animator thisAnimator;

        Rigidbody2D body;

        float horizontal;
        float vertical;
        float moveLimiter = 0.7f;
        float speed;

        public float runSpeed = 20.0f;

        void Start()
        {
            thisAnimator = GetComponent<Animator>();
            body = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            // Gives a value between -1 and 1
            horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
            vertical = Input.GetAxisRaw("Vertical"); // -1 is down
            if (horizontal == 0 && vertical == 0)
            {
                speed = 0;
            }
            else
            {
                speed = 1;
            }

            thisAnimator.SetFloat("Horizontal", horizontal);
            thisAnimator.SetFloat("Vertical", vertical);
            thisAnimator.SetFloat("Speed", speed);

            
        }

        void FixedUpdate()
        {
            if (horizontal != 0 && vertical != 0) // Check for diagonal movement
            {
                // limit movement speed diagonally, so you move at 70% speed
                horizontal *= moveLimiter;
                vertical *= moveLimiter;
            }

            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }
    }

}
