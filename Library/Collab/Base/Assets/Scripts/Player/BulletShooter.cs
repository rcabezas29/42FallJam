using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    public GameObject   normalBullet;
    public GameObject   yellowBullet;
    public GameObject   blueBullet;
    public float        shootCooldownNormal = 0.5f;
    public float        shootCooldownYellow = 0.5f;
    public float        shootCooldownBlue = 0.5f;
    private float       timeElapsedNormal = 0;
    private float       timeElapsedYellow = 0;
    private float       timeElapsedBlue = 0;

    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsedNormal += Time.deltaTime;
        timeElapsedYellow += Time.deltaTime;
        timeElapsedBlue += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && timeElapsedNormal > shootCooldownNormal)
        {
            timeElapsedNormal = 0;
            ShootNormal();
        }
        if (Input.GetButtonDown("Fire2") && timeElapsedYellow > shootCooldownYellow)
        {
            timeElapsedYellow = 0;
            ShootYellow();
        }
        if (Input.GetButtonDown("Fire3") && timeElapsedBlue > shootCooldownBlue)
        {
            timeElapsedBlue = 0;
            ShootBlue();
        }
    }

    private void ShootNormal()
    {
        GameObject bullet = Instantiate(normalBullet, transform.position, transform.rotation);    
    }

    private void ShootYellow()
    {
        GameObject bullet = Instantiate(yellowBullet, transform.position, transform.rotation);    
    }

    private void ShootBlue()
    {
        GameObject bullet = Instantiate(blueBullet, transform.position, transform.rotation);    
    }
}
