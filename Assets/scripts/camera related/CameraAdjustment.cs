using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjustment : MonoBehaviour
{
    GameObject mainCamera;
    float camYoffset;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        if (mainCamera != null)
        {
          camYoffset = mainCamera.transform.position.y - transform.position.y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(mainCamera != null)
        {
            if (GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, (transform.position.y+(-1)) + camYoffset, mainCamera.transform.position.z);
            }
        }
    }
}
