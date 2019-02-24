using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBulletsRed : MonoBehaviour
{
    public float Destroytime = 0.5f;
    private GameObject gamectrlob;
    public GameObject Explosion;
    private GameController gameController;


    private void Start()
    {
        gamectrlob = GameObject.FindGameObjectWithTag("GameController");
        gameController = gamectrlob.GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "EnemyRed" || other.tag == "EnemyBlue")
        {
            return;
        }

        if (other.tag == "Protecter")
        {
            gameController.GetComponent<ProtecterSkill>().Divide();
            other.gameObject.SetActive(false);
        }

        if (other.tag != "BulletsBlue")
        {
            GetComponentInChildren<Animator>().SetBool("Explosion", true);
        }
        Instantiate(Explosion, transform.position, transform.rotation);

        if (other.tag == "PlayerRed")
        {
            gamectrlob.GetComponent<Health>().ReduceHealth();
            if (gamectrlob.GetComponent<Health>().health == 0)
            {
                Instantiate(other.GetComponent<PlayerControllerRed>().PlayerExplosion, other.transform.position, other.transform.rotation);
                Destroy(other.gameObject);

                Invoke("DestroygameObject", Destroytime);
                //Destroy(gameObject);
                gameController.GameOver();
            }
        }
        else if (other.tag == "PlayerBlue")
        {
            gamectrlob.GetComponent<Health>().ReduceHealth();
            if (gamectrlob.GetComponent<Health>().health == 0)
            {
                Instantiate(other.GetComponent<PlayerControllerBlue>().PlayerExplosion, other.transform.position, other.transform.rotation);
                Destroy(other.gameObject);

                Invoke("DestroygameObject", Destroytime);
                //Destroy(gameObject);
                gameController.GameOver();
            }
        }

        // gameController.AddScore(score);
        if (other.tag != "PlayerRed" && other.tag != "PlayerBlue" && other.tag != "Protecter")
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "BulletsRed" || other.tag == "PlayerRed" || other.tag == "PlayerBlue" || other.tag == "Protecter")
        {
            
            Invoke("DestroygameObject", Destroytime);
            //Destroy(gameObject);
        }
    }

    void DestroygameObject()
    {
        Destroy(gameObject);
    }
}
