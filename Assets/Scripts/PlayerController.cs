using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject ex;
    public GameObject bullet;
    public Transform bulletShooter;
    public float MoveSpeed;
    private float realSpeed;
    void Start()
    {
        InvokeRepeating("Shoot", 0, 0.5f);
    }
    void FixedUpdate()
    {
        Move();
    }
    void Shoot()
    {
        GameObject bulletEntity = Instantiate(bullet, bulletShooter.position, Quaternion.identity);

    }
    void Move()
    {

        float V = Input.GetAxis("Vertical");
        float H = Input.GetAxis("Horizontal");
        realSpeed = MoveSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            realSpeed = MoveSpeed * 2;
        }

        if (this.transform.position.x > 2.77f)
        {
            transform.position = new Vector3(2.77f, this.transform.position.y, 0.668f);
        }
        else if (this.transform.position.x < -2.77f)
        {
            transform.position = new Vector3(-2.77f, this.transform.position.y, 0.668f);
        }
        if (this.transform.position.y < -5.1f)
        {
            transform.position = new Vector3(this.transform.position.x, -5.1f, 0.668f);
        }
        transform.position += realSpeed * Time.deltaTime * new Vector3(H, V >= 0 ? V * 2 : V / 2, 0);
        //this.GetComponent<Rigidbody>().velocity = new Vector3(H, V >= 0 ? V * 2 : V / 2, 0) * MoveSpeed;
    }
}
