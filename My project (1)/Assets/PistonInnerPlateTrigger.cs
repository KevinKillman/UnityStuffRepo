using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonInnerPlateTrigger : MonoBehaviour, IPistonTriggerAction
{
    private Rigidbody rb;
    public GameObject outerPlate;
    public GameObject plateConnector;
    Vector3 originalPosition;
    Vector3 outerPlateOriginalPosition;
    Vector3 connectorOriginalPosition;
    private bool alreadyPushedOnce=false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalPosition = new Vector3(rb.transform.position.x, rb.transform.position.y, rb.transform.position.z);
        outerPlateOriginalPosition = new Vector3(outerPlate.transform.position.x, outerPlate.transform.position.y, outerPlate.transform.position.z);
        connectorOriginalPosition = new Vector3(plateConnector.transform.position.x, plateConnector.transform.position.y, plateConnector.transform.position.z);

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (rb.transform.position.x <= outerPlateOriginalPosition.x )
        {
            ResetPistonComponents();
        }
    }

    private void ResetPistonComponents()
    {
        var rbs = GetComponentsInChildren<Rigidbody>();
        rb.velocity = new Vector3(0, 0, 0);

        foreach ( var body in rbs )
        {
            body.velocity = new Vector3(0, 0, 0);
        }
        rb.transform.position = originalPosition;
        plateConnector.transform.position = connectorOriginalPosition;
        outerPlate.transform.position = outerPlateOriginalPosition;
        alreadyPushedOnce = false;
    }

    public void PistonTriggerMethod()
    {
        rb.freezeRotation = true;
        if ( !alreadyPushedOnce )
        {
            Vector3 directionVector = ( outerPlateOriginalPosition - originalPosition );
            rb.AddRelativeForce(new Vector3(-200, 0, 0), ForceMode.Impulse);
        }
        alreadyPushedOnce = true;

        
    }
}
