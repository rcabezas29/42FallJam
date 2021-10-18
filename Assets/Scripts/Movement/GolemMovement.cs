using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemMovement : MonoBehaviour
{
	public float	timeForStep;
	float			timeWaiting = 0;
	int				golemState = 0;
	public	AudioSource source;
    // Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		timeWaiting += Time.deltaTime;
		if (timeWaiting > timeForStep)
		{
			if (golemState == 0)
				golemState = 1;
			else if (golemState == 1)
				golemState = 0;
			timeWaiting = 0;
		}
		if (golemState == 1)
			GolemStep();
    }

    void    GolemStep()
	{
		Vector3 vector;

		source.Play();
		vector.x = 0;
		vector.y = 1f * Time.deltaTime;
		vector.z = 0;
		transform.Translate(vector);
	}
}
