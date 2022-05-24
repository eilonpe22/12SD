using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private Image healthbar;
    public float currentHealth ;
    private float maxHealth ;
    PlayerController playerController;
    void Start()
    {
        healthbar = GetComponent<Image>();
        playerController = FindObjectOfType<PlayerController>();
        maxHealth = playerController.PlayerHP;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = playerController.PlayerHP;
        healthbar.fillAmount = currentHealth / maxHealth; 
    }
}
