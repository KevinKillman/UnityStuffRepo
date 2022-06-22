using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environ : MonoBehaviour
{
    public int speedUpTotalCount;
    public List<GameObject> pickups;
    // Start is called before the first frame update
    void Start()
    {
        speedUpTotalCount = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        speedUpTotalCount = pickups.Count;
    }
}
