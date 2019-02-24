using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : ShipController
{
    public GameObject Bullets;
    public Transform BulletsSpawnPosition;
    public float MoveSpeed;
    public float Titl;
    
    public float zdir = -1;
    private float xdir;


    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("RandomMove");
        StartCoroutine("RandomShoot");
        InvokeRepeating("RandomMovedirset",0.5f,Random.Range(0f,1f));
    }
    private void FixedUpdate()
    {
        Movement(xdir, zdir, MoveSpeed, Titl);
    }
    
    IEnumerator RandomMove()
    {
        while (true)
        {
            xdir = Random.Range(-2.0f, 2.0f);
            yield return new WaitForSeconds(Random.Range(0f,1f));
        }
    }

    void RandomMovedirset()
{
    xdir = Random.Range(-2.0f, 2.0f);
}

    IEnumerator RandomShoot()
    {
        while (gameObject.transform.position.z > 35)
        {
            Instantiate(Bullets,BulletsSpawnPosition.position,Quaternion.identity);
            //GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(Random.Range(0.5f,1f));
        }
    }
}
