using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovements : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] bool isRight;
    public bool movementsAllowed;
    public bool isDynamic;
   [SerializeField] Animator npcAnim;
    float xVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        xVelocity = rb.velocity.x;
    }

    private void FixedUpdate()
    {

        if (movementsAllowed)
        {
            xVelocity = rb.velocity.x;
            if (Mathf.Abs(xVelocity) > 0.1)
            {
                //npcAnim.SetFloat("xVelocity", xVelocity);
                npcAnim.SetBool("moveIt", true);
            }
            else
            {
                npcAnim.SetBool("moveIt", false);
            }
            if (isDynamic)
            {
                if (isRight)
                {
                    Debug.Log("is right");
                    rb.velocity = new Vector2(Time.deltaTime * speed, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(Time.deltaTime * speed * -1, rb.velocity.y);
                }

            }

        }





        /*
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("RP"))
            {

                if (isVertical)
                {
                    isUp = !(isUp);
                }
                else
                {
                    isRight = !(isRight);
                }
            }
        }
        */

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("border"))
        {

          
            isRight = !(isRight);
           
        }

    }
}


