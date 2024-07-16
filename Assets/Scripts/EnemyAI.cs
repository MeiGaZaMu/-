using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    mySceneManager sceneManager;
    public GameObject explosion;
    float lowestPos;
    public Transform bulletShooter;
    public GameObject bullet;
    public int EnemyNum;
    float speed;
    void Start()
    {
        sceneManager = GameObject.Find("SceneManager").GetComponent<mySceneManager>();
        switch (EnemyNum)
        {
            //普通飞机，固定位置发子弹
            case 1:
                speed = Random.Range(2f, 3f);
                lowestPos = 0;
                InvokeRepeating("Shoot", 0, 4f);
                break;
            //冲锋飞机，和玩家爆了
            case 2:
                speed = Random.Range(4, 5);
                lowestPos = -10;
                break;
            //大飞机，固定位置三发子弹
            case 3:
                speed = 1;
                lowestPos = 2;
                InvokeRepeating("MultiShoot", 0, 8f);
                break;
        }
    }
    void Update()
    {
        if (this.transform.position.y > lowestPos)
        {
            this.transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
    }
    void Shoot()
    {
        GameObject bulletEntity = Instantiate(bullet, bulletShooter.position, Quaternion.identity);
    }
    void MultiShoot()
    {
        for (int i = -2; i < 3; i++)
        {
            GameObject bulletEntity = Instantiate(bullet, bulletShooter.position, Quaternion.identity);
            bulletEntity.transform.Rotate(0, 0, 10 * i);

        }
    }

    public void hurt()
    {
        Instantiate(explosion, this.gameObject.transform.position, Quaternion.identity);
        //explosion.GetComponent<Animation>().Play();
        sceneManager.countScore();
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            sceneManager.GameOver();
        }
        if (other.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);
        }
    }
}
