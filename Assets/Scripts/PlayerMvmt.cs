using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EP 8, https://www.youtube.com/playlist?list=PLFt_AvWsXl0fnA91TcmkRyhhixX9CO3Lw

public class PlayerMvmt : MonoBehaviour
{
	public float speed = 5;

	// Start is called before the first frame update
	void Start() { }

	// Update is called once per frame
	void Update()
	{
		// Find direction, restrict movement to only horizontal
		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
		Vector2 direction = input.normalized;

		// Find velocity
		Vector2 velocity = direction * speed;

		// Move shape w/ specified parameters (move by new displacement val)
		//transform.position += velocity * Time.deltaTime;
		transform.Translate(velocity * Time.deltaTime);
	}
}
