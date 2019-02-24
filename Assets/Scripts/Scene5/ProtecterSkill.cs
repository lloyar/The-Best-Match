using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtecterSkill : MonoBehaviour
{
    public float distance;
    public GameObject Protecter;
    private GameObject PlayerRed;
    private GameObject PlayerBlue;
    public Vector3 Vector;
    public Vector3 Vector2;
    // Start is called before the first frame update
    void Start()
    {
        Protecter.SetActive(false);
        PlayerRed = GameObject.FindGameObjectWithTag("PlayerRed");
        PlayerBlue = GameObject.FindGameObjectWithTag("PlayerBlue");
    }

    private void Update()
    {
        if (PlayerRed && PlayerBlue)
        {
            Vector = PlayerRed.transform.position - PlayerBlue.transform.position;
            Vector2 = PlayerRed.transform.position + PlayerBlue.transform.position;
            if (Vector3.Distance(PlayerRed.transform.position, PlayerBlue.transform.position) < distance)
            {
                Protecter.SetActive(true);
                Protecter.transform.position = PlayerBlue.transform.position + Vector / 2;
                //Instantiate(Protecter, new Vector3(Vector.x / 2, Vector.y / 2, Vector.z / 2), Quaternion.identity);
            }
            else
            {
                Protecter.SetActive(false);
            }
        }
    }

    IEnumerator NewMethod()
    {
        while (true)
        {
            PlayerRed.GetComponent<Rigidbody>().AddForce(Vector * 1.5f, ForceMode.Impulse);
            PlayerBlue.GetComponent<Rigidbody>().AddForce(-Vector * 1.5f, ForceMode.Impulse); //Movement(-Vector.x, PlayerBlue.transform.position.z, 10, 25);
            yield return null;
        }
    }

    public void Divide()
    {
        StartCoroutine("NewMethod");
        Invoke("NewMethod1", 0.5f);
    }

    private void NewMethod1()
    {
        StopCoroutine("NewMethod");
    }
}
