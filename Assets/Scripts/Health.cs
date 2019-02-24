using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text HealthText;
    public int health = 2;

    // Start is called before the first frame update
    void Start()
    {
        HealthText.text = "Health:" + health;
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void ReduceHealth()
    {
        health -= 1;
        HealthText.text = "Health:" + health;
    }
}
