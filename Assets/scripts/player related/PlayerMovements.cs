using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] Animator playerAnim;
    [SerializeField]float xVelocity;
    Rigidbody2D rb;
    [SerializeField] float defaultSpeed = 5f; 
    [SerializeField] float boostedSpeed = 5f;
    float horizontalInput;
    Vector2 movementDirection;

    [SerializeField] float rotationSpeed; 
     float rotationAmount;
    [SerializeField] bool clockwise;
    [SerializeField] GameObject gfx;

    public bool movementsAllowed;

    public MovementType currentMovementType;
    public enum MovementType
    {
        Normal,
        Boosted,
        Reversed,
        Rotated,
     
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (movementsAllowed)
        {
            horizontalInput = (Input.GetAxis("Horizontal"));


            if (horizontalInput < 0 || horizontalInput > 0)
            {
                playerAnim.SetBool("moveIt", true);

            }
            else
            {
                playerAnim.SetBool("moveIt", false);
            }
            switch (currentMovementType)
            {
                case MovementType.Normal:
                    movementDirection = new Vector2(horizontalInput, 0);
                    transform.Translate(movementDirection * defaultSpeed * Time.deltaTime);
                    break;

                case MovementType.Boosted:
                    movementDirection = new Vector2(horizontalInput, 0);
                    transform.Translate(movementDirection * boostedSpeed * Time.deltaTime);
                    break;

                case MovementType.Reversed:
                    movementDirection = new Vector2(-horizontalInput, 0);
                    transform.Translate(movementDirection * defaultSpeed * Time.deltaTime);
                    break;

                case MovementType.Rotated:
                    if (clockwise)
                    {
                        rotationAmount = rotationSpeed * Time.deltaTime;
                    }
                    else
                    {
                        rotationAmount = -(rotationSpeed) * Time.deltaTime;
                    }
                    gfx.transform.Rotate(Vector3.forward, rotationAmount);
                    movementDirection = new Vector2(horizontalInput, 0);
                    transform.Translate(movementDirection * defaultSpeed * Time.deltaTime);
                    break;

            }
        }
       
    }

}

