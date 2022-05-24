using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySphereScript : MonoBehaviour
{
    //trails are fun
    [SerializeField] Vector3 _Rotation;
    [SerializeField] private float _Rspeed;
   
    void Update()
    {
        transform.Rotate(_Rotation * _Rspeed * Time.deltaTime);
    }
}
