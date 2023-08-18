using UnityEngine;

/*
	This script is based on these tutorials:
		- https://youtu.be/Eq6rCCO2EU0
		- https://youtu.be/aFxucZQ_5E4
*/

public class Enemy : MonoBehaviour
{
	public float speed = 2.5f;
	public int HP = 50;

	private readonly Transform[] points = PathPoints.points;
	private Vector3 currentDestination;
	private int destinationIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
		currentDestination = points[0].position;
    }

	public void TakeDamage(int taken)
	{
		HP -= taken;
		if (HP <= 0)
			Destroy(gameObject);
	}

    // Update is called once per frame
    void Update()
    {
		transform.position = Vector2.MoveTowards
			(transform.position, currentDestination, speed * Time.deltaTime);

		if (Vector2.Distance(transform.position, currentDestination) <= .02f)
		{
			destinationIndex++;
			currentDestination = points[destinationIndex].position;
		}

		if (destinationIndex >= points.Length-1)
			Destroy(gameObject);
    }
}
