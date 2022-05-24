using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSquadScript : MonoBehaviour
{
    public float canvasLifeTimer;
    public GameObject MainMenuCanvas;
    private void Awake()
    {
        
        gameObject.SetActive(true);
        Time.timeScale = 0;
        Destroy(gameObject, canvasLifeTimer);
        Time.timeScale = 1;
        MainMenuCanvas.SetActive(true);
    }
}
