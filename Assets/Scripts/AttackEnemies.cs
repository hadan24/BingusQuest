using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackEnemies : MonoBehaviour
{
	public float range = 4f;
	public float cooldown = 1f;
	private float cooldownCountdown = 0f;

	public GameObject projectilePF;
	public Transform cast_hand;

	private Transform currentTarget = null;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, .5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTarget == null)
			return;

		Debug.DrawLine(transform.position, currentTarget.position, Color.red);

		if (cooldownCountdown <= 0)
		{
			Cast();
			cooldownCountdown = cooldown;
		}
		cooldownCountdown -= Time.deltaTime;
    }

	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject nearestEnemy = null;
		float shortestDistance = float.PositiveInfinity;

		foreach (GameObject enemy in enemies)
		{
			float distance = Vector2.Distance(transform.position, enemy.transform.position);
			if (distance < shortestDistance)
			{
				shortestDistance = distance;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= range)
			currentTarget = nearestEnemy.transform;
		else currentTarget = null;
	}

	void Cast()
	{
		// getting the fireball to face the correct direction was done with the help of this:
		// https://gamedev.stackexchange.com/questions/186283/rotating-towards-a-target-in-top-down-2d-game
		Vector3 enemyDirection = currentTarget.position - transform.position;
		float angleToEnemy = Vector3.SignedAngle(transform.up, enemyDirection, transform.forward);
		Instantiate(projectilePF, cast_hand.position, Quaternion.Euler(0f, 0f, angleToEnemy));
	}

	private void OnDrawGizmosSelected() {
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}