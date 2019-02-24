using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChilderMoveAI : ShipController
{
    public GameObject Bullets;
    public Transform BulletsSpawnPosition;
    public float MoveSpeed;
    public float Titl = 3.5f;
    public float zdir = 1;
    private float xdir;
    private Vector3 Vector;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("RandomMove");
        StartCoroutine("RandomShoot");
        InvokeRepeating("RandomMovedirset", 0.5f, Random.Range(0f, 1f));
        Vector = GameObject.FindGameObjectWithTag("GameController").GetComponent<ProtecterSkill>().Vector2;

    }

    private void FixedUpdate()
    {
        Movement(xdir, zdir, MoveSpeed, Titl);
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            Divide();
        }
    }

    IEnumerator RandomMove()
    {
        while (true)
        {
            xdir = Random.Range(-2.0f, 2.0f);
            zdir = Random.Range(-0.5f, 2.0f);
            yield return new WaitForSeconds(Random.Range(0f, 1f));
        }
    }

    void RandomMovedirset()
    {
        xdir = Random.Range(-2.0f, 2.0f);
        zdir = Random.Range(-2.0f, 2.0f);
    }

    IEnumerator RandomShoot()
    {
        while (gameObject.transform.position.z > 35)
        {
            Instantiate(Bullets, BulletsSpawnPosition.position, Quaternion.identity);
            //GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(Random.Range(0.5f, 1f));
        }
    }

    IEnumerator BackHome()
    {
        while (true)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector / 2 - gameObject.transform.position, ForceMode.Impulse);
            //StopCoroutine("StayMove");
            yield return null;
        }
    }

    IEnumerator BackCentral()
    {
        while (true)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.5f, 0, 15) - gameObject.transform.position, ForceMode.Impulse);
            yield return null;
        }
    }

    public void Divide()
    {
        StartCoroutine("BackHome");
        Invoke("BackHomeStop", 1f);
        Invoke("NewMethod", 2);
    }

    private void NewMethod()
    {
        StartCoroutine("BackCentral");
        Invoke("BackCentralStop", 0.5f);
    }

    private void BackHomeStop()
    {
        StopCoroutine("BackHome");
    }

    private void BackCentralStop()
    {
        StopCoroutine("BackCentral");
    }
}
