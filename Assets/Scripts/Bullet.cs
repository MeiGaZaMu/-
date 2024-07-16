using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Update()
    {
        this.transform.Translate(Vector3.up * Time.deltaTime * 10);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("子弹击中" + other.gameObject.tag);
        switch (other.gameObject.tag)
        {
            case "Enemy":
                Debug.Log("击中敌人");
                other.gameObject.GetComponent<EnemyAI>().hurt();

                break;
            case "wall":
                Destroy(this.gameObject);
                break;
            default:
                Destroy(gameObject);
                break;
        }
    }
}
