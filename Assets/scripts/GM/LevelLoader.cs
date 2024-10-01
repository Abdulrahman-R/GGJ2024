using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
   public Animator animator;
    public float transitionTime;
   public bool nextAllowed;
    // Update is called once per frame

    private void Start()
    {
        nextAllowed = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();


        }

        if(nextAllowed == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LoadNextLevel();


            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            LoadLevelByIndex(0);

        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void ReloadLevel()
    {
        
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        animator.SetTrigger("start");
        Time.timeScale = 1;
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void LoadLevelByIndex(int levelIndex)
    {
        StartCoroutine(LoadLevel(levelIndex));
    }

   
    public void QuitGame()
    {

        Application.Quit();
    }

}
