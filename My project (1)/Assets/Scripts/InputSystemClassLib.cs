using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputSystemClassLib : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if ( context.performed && GetComponent<PlayerController>().jumped == false)
        {
            rb.AddForce(Vector3.up*5f, ForceMode.Impulse);
            GetComponent<PlayerController>().jumped = true;
        }
    }
}
