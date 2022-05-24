using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHP : MonoBehaviour
{
   
    [SerializeField] private int HPpack;
    PlayerController playerController;
    public int MaxHP=100;
    public int CurrentHP;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            CurrentHP = other.GetComponent<PlayerController>().PlayerHP;
            if (CurrentHP < MaxHP)
            {
                other.GetComponent<PlayerController>().PlayerHP += HPpack;
                Destroy(gameObject);
            }
            
            
            

        }
    }

}
