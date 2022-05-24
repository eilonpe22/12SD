using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCannonScript : MonoBehaviour
{

    public ParticleSystem ElectricBeam;
    public Transform cannonTarget;
    public float cannonTrackSpeed;
    

    private void Start()
    {
        cannonTarget = FindObjectOfType<PlayerController>().transform;
        ElectricBeam = GetComponent<ParticleSystem>();
    }
    void Update()
    {
         Vector3 direction = cannonTarget.position - transform.position;
         Quaternion rotation = Quaternion.LookRotation(direction);
          transform.rotation = Quaternion.Lerp(transform.rotation,rotation,cannonTrackSpeed) ;

        
    }

    void OnParticleCollision(GameObject other)
    {
        print("Particle collision");
    }


   


}
