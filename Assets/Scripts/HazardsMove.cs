using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardsMove : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        Movement();
    }

    void Movement()
    {
        gameObject.GetComponentInChildren<Rigidbody>().velocity = new Vector3(0, 0, -speed);
    }
}
