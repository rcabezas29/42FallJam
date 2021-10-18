using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExploder : MonoBehaviour
{
    private float   timeToExplode = 0.75f;
    private float   timeElapsed;
    private ParticleSystem  ps;
    private bool    exploding = false;
	private AudioSource source;

    void Start()
    {
		source = GetComponent<AudioSource>();
        ps = gameObject.GetComponent<ParticleSystem>();
        timeElapsed = 0;
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (!exploding && timeElapsed > timeToExplode)
            Explode();
        else if (exploding && timeElapsed > 0.75f)
            Destroy(gameObject);
    }

    private void Explode()
    {
        timeElapsed = 0;
        exploding = true;
        ps.Play();
		source.Play();
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        CircleCollider2D  col = gameObject.GetComponent<CircleCollider2D>();
        EnemyWalktoGolem    gw = gameObject.GetComponent<EnemyWalktoGolem>();
        sr.enabled = false;
        col.enabled = false;
        gw.enabled = false;

        ExplodeCloseEnemies();
    }

    private void ExplodeCloseEnemies()
    {
        var  closeEnemies = FindObjectsOfType<GameObject>();
        for (int i = 0; i < closeEnemies.Length; i++)
        {
            if (closeEnemies[i].GetComponent<IsExplodable>() != null)
            {
                if (closeEnemies[i].GetComponent<EnemyExploder>() == null)
                {
                    Vector3 diff = closeEnemies[i].transform.position - transform.position;
                    if (diff.magnitude < 2f)
                    {
                        ColorManager    cm;
                        cm = closeEnemies[i].GetComponent<ColorManager>();
                        closeEnemies[i].AddComponent(typeof(EnemyExploder));
                        if (cm != null)
                            cm.color = 1;
                    }                
                }
            }
        }
    }
}
