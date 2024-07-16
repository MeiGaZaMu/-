using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    void Update()
    {
        this.transform.Translate(Vector3.down * Time.deltaTime * 5);
    }
    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                Debug.Log("击中玩家");
                GameObject.Find("bloodBar").GetComponent<bloodController>().hurt();
                break;
            case "Enemy":
                Debug.Log("击中敌人");
                break;
            case "wall":
                Destroy(gameObject);
                break;
            default:
                Destroy(gameObject);
                break;

        }
    }
}
