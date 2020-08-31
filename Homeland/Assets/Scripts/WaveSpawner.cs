using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [Header("Unity fields")]
    public Transform spawnPoint;
    public GameObject enemyPrefab;
    public Text waveCountdownText;
    public Transform parent;
    [Header("Attributes")]
    public float timeBetweenWaves = 5f;
    private float countdown = 3f;
    private int waveIndex = 0;
    

    public void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    /// <summary>
    /// Use coroutine to spawn an enemy wave. 
    /// Current equation to determine the number of enemies to spawn: number of enemies = waveIndex
    /// </summary>
    private IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    /// <summary>
    /// Instantiate a single enemy prefab
    /// </summary>
    private void SpawnEnemy()
    {
        GameObject enemyInstance = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemyInstance.transform.SetParent(parent);
    }
}
