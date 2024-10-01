using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField] GameObject featherParticalEffect;
    GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {

                GameObject ParticalSystem = Instantiate(featherParticalEffect, new Vector3(transform.position.x, transform.position.y, -0.03749491f), Quaternion.identity);
                gameController.Lose();
                Destroy(gameObject);
                Debug.Log("you lost");
        }
    }
}
