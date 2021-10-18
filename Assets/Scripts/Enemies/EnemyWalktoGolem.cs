using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalktoGolem : MonoBehaviour
{
	public float speed;
	public Transform target;
	float distancetoGolem;
	int enemyState = 1;
	public float	attackCooldown;
	float	cooldownTime = 0;
    private	SpriteFlipper	sf;
	// Start is called before the first frame update
    void Start()
    {
		distancetoGolem = 10;
		sf = gameObject.GetComponent<SpriteFlipper>();
    }

    // Update is called once per frame
    void Update()
    {
		EnemyAttack enemyAttack;
		Vector3		diff;

		cooldownTime += Time.deltaTime;
		diff = transform.position - target.position;
		distancetoGolem = Vector3.Magnitude(diff);
		if (diff.x < 0)
			sf.FlipRight();
		else
			sf.FlipLeft();
        float step =  speed * Time.deltaTime; // calculate distance to move
		if (distancetoGolem < 1.8f)
		{
			ColorManager	cm;

			cm = gameObject.GetComponent<ColorManager>();
			if (cm != null && cm.color == 2)
			{
				HealTarget();
				Destroy(gameObject);
			}
			enemyState = 0;
			if (cooldownTime > attackCooldown)
			{
				enemyAttack = this.GetComponent<EnemyAttack>();
				enemyAttack.Attack(target.gameObject);
				cooldownTime = 0f;
			}
		}
		else
			enemyState = 1;
		if (enemyState == 1)
        	transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

	public GameObject	healEffect;

	private void HealTarget()
	{
		Health	health;

		health = target.gameObject.GetComponent<Health>();
		health.HP += 10;
		GameObject hh = Instantiate(healEffect, null);
		hh.transform.position = target.position;
		
		ParticleSystem	ps;

		ps = hh.GetComponent<ParticleSystem>();
		ps.Play();
	}
}
