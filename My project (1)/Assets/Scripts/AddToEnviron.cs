using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToEnviron : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Anything Being added to the environment should be a child of the Environ GameObject.
        GetComponentInParent<Environ>().pickups.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
