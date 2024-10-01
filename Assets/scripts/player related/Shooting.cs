using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    CameraShake cameraShake;
    public GameObject[] projectilePrefabs;
    GameObject currentprojectilePrefab;
    public GameObject timer;
    public Transform shootPoint;
    public float shootForce = 10f;
    public bool shootingAllowed;
    AudioManager audioManager;
    [SerializeField] GameObject featherParticalEffect;

    public ShootingMode currentShootingMode;
    public enum ShootingMode
    {
        Normal,
        Forced,
        Delayed,
    }
    public ProjectileType currentProjectileType;
    public enum ProjectileType
    {
        Joy,
        Sad,
        Fear,
        Anger,
        Disgust,
    }

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        cameraShake = FindObjectOfType<CameraShake>();
            switch (currentProjectileType)
            {
                case ProjectileType.Joy:

                    currentprojectilePrefab = projectilePrefabs[0];
                    break;

                case ProjectileType.Sad:

                    currentprojectilePrefab = projectilePrefabs[1];
                    break;

                case ProjectileType.Fear:

                    currentprojectilePrefab = projectilePrefabs[2];
                    break;
            case ProjectileType.Anger:

                    currentprojectilePrefab = projectilePrefabs[3];
                    break;

            case ProjectileType.Disgust:

                    currentprojectilePrefab = projectilePrefabs[4];
                    break;
            }


       
    }
    void Update()
    {
        if(Time.timeScale <= 0)
        {
            shootingAllowed = false;
        }
        if (shootingAllowed)
        {

            switch (currentShootingMode)
            {
                case ShootingMode.Normal:
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Shoot();
                    }

                    break;

                case ShootingMode.Forced:

                    if(timer.activeInHierarchy == false)
                    {
                        timer.SetActive(true);
                    }
                  
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Shoot();
                    }

                    break;

                case ShootingMode.Delayed:
                   
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        timer.SetActive(true);
                       shootingAllowed = false;
                    }

                    break;
            }

           
        }
       
    }

    public void Shoot()
    {

        //-0.04798577 to be changed
        shootingAllowed = false;
        cameraShake.ShakeIt();
        //gameObject.GetComponent<PlayerMovements>().movementsAllowed = false;
        GameObject projectile = Instantiate(currentprojectilePrefab, new Vector3(shootPoint.transform.position.x,shootPoint.transform.position.y, -0.04798577f), Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.AddForce(shootPoint.transform.up * shootForce, ForceMode2D.Impulse);
        }
        GameObject featherParticalSystem = Instantiate(featherParticalEffect, new Vector3(transform.position.x, transform.position.y, -0.03749491f), Quaternion.identity);
        audioManager.PlaySound("chickenExplosion");
        Destroy(gameObject);
    }
}
