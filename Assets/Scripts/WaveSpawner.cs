using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
	public GameObject enemyPF;
	public float waveDelay = 5f;
	public float enemyDelay = .4f;
	public int numberOfWaves = 10;

	private int currentWave = 0;
	private float waveCountdown = 1f;

	// Update is called once per frame
	void Update()
	{
		if (currentWave <= numberOfWaves && waveCountdown <= 0f)
		{
			waveCountdown = waveDelay;
			if (waveCountdown < enemyDelay*numberOfWaves)
				waveCountdown += enemyDelay * (numberOfWaves + 1);
			StartCoroutine(SpawnWave());
		}
		waveCountdown -= Time.deltaTime;

		if (Input.GetKeyDown(KeyCode.Q))
		{
			Application.Quit();
		}
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
