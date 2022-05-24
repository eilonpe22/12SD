using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CrossHair : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    public Transform crossHair;

    public Rigidbody crossHairRB;
    public float mouseSensitivity=1f;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
    }

    public void Aim(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();
        crossHairRB.AddForce(new Vector3(inputVector.x, inputVector.y, 0) * mouseSensitivity * Time.deltaTime, ForceMode.Force);

     
    }
    void Update()
    {
       

       // playerInputActions.Player.Aim.ReadValue<Vector2>();

    }
}
