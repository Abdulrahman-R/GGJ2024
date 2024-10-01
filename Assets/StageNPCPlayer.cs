using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageNPCPlayer : MonoBehaviour
{
    [SerializeField] GameObject currentPlayer;
    [SerializeField] GameObject currentNPC;
    [SerializeField] int backgroundIndex;
    GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        currentPlayer.transform.parent = currentNPC.transform;
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
       // transform.position = currentNPC.transform.position;
    }

    public void FromNpcToPlayer()
    {
        gameController.ChangeBackground(backgroundIndex);
        currentPlayer.transform.parent = currentNPC.transform;
        currentPlayer.transform.parent = transform;
        currentNPC.SetActive(false);
        currentPlayer.SetActive(true);
    }
}
