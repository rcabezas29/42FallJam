using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExploder : MonoBehaviour
{
    private float   timeToExplode = 1.75f;
    private float   timeElapsed;
    private ParticleSystem  ps;
    private bool    exploding = false;
    private bool    dying = false;

    void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
        timeElapsed = 0;
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (!exploding && timeElapsed > timeToExplode)
            Explode();
        else if (exploding && timeElapsed > 2f)
            Destroy(gameObject);
    }

    private void Explode()
    {
        timeElapsed = 0;
        exploding = true;
        ps.Play();
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        CircleCollider2D  col = gameObject.GetComponent<CircleCollider2D>();
        sr.enabled = false;
        col.enabled = false;
  //      gameObject.renderer.enabled = false;
  //     Destroy(gameObject);
    }
}
