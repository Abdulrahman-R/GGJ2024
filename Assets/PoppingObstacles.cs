using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoppingObstacles : MonoBehaviour
{
    // Start is called before the first frame update
    public ObsNum currentObsNum;
    [SerializeField] GameObject[] obsToPup;
    [SerializeField]float popingDlayTime;
    public enum ObsNum
    {
        One,
        Two,
        
    }
    void Start()
    {
        switch (currentObsNum)
        {
            case ObsNum.Two:
                StartCoroutine(PopingTwo());
                break;

            case ObsNum.One:
                StartCoroutine(PopingOne());
                break;
        }
    }

   

    IEnumerator PopingOne()
    {
        obsToPup[0].SetActive(false);
        yield return new WaitForSeconds(popingDlayTime);
        obsToPup[0].SetActive(true);
        yield return new WaitForSeconds(popingDlayTime);
        StartCoroutine(PopingOne());

    }
    IEnumerator PopingTwo()
    {
        obsToPup[0].SetActive(true);
        obsToPup[1].SetActive(false);
        yield return new WaitForSeconds(popingDlayTime);
        obsToPup[0].SetActive(false);
        obsToPup[1].SetActive(true);
        yield return new WaitForSeconds(popingDlayTime);
        StartCoroutine(PopingTwo());

    }

}
