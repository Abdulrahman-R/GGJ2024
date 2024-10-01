using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDetection : MonoBehaviour
{
    GameObject NPCManager;
    // Start is called before the first frame update
    void Start()
    {
        NPCManager = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("pr"))
        {
            Debug.Log("i have kikced");
            NPCManager.GetComponent<StageNPCPlayer>().FromNpcToPlayer();
        }
    }
}
