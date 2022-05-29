using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class LaserScript : MonoBehaviour
{
    public float fireSpeed = 10f;
    public float destroyLaserTime;
    public int deadEnemysGoal;
    private int counter;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        LaserDMG();
        //gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        LaserBehavior();
    }
    void LaserBehavior()
    {
        transform.position += transform.forward * fireSpeed * Time.deltaTime;
    }
    void LaserDMG()
    {
        Destroy(gameObject, destroyLaserTime);
    }


}


