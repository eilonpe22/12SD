using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool restartButton;
    public int enemyCounter;
    public int enemyGoals;
    [SerializeField]
    private Text _counterText;
    [SerializeField]
    private GameObject endGame;
    [SerializeField]
    private GameObject winGame;
    public PlayerController playerController;
    private int life;
    [SerializeField]
    private GameObject player;
    public Vector3 playerStartPos;
    public Vector3 playerStartRotation;
    private bool pauseButton;
    public GameObject PauseCanvas;
    public GameObject HUDcanvas;
    public bool escButton;
    public bool TabButton;
    public GameObject ControlsCanvas;
   
    public bool isPaused;

    private void Awake()
    {
        HUDcanvas.SetActive(true);
        GameObject go = Instantiate(player, playerStartPos, Quaternion.Euler(playerStartRotation));
        playerController = go.GetComponent<PlayerController>();
    }
    void Start()
    {
        
        restartButton = false;


    }

    // Update is called once per frame
    void Update()
    {
        _counterText.text = enemyGoals + " / " + enemyCounter;
        OnRestart();
        OnVictory();
        OnLost();
        OnPause();
        OnESC();
        OnControls();
        
        // Time.timeScale = 0;//stoping game/freeze time
        // Time.timeScale = 1;//start game/normal tine
        // Time.timeScale = 0.1-0.9;//slow mo

    }
    public void OnRSTButton(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            restartButton = true;
        }
        if (context.canceled)
        {
            restartButton = false;
        }


    }
    void OnRestart()
    {
        if (restartButton)
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 0;
        Time.timeScale = 1;
    }
    void OnVictory()
    {
        if (enemyCounter == enemyGoals)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            winGame.SetActive(true);
            Time.timeScale = 0;
            
        }
    }
    void OnLost()
    {
        life = playerController.PlayerHP;
        if (life <= 0)
        {

            endGame.SetActive(true);
            Time.timeScale = 0;

        }
    }
    public void OnPauseButton(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            pauseButton = true;
            

        }
        if (context.canceled)
        {
            pauseButton = false;
        }




    }

    public void OnEscButton(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
           escButton = true;
        }
        if (context.canceled)
        {
            escButton = false;
        }


    }
    public void OnESC()
    {
        if (escButton)
        {
            Time.timeScale = 1;
            PauseCanvas.SetActive(false);
            
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    public void OnPause()
    {
        if (pauseButton)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            PauseCanvas.SetActive(true);
            Time.timeScale = 0;
           
        }
          
    }

    void OnControls()
    {
        if (TabButton)
        {
            ControlsCanvas.SetActive(true);
        }
        else
            ControlsCanvas.SetActive(false);
    }

    public void OnControlTab(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            TabButton = true;
        }
        if (context.canceled)
        {
            TabButton = false;
        }

    }
    public void BackToMainMenu() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameMainMenu", LoadSceneMode.Single);
    }

    public void LoadNextLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}