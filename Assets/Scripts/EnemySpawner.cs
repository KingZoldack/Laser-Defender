using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    List<WaveConfig> waveConfigs;
    int startingWaves = 0;

    // Start is called before the first frame update
    void Start()
    {
        var currentWaves = waveConfigs[startingWaves];
        StartCoroutine(SpawnAllEnemiesInWave(currentWaves));
    }

    IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.ReturnNumberOfEnemies(); enemyCount++)
        {
            Instantiate(waveConfig.ReturnEnemyPrefab(), waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(waveConfig.ReturnTimeBetweenSpawns());
        }
        
    }
}
