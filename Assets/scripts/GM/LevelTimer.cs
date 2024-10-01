using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    GameController gameController;
    [SerializeField] Sprite[] kingStatusImages;
   [SerializeField] Image currentKingStatusImage;
     public float duration;
     float TimeLeft;
     bool TimerOn = false;

    AudioSource audioSource;

    public GameObject TimerTxt;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        TimeLeft = duration;
        TimerOn = true;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                Debug.Log("Time is UP!");
                TimeLeft = 0;
                TimerOn = false;
                
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        if (minutes <= 0 && seconds <= duration * 0.0 )
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            gameController.Lose();
           // gameObject.SetActive(false);
        }else if (minutes <= 0 && seconds <= duration * 0.3)
        {
            currentKingStatusImage.sprite = kingStatusImages[2];
            TimerTxt.GetComponent<TMP_Text>().color = Color.red;
            if (!(audioSource.isPlaying))
            {
                audioSource.Play();
            }
            
        }
        else if (minutes <= 0 && seconds <= duration * 0.5) {
           // TimerTxt.GetComponent<TMP_Text>().color = Color.yellow;
            currentKingStatusImage.sprite = kingStatusImages[1];
        }
        else if (minutes <= 0 && seconds <= duration * 0.7)
        {
            currentKingStatusImage.sprite = kingStatusImages[0];
            //TimerTxt.GetComponent<TMP_Text>().color = Color.green;
        }
        TimerTxt.GetComponent<TMP_Text>().text = "" + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
