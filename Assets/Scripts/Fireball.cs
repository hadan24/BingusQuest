using UnityEngine;

public class Fireball : MonoBehaviour
{
	private Transform target = null;
	private Rigidbody2D myRB;

	public float speed = 10f;
	public int power = 5;

	public void targetLock(Transform _target)
	{
		target = _target;
	}

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
		{
			Destroy(gameObject);
			return;
		}
		Vector3 enemyDirection = (target.position - transform.position).normalized;
		Vector2 velocity = enemyDirection * speed;
		myRB.position += velocity * Time.deltaTime;
    }

	private void OnTriggerEnter2D(Collider2D triggered) {
		if (triggered.tag != "Enemy")
			return;
		
		Destroy(gameObject);

		Enemy enemyScript = triggered.transform.GetComponent<Enemy>();
		if (enemyScript != null)
			enemyScript.TakeDamage(power);
		else Destroy(triggered.gameObject);
	}
}
