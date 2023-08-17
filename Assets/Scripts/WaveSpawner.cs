using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
	public GameObject enemyPF;
	public float waveDelay = 5f;
	public float enemyDelay = .5f;
	public int numberOfWaves = 10;

	private int currentWave = 0;
	private float waveCountdown = 1f;

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (currentWave <= numberOfWaves && waveCountdown <= 0f)
		{
			waveCountdown = waveDelay;
			StartCoroutine(SpawnWave());
		}
		else
			waveCountdown -= Time.deltaTime;
	}

	IEnumerator SpawnWave()
	{
		currentWave++;
		for (int i = 0; i < currentWave; i++)
		{
			Instantiate(enemyPF, transform.position, transform.rotation, transform);
			yield return new WaitForSeconds(enemyDelay);
		}
	}
}
