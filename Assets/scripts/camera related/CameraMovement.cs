using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    GameObject projectile;
    float cameraOffset;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        projectile = GameObject.FindGameObjectWithTag("pr");
        if(projectile != null)
        {

            float yOffset = transform.position.y - projectile.transform.position.y;
            if (projectile.GetComponent<Rigidbody2D>().velocity.y < 0 )
            {
                transform.position = new Vector3(transform.position.x, projectile.transform.position.y + yOffset, transform.position.z);
            }
           
        }
        
    }
}
