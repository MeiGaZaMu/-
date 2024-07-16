using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bloodController : MonoBehaviour
{
    public GameObject ex;
    public void hurt()
    {
        this.transform.localScale = new Vector3(this.transform.localScale.x - 0.5f, 1, 1);
        if (this.transform.localScale.x < 0)
        {
            this.transform.localScale = new Vector3(0, 1, 1);
            GameObject.Find("SceneManager").GetComponent<mySceneManager>().GameOver();

        }
    }
}
