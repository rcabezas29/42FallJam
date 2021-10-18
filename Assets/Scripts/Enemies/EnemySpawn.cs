using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
	public BoxCollider2D	collider;

	public	GameObject		enemy;

	[SerializeField] float spawnCooldown = 2f;

	float	timeCounter = 0;

    void Start()
    {

    }

    void Update()
    {
        timeCounter += Time.deltaTime;

        if (timeCounter >= spawnCooldown)
        {
            CreateEnemy();
            timeCounter = 0;
        }
    }

    void CreateEnemy ()
    {
		float	randx = Random.Range(-collider.size.x / 2, collider.size.x / 2);
		Vector3 enemyOffset = new Vector3(randx, -0.5f, 0);

		Vector3	zero = new Vector3(0, 0, 0);

        float chance = Random.Range(0f, 100f);
        GameObject newEnemy = null;
	    newEnemy = Instantiate(enemy, this.transform);
		newEnemy.transform.position = zero;
		newEnemy.transform.position += this.transform.position;
		newEnemy.transform.position += enemyOffset;

        ColorManager cm;
        cm = newEnemy.gameObject.GetComponent<ColorManager>();
        cm.color = 0;
    }
}
