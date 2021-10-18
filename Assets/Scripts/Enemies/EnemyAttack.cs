using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	public int	strength;
	public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void	Attack(GameObject objective)
	{
		Health health;
		health = objective.GetComponent<Health>();
		source.Play();

		health.HP -= strength;
	}
}
