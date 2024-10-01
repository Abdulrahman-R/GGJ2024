using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    LevelLoader levelLoader;
    [SerializeField] GameObject gamePlayPanel;
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject firstPlayer;
    [SerializeField] GameObject levelTimer;
    GameObject background;
    [SerializeField]Material[] backgroundMaterial;

    [SerializeField] float delayTime;
    AudioManager audioManager;
    bool doOnce;
    // Start is called before the first frame update
    void Start()
    {
        background = GameObject.Find("BackGroundPlane");
        audioManager = FindObjectOfType<AudioManager>();
        levelLoader = FindObjectOfType<LevelLoader>();
    }

    private void Update()
    {
        if(doOnce == false)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                doOnce = true;
                firstPlayer.GetComponent<PlayerMovements>().movementsAllowed = true;
                firstPlayer.GetComponent<Shooting>().shootingAllowed = true;
                levelTimer.SetActive(true);
            }
        }
      
    }

    public void Win()
    {
       
        StartCoroutine(Wining());
    }

    public void Lose()
    {
        StartCoroutine(Losing());
    }


    IEnumerator Wining()
    {
        audioManager.PlaySound("kingLaugh");
        ChangeBackground(5);
        levelTimer.SetActive(false);
        yield return new WaitForSeconds(delayTime);
        gamePlayPanel.SetActive(false);
        winPanel.SetActive(true);
        levelLoader.nextAllowed = true;
        Time.timeScale = 0;
    }

    IEnumerator Losing()
    {
        audioManager.PlaySound("kingCry");
        ChangeBackground(5);
        levelTimer.SetActive(false);
        yield return new WaitForSeconds(delayTime);
        gamePlayPanel.SetActive(false);
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }


    public void ChangeBackground(int index)
    {
        background.GetComponent<MeshRenderer>().material = backgroundMaterial[index];
    }
}
