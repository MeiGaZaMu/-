using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public bool isOver = false;
    void Update()
    {
        if (isOver)
        {
            Destroy(this);
        }
    }
}
