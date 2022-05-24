using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    
    public GameObject settingsCanvas;
    public bool settingsButton;
    // Start is called before the first frame update
    void Start()
    {
       settingsCanvas.SetActive(false);
        settingsButton = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void SettingsButton()
    {
        if(settingsButton == true)
        {
            settingsCanvas.SetActive(true);
            print("settingspressed");
        }
        
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("quiting");
    }
}
