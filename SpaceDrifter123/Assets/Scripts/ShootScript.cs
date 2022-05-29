using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ShootScript : MonoBehaviour
{
    // Shooting inputs
    public int damage;
    public float FireRate, spread, range, reloadTime, timeBetweenShots, timeToOverHeat;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    public bool MGactive;
    int bulletsLeft, bulletShot;
    bool shooting, readyToShoot, reloading;
    private float timer;
    public float overHeatTimer;
    [SerializeField]
    private float coldownSpeed;


    //refrence
    public Camera fpsCam;
    public Transform atackPoint;
    public Transform atackPoint2;
    public Transform MGatackPoint1;
    public Transform MGatackPoint2;
    public Transform MGatackPoint3;
    public Transform MGatackPoint4;
    public Transform MGatackPoint5;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;
    public GameObject laser;
    public GameObject laser2;
    public GameObject MGlaser;
    public GameObject MGlaser2;
    // Start is called before the first frame update
    void Start()
    {
        shooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        NormalShot();
        OverHeat();
        
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            shooting = true;
        }
        if (context.canceled)
        {
            shooting = false;
        }


    }
    void NormalShot()
    {
       
        if  (shooting && allowButtonHold)
        {
            //starting timer
            timer += Time.deltaTime;
            if (timer > timeBetweenShots)
            {
                
                //reset timer
                timer = 0;
                Instantiate(laser, atackPoint.position, transform.rotation);
                Instantiate(laser2, atackPoint2.position, transform.rotation);
                Debug.Log("lll");
            }

        }
        if (MGactive == true)
        {
            MachineGunBehavior();
        }
    }
    void OverHeat()
    {
        if (allowButtonHold == false)
        {

            overHeatTimer -= Time.deltaTime / coldownSpeed;
            if (overHeatTimer <= 0)
            {
                overHeatTimer = 0;
                allowButtonHold = true;

            }
            return; // stop runing function
        }
        if (shooting)
        {
            overHeatTimer += Time.deltaTime;
            if (overHeatTimer >= timeToOverHeat)
            {
                overHeatTimer = timeToOverHeat;
                allowButtonHold = false;
            }

        }
        else
        {

            if (overHeatTimer >= 0)
            {

                overHeatTimer -= Time.deltaTime / coldownSpeed;
            }
        }



    }
    public void MachineGunBehavior()
    {
        timer += Time.deltaTime;
        if (timer > timeBetweenShots)
        {
            //reset timer
            timer = 0;
            Instantiate(MGlaser, MGatackPoint1.position, transform.rotation);
            Instantiate(MGlaser2, MGatackPoint2.position, transform.rotation);
            Instantiate(MGlaser2, MGatackPoint3.position, transform.rotation);
            Instantiate(MGlaser2, MGatackPoint4.position, transform.rotation);
            Instantiate(MGlaser2, MGatackPoint5.position, transform.rotation);

        }
        
    }
    public void MachineGunActive()
    {
        MGactive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(18.0f);
        MGactive = false;
    }


}