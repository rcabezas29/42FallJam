using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public Rigidbody2D  rb;
    public float        speed = 1;


    void Start()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 targetDirection = mousePos - transform.position;
        Vector2 vel;
        Vector3 newPos;

        vel.x = targetDirection.x / targetDirection.magnitude * speed;
        vel.y = targetDirection.y / targetDirection.magnitude * speed;
        transform.position += targetDirection / targetDirection.magnitude * 2;
        rb.velocity = vel;
    }
}
