using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    public float ScrollSpeed;
    public float ScrollDistance;
    private Vector3 startpostion;
    // Start is called before the first frame update
    void Start()
    {
        startpostion = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        BG_Scroll();
    }

    void BG_Scroll()
    {
        var ScrollVector = new Vector3(0 ,0 ,-Mathf.Repeat(Time.time * ScrollSpeed, ScrollDistance));
        transform.position = startpostion + ScrollVector;
    }
}
