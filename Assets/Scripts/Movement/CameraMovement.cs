using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	float			timeWaiting = 0;
	int				golemState = 0;

    void Update()
    {
		CameraStep();
    }

    void    CameraStep()
	{
		Vector3 vector;

		vector.x = 0;
		vector.y = 0.5f * Time.deltaTime;
		vector.z = 0;
		transform.Translate(vector);
	}
}
