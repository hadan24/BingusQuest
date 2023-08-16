using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EP 10, https://www.youtube.com/playlist?list=PLFt_AvWsXl0fnA91TcmkRyhhixX9CO3Lw

// for collision detection, need rigidbody AND collider
// "isTrigger" ignores collision but collects collision data to trigger events

public class PlayerCollision : MonoBehaviour
{
	Rigidbody2D myRB;   // isKinematic property ignores physics but still allows collision detection
	public float speed = 5;
	Vector2 velocity;

	// Start is called before the first frame update
	void Start()
	{
		myRB = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), 0).normalized;
		velocity = direction * speed;
	}

	// FixedUpdate is called on regular time intervals
	// thus Time.(fixed)deltaTime WON'T change unless we tell it to
	void FixedUpdate()
	{
		// fixedDeltaTime is rate at which physics calcs are done
		// can change for slow-mo/speed-up effs
		myRB.position += velocity * Time.fixedDeltaTime;
	}

	// can be attached to trigger OR active collider
	void OnTriggerEnter2D(Collider2D trigger)
	{
		if (trigger.tag == "stone-wall")
        {
			velocity = Vector2.zero;
		}
	}
}