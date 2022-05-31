using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBarScript : MonoBehaviour
{
    public Image healthbar;
    public float currentHealth ;
    private float maxHealth ;
    SuicideEnemy enemy;
    void Start()
    {
        healthbar = GetComponent<Image>();
        enemy = FindObjectOfType<SuicideEnemy>();
        maxHealth = enemy.enemyHealth;
     
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = enemy.enemyHealth;
        
        healthbar.fillAmount = currentHealth / maxHealth; 
    }
}
