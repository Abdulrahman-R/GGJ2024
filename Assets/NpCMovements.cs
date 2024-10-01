using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpCMovements : MonoBehaviour
{
    [SerializeField] bool isStatic;
    public bool movementsAllowed;
    public NPCMovementType currentNPCMovementType;
    public enum NPCMovementType
    {
        Static,
        Dynamic,
    }
    // Start is called before the first frame update
    void Start()
    {

       
       
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentNPCMovementType)
        {
            case NPCMovementType.Static:
                break;

            case NPCMovementType.Dynamic:

                break;



        }
    }
}
