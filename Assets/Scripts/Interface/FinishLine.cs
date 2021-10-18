using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
	public GameObject Golem;

	void	OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject == Golem)
			Application.Quit();
	}
}
