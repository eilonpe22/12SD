using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public float fireSpeed = 10f;
    public float destroyLaser;
    public int deadEnemysGoal;
    public int LaserDamege;
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
        Destroy(gameObject, destroyLaser);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            other.GetComponent<PlayerController>().PlayerHP -= LaserDamege;
        }
    }
}