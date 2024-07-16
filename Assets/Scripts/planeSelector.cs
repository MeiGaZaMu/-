using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class planeSelector : MonoBehaviour
{
    int targetPlane = -1;
    public Button planeA;
    public Button planeB;
    public Button planeC;
    public Text planeText;
    public Button choice;
    public void planeAChoose()
    {
        targetPlane = 0;
        planeText.text = "速度战机——速度较快但是子弹发射速度慢";
    }
    public void planeBChoose()
    {
        targetPlane = 1;
        planeText.text = "均衡战机——速度与子弹时间较为平衡";
    }
    public void planeCChoose()
    {
        targetPlane = 2;
        planeText.text = "火力战机——速度较慢但是子弹发射速度快";
    }

    public void loadingShoot()
    {
        Debug.Log("按下按钮");
        if (targetPlane == -1)
        {
            return;
        }
        mySceneManager.PlayMode = targetPlane;
        SceneManager.LoadScene("Shooter");

    }
}
