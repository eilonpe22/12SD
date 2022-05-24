using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{




    [SerializeField] float boostSpeed;

    public int PlayerHP;
    public PlayerInputActions playerInputActions;

    public float sideTilt = 1f;
    public float AimSensitivity;
    public float verticalSens = 1f;
    public float horizontalSens = 1f;


    public Vector3 playerRotation;


    public Slider AimSens;


    public bool boosted;
    private Rigidbody RB;
    public Transform playerBody;

   // [SerializeField]
  //  private float yawTorque = 200f;
  //  [SerializeField]
   // private float pitchTorque = 200f;
    [SerializeField]
    private float rollTorque = 500f;
    [SerializeField]
    private float thrust = 100f;
    [SerializeField]
    private float strafeThrust = 50f;
    [SerializeField]
    private float updownSpeed = 50f;


    [SerializeField, Range(0.001f, 0.999f)]
    private float thrustGlideReduction = 0.999f;
    [SerializeField, Range(0.001f, 0.999f)]
    private float upDownGlideReduction = 0.999f;
    [SerializeField, Range(0.001f, 0.999f)]
    private float leftRightGlideReduction = 0.999f;
    float glide = 0f;
    float horizontalGlide = 0f;
    float torqueReset = 0.5f;

    public bool ADS;
    public GameObject AdsCamera;
    public GameObject CrossHair;

    //input boost Values
    public ParticleSystem thrusterR;
    public ParticleSystem thrusterL;
    public GameObject boostFire;
    public GameObject boostEffect;

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();


        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    private void FixedUpdate()
    {
        HandleMovement();

        Boosted();

        PlayerADS();

    }

    void HandleMovement()
    {

        // Roll

        // RB.AddRelativeTorque(Vector3.back * roll1D * rollTorque * Time.deltaTime, ForceMode.Impulse);
        if (roll1D > 0.1f || roll1D < -0.1f)
        {
            playerBody.Rotate(new Vector3(0, 0, roll1D * rollTorque * sideTilt) * Time.deltaTime);
        }

        //playerBody.Rotate(new Vector3(0,0,roll1D*rollTorque*sideTilt)*Time.deltaTime);

        // Pitch
        //if (pitchYaw> 0.1f || pitchYaw < -0.1f)


        // playerBody.Rotate(new Vector3(0, pitchYaw.x, pitchYaw.y*AimSensitivity) * Time.deltaTime);
        //playerBody.Rotate(new Vector3(0, pitchTorque * AimSensitivity,0)*Time.deltaTime);
        // Yaw
        if (pitchYaw.y > 0.1f || pitchYaw.y < -0.1f)
        {
            playerBody.Rotate(new Vector3(pitchYaw.y * -sideTilt * AimSensitivity * verticalSens, 0, 0) * Time.deltaTime);
            //RB.AddRelativeTorque(Vector3.left * Mathf.Clamp(pitchYaw.y, -1f, 1f) * pitchTorque * Time.deltaTime, ForceMode.Force);
        }
        else
        {
            //RB.AddRelativeTorque(Vector3.right * Mathf.Clamp(pitchYaw.y, -1f, 1f) * pitchTorque * Time.deltaTime, ForceMode.Force);
        }

        //RB.AddRelativeTorque(Vector3.up * Mathf.Clamp(pitchYaw.x, -1f, 1f) * yawTorque * Time.deltaTime, ForceMode.Force);
        // playerBody.Rotate(new Vector3(0, pitchYaw.x, pitchYaw.y * AimSensitivity) * Time.deltaTime);
        //playerBody.Rotate(new Vector3(yawTorque * AimSensitivity, 0,0)*Time.deltaTime);
        //RB.AddRelativeTorque(Vector3.up * Mathf.Clamp(pitchYaw.x, -1f, 1f) * yawTorque * Time.deltaTime, ForceMode.Acceleration);

        if (pitchYaw.x > 0.1f || pitchYaw.x < -0.1f)
        {
            //pitchYaw.x=(-1,1)
            playerBody.Rotate(new Vector3(0, pitchYaw.x * sideTilt * AimSensitivity * horizontalSens, 0) * Time.deltaTime);
            //RB.AddRelativeTorque(Vector3.up * Mathf.Clamp(pitchYaw.x, -1f, 1f) * yawTorque * Time.deltaTime, ForceMode.Force);
        }
        else
        {
            //RB.AddRelativeTorque(Vector3.down * Mathf.Clamp(pitchYaw.x, -1f, 1f) * yawTorque * Time.deltaTime, ForceMode.Force);
        }
        // Thrust
        if (thrust1D > 0.1f || thrust1D < -0.1f)
        {
            float currentThrust = thrust;
            RB.AddRelativeForce(Vector3.forward * thrust1D * currentThrust * Time.deltaTime, ForceMode.Impulse);
            glide = thrust;
        }
        else
        {
            RB.AddRelativeForce(Vector3.forward * glide * Time.deltaTime);
            glide *= thrustGlideReduction;
        }

        if (strafe1D > 0.1f || strafe1D < -0.1f)
        {
            float currentStrafe = strafeThrust;
            RB.AddRelativeForce(Vector3.right * strafe1D * currentStrafe * Time.deltaTime, ForceMode.Impulse);
            horizontalGlide = strafeThrust;
        }
        else
        {
            RB.AddRelativeForce(Vector3.right * horizontalGlide * Time.deltaTime);
            horizontalGlide *= leftRightGlideReduction;
        }
        if (Boost > 0.1f || Boost < -0.1f)
        {
            RB.AddRelativeForce(Vector3.forward * boostSpeed * Time.deltaTime, ForceMode.Impulse);
            boosted = true;
        }
        else
        {
            boosted = false;
        }


        if (upDown1D > 0.1f || upDown1D < -0.1f)
        {
            RB.AddRelativeForce(Vector3.up * upDown1D * updownSpeed * Time.deltaTime, ForceMode.Impulse);
        }
    }

    //Player Inputs
    public float Boost;
    private float thrust1D;
    private float strafe1D;
    private float upDown1D;
    private float roll1D;
    private Vector2 pitchYaw;

    public void OnThrust(InputAction.CallbackContext context)
    {
        thrust1D = context.ReadValue<float>();
    }
    public void OnStrafe(InputAction.CallbackContext context)
    {
        strafe1D = context.ReadValue<float>();
    }
    public void OnUpDown(InputAction.CallbackContext context)
    {
        upDown1D = context.ReadValue<float>();
    }
    public void OnRoll(InputAction.CallbackContext context)
    {
        roll1D = context.ReadValue<float>();
    }
    public void OnPitchYaw(InputAction.CallbackContext context)
    {
        pitchYaw = context.ReadValue<Vector2>();
    }
    public void OnBoost(InputAction.CallbackContext context)
    {
        Boost = context.ReadValue<float>();
    }
    public void OnADS(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ADS = true;
        }
        if (context.canceled)
        {
            ADS = false;
        }
    }

   
    //if we want to use this method disable "play on awake" in the prefabs particle system
    //public ParticleSystem BoostEffectR;
    //public ParticleSystem BoostEffectL;
    public void Boosted()
    {
        if (boosted)
        {
            thrusterR.startSpeed = 25f;
            thrusterL.startSpeed = 25f;

            //BoostEffectR.Play();
            //BoostEffectL.Play();
            boostFire.SetActive(true);
            boostEffect.SetActive(true);
        }
        else
        {
            thrusterR.startSpeed = 5f;
            thrusterL.startSpeed = 5f;
            boostFire.SetActive(false);
            boostEffect.SetActive(false);
        }
    }
    
    public void PlayerADS() 
    {
        if (ADS)
        {
            AdsCamera.SetActive(true);
            CrossHair.SetActive(true);
        }
        else
        {
            AdsCamera.SetActive(false);
            CrossHair.SetActive(false);
        }
    }
    


    //look AT script
    // Vector3 direction = transform.position - crossHair.position;
    // Quaternion rotation = Quaternion.LookRotation(direction);
    //  transform.rotation = rotation;


}

   

    





    
         
    

	
    
   
    








