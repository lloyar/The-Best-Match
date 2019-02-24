using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRed1 : ShipController
{
    public GameObject Bullets;
    public Transform BulletsSpawnPositon;
    public float ShootSpeed = 0.2f;
    public float MoveSpeed = 15;
    public float Titl = 3.5f;
    public GameObject PlayerExplosion;


    private void Start()
    {
        StartCoroutine("Shooter");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var zdir = Input.GetAxis("Horizontal");
        var xdir = Mathf.Clamp(Input.GetAxis("Vertical"), 0, 1);
        Movement(xdir, zdir, MoveSpeed, Titl);
        GetComponent<Transform>().position = new Vector3(
            gameObject.transform.position.x,
            0,
            Mathf.Clamp(gameObject.transform.position.z, 0, 21)
        );
    }

    IEnumerator Shooter()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.F))
            {
                Instantiate(Bullets, BulletsSpawnPositon.position, Quaternion.identity);
                //audioplayer.Play();
            }

            yield return new WaitForSeconds(ShootSpeed);
        }
    }

}
