using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideEnemy : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private float speedAtShoting;
    [SerializeField] private float laserDMG;
    [SerializeField] private float minDist;
    public Transform atackPoint;
    public GameObject laser;
    public Transform playerLoaction;
    PlayerController playerController;
    public float spaceBetween;
    public GameObject[] AI;
    public GameManager gameManager;
    public GameObject Explosion1;
    Rigidbody rb;
    
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        AI = GameObject.FindGameObjectsWithTag("Enemy");
        playerLoaction = playerController.playerBody;
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //need to change the " set active " to health system.
            playerController.PlayerHP = playerController.PlayerHP - 20;
            //make the enemy disapear .
            GameObject GO = Instantiate(Explosion1, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(GO, 5);

        }
        if (other.tag == "Laser")
        {

            gameManager.GetComponent<GameManager>().enemyCounter++;
            
           GameObject GO = Instantiate(Explosion1, transform.position, Quaternion.identity);

            Debug.Log("12");
          
            Destroy(other.gameObject);
            Destroy(gameObject);
            Destroy(GO,5);

        }
        if (other.tag == "Ground")
        {
            GameObject GO = Instantiate(Explosion1, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        EmemySepration();
    }
    private void FixedUpdate()
    {

        EnemyMovement();


    }
    void EmemySepration()
    {
        // seperate the enemys from each other 
        foreach (GameObject go in AI)
        {
            if (go != gameObject && go != null)
            {
                float distance = Vector3.Distance(go.transform.position, this.transform.position);
                if (distance <= spaceBetween)
                {
                    Vector3 direction = transform.position - go.transform.position;
                    transform.Translate(direction * Time.deltaTime);
                }
            }

        }
    }
    void EnemyMovement()
    {
        //make the object move towards the player .
        transform.position = Vector3.MoveTowards(transform.position, playerLoaction.transform.position, speed * Time.deltaTime);
        //make the object face the player .
        transform.LookAt(playerLoaction);
        float dist = Vector3.Distance(playerLoaction.transform.position, transform.position);
        if (dist < minDist)
        {
            Instantiate(laser, atackPoint.position, transform.rotation);
            transform.position = Vector3.MoveTowards(transform.position, playerLoaction.transform.position, speed * Time.deltaTime);
        }
        
    }
}
