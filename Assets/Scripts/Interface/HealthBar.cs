using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
	public Image lifeBar;
	public Health health;

    // Update is called once per frame
    void Update()
    {
        lifeBar.fillAmount = health.HP / 100f;
    }
}
