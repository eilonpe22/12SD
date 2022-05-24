using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Itemspawner;

    [SerializeField] private PlayerController playerController;


    [SerializeField] private float Xbond = 5000f;
    [SerializeField] private float Zbond = 5000f;

    [SerializeField] private float Ybond = 10000f;
    [SerializeField] private Vector3 bondsMin;
    [SerializeField] private Vector3 bondsMax;
    [SerializeField] private float TimeTOSpawn = 2f;
    [SerializeField] private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        //  Vector3 pos = new Vector3(70, 200, 10);
        // Instantiate(playerMain, pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        TimeToSpawn();
    }
    void SpreadItems()
    {

        int Spread = Random.Range(0, Itemspawner.Length);
        // Vector3 randomPos = new Vector2(Random.Range(bondsMin.x, bondsMax.x), Random.Range(bondsMin.y, bondsMax.y));
        Vector3 randPlayePos = new Vector3(Random.Range(playerController.transform.position.x - Xbond, playerController.transform.position.x + Xbond),
            Random.Range(playerController.transform.position.y - Ybond, playerController.transform.position.y + Ybond),
            Random.Range(playerController.transform.position.y - Zbond, playerController.transform.position.z + Zbond));

        randPlayePos.x = Mathf.Clamp(randPlayePos.x, bondsMin.x, bondsMax.x);
        randPlayePos.y = Mathf.Clamp(randPlayePos.y, bondsMin.y, bondsMax.y);
        randPlayePos.z = Mathf.Clamp(randPlayePos.z, bondsMin.z, bondsMax.z);

        GameObject clone = Instantiate(Itemspawner[Spread], randPlayePos, Quaternion.identity);
        if (randPlayePos.y < -3.8f)
        {
            Destroy(this.gameObject);
        }

    }
    void TimeToSpawn()
    {
        currentTime += Time.deltaTime;




        if (currentTime > TimeTOSpawn)
        {
            SpreadItems();
            currentTime = 0;
        }
    }
}