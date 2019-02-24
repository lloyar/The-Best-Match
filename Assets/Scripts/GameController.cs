using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] Allhazards;
    private GameObject[] hazards;

    public Text RestartText;
    public Text GameOverText;
    public bool GameOverFlag;
    public bool RestartFlag;
    public float spawnWaitSeconds;
    public Vector3 spawnRange;
    public int spawnCountter;
    public float GameTime = 60f;
    public GameObject NextLevelButton;


    // Start is called before the first frame update
    void Start()
    {
        hazards = new GameObject[2];
        hazards[0] = Allhazards[0];
        hazards[1] = Allhazards[1];
        NextLevelButton.SetActive(false);
        RestartText.text = "";
        GameOverText.text = "";
        GameOverFlag = false;
        RestartFlag = false;
        StartCoroutine("SpawnFlow");
        NextLevelButton.SetActive(false);
        StartCoroutine("SwitchHazards");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Time.time > GameTime)
        {
            StartCoroutine("NextLevel");
        }
    }

    IEnumerator SwitchHazards()
    {
        while (true)
        {
            if (Time.time > GameTime / 3)
            {
                hazards[0] = Allhazards[2];
                hazards[1] = Allhazards[3];
                StopCoroutine("SwitchHazards");
            }
            yield return null;
        }
    }

    IEnumerator SpawnFlow()
    {
        while (true)
        {
            for (int i = 0; i < spawnCountter; i++)
            {
                var ob = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnRange.x, spawnRange.x), spawnRange.y, spawnRange.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(ob, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWaitSeconds);
            }
            yield return new WaitForSeconds(2f);
            if (GameOverFlag)
            {
                RestartText.text = "按下'R'重新开始";
                RestartFlag = true;
            }
        }
    }

    IEnumerator NextLevel()
    {
        StopCoroutine("SpawnFlow");
        yield return new WaitForSeconds(5f);
        NextLevelButton.SetActive(true);
    }

    public void GameOver()
    {
        GameOverFlag = true;
        GameOverText.text = "Game Over!";
    }

    public void AddScore(int score)
    {
        //Score += score;
        //ScoreText.text = "Score:" + Score;
    }
}
