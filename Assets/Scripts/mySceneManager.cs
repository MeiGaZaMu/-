
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mySceneManager : MonoBehaviour
{
    public static int PlayMode = -1;
    public int score;
    float shootTime = 1;
    public GameObject overText;
    public Text scoreText;
    public GameObject replayButton;
    public GameObject ex;
    public GameObject[] enemys;
    public Renderer BG;
    PlayerController player;
    void Start()
    {
        Debug.Log("加载场景,当前PlayMode等于" + PlayMode);
        score = 0;
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        switch (PlayMode)
        {
            case 0:
                shootTime = 8f;
                player.MoveSpeed = 5f;
                break;
            case 1:
                shootTime = 5f;
                player.MoveSpeed = 3f;
                break;
            case 2:
                shootTime = 3f;
                player.MoveSpeed = 1f;
                break;
        }
        InvokeRepeating("InstantiateEnemy", 0, shootTime);
    }
    void Update()
    {
        BG.material.SetTextureOffset("_MainTex", new Vector2(0, Time.time / 5));
    }

    void InstantiateEnemy()
    {
        Debug.Log("生成了一次敌人");
        int num = Random.Range(0, enemys.Length);
        GameObject enemy = Instantiate(enemys[num], new Vector3(Random.Range(-2.17f, 2.17f), 5.05f, 0.688f), Quaternion.identity);
        //enemy.GetComponent<EnemyAI>().EnemyNum = num;
    }
    public void GameOver()
    {

        Instantiate(ex, player.transform.position, Quaternion.identity);
        overText.SetActive(true);
        replayButton.SetActive(true);
        Destroy(GameObject.FindWithTag("Player"));

    }
    public void countScore()
    {
        score++;
        scoreText.text = "分数：" + score.ToString();
    }

    public void RePlay()
    {
        SceneManager.LoadScene("choose");
    }
}
