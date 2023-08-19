using UnityEngine;
using UnityEngine.SceneManagement;

// EP 8, https://www.youtube.com/playlist?list=PLFt_AvWsXl0fnA91TcmkRyhhixX9CO3Lw

public class PlayerMvmt : MonoBehaviour
{
	public float speed = 5;

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

	//upon colliding with the wall, scene will advance to tower defence portion
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("stone-wall"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}
