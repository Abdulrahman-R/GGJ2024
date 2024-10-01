using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] Sprite currentImageStatus;
    Image imageStatusRef;
    // Start is called before the first frame update
    void Start()
    {
        imageStatusRef = GameObject.FindGameObjectWithTag("CS").GetComponent<Image>();
        imageStatusRef.sprite = currentImageStatus;
    }
}
