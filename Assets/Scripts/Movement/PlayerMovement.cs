using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float		moveSpeed;
	public Rigidbody2D rb;
	Vector2				movement;
    SpriteFlipper       sf;
	public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        sf = gameObject.GetComponent<SpriteFlipper>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
        if (movement.x > 0)
		{
            sf.FlipRight();
			source.Play();
		}
        else if (movement.x < 0)
		{
            sf.FlipLeft();
			source.Play();
		}
		
    }

	void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
	}
}
