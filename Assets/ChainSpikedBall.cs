using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainSpikedBall : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    float rotationAmount;
    [SerializeField] bool clockwise;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if (clockwise)
        {
            rotationAmount = rotationSpeed * Time.deltaTime;
        }
        else
        {
            rotationAmount = -(rotationSpeed) * Time.deltaTime;
        }

        transform.Rotate(Vector3.forward, rotationAmount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RRP"))
        {
            clockwise = !(clockwise);
        }
    }
}
