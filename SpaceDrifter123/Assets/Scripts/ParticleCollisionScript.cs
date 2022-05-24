using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollisionScript : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("partttcoooooooo");
        other.GetComponent<PlayerController>().PlayerHP--;
    }
}
