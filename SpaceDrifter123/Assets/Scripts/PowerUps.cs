using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public int powerupID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
          //  PlayerController player = other.transform.GetComponent<PlayerController>();
            ShootScript player = other.transform.GetComponent<ShootScript>();
            if (player != null)
            {
                switch (powerupID)
                {
                    case 0:
                        player.MachineGunActive();
                        break;
                   

                }


            }

        }
    }
}
