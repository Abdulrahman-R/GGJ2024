using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] GameObject[] ObjetcsToSpawn;
     GameObject currentObjetcToSpawn;
    [SerializeField] GameObject ParticalEffect;
    public SpawningMode currentSpawningMode;
    GameController gameController;
    CameraShake cameraShake;
    AudioManager audioManager;
    public enum SpawningMode
    {
        Joy,
        Sad,
        Fear,
        Anger,
        Disgust,
    }
    // Start is called before the first frame update
    void Start()
    {
        cameraShake = FindObjectOfType<CameraShake>();
        gameController = FindObjectOfType<GameController>();
        audioManager = FindObjectOfType<AudioManager>();
        switch (currentSpawningMode)
        {
            case SpawningMode.Joy:

                currentObjetcToSpawn = ObjetcsToSpawn[0];
                break;

            case SpawningMode.Sad:

                currentObjetcToSpawn = ObjetcsToSpawn[1];
                break;

            case SpawningMode.Fear:

                currentObjetcToSpawn = ObjetcsToSpawn[2];
                break;
            case SpawningMode.Anger:

                currentObjetcToSpawn = ObjetcsToSpawn[3];
                break;

            case SpawningMode.Disgust:

                currentObjetcToSpawn = ObjetcsToSpawn[4];
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("hit player");
            // collision.gameObject.GetComponent<PlayerMovements>().movementsAllowed = true;
            //collision.gameObject.GetComponent<Shooting>().shootingAllowed = true;
            //collision.gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            Vector3 spwanPose = collision.transform.position;
           // Destroy(collision.gameObject);
           // GameObject projectile = Instantiate(currentObjetcToSpawn, spwanPose, Quaternion.identity);
            GameObject ParticalSystem = Instantiate(ParticalEffect, new Vector3(transform.position.x, transform.position.y, -0.03749491f), Quaternion.identity);
            cameraShake.ShakeIt();
            audioManager.PlaySound("emojiExplosion");
            Destroy(gameObject);
        }

        if (collision.CompareTag("border") || collision.CompareTag("enemy"))
        {
            GameObject ParticalSystem = Instantiate(ParticalEffect, new Vector3(transform.position.x, transform.position.y, -0.03749491f), Quaternion.identity);
            cameraShake.ShakeIt();
            audioManager.PlaySound("emojiExplosion");
            gameController.Lose();
            Destroy(gameObject);
            Debug.Log("you lost");
        }

        if (collision.CompareTag("king"))
        {
            GameObject ParticalSystem = Instantiate(ParticalEffect, new Vector3(transform.position.x, transform.position.y, -0.03749491f), Quaternion.identity);
            Debug.Log("you won");
            cameraShake.ShakeIt();
            Destroy(collision.gameObject);
           // audioManager.PlaySound("emojiExplosion");
            gameController.Win();
            Destroy(gameObject);
        }
    }

}
