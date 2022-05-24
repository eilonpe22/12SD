using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonProjectileScript : MonoBehaviour
{

    private float timer;
    [SerializeField] private float fireRate;
    public GameObject Projectile;
    public Transform cannonTarget;
    public Transform ProjectileOrigin;
    // Start is called before the first frame update
    void Start()
    {
        cannonTarget = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        OnShoot();
    }


    void OnShoot()
    {
        timer += Time.deltaTime;
        if (timer > fireRate)
        {
            //reset timer
            timer = 0;
            Instantiate(Projectile, ProjectileOrigin.position, transform.rotation);

        }
    }
}
