using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField]
    GameObject _enemyPrefab, _pathPrefab;
    
    [SerializeField]
    float _timeBetweenSpawns = 0.5f, _spawnRandomfactor = 0.3f, _moveSpeed = 2f;
    
    [SerializeField]
    int _numberOfEnemies = 5;

    public GameObject ReturnEnemyPrefab() { return _enemyPrefab; }
    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach (Transform child in _pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints; 
    }

    public float ReturnTimeBetweenSpawns() { return _timeBetweenSpawns; }
    public float ReturnSpawnRandomFactor() { return _spawnRandomfactor; }
    public float ReturnMoveSpeed() { return _moveSpeed; }
    public int ReturnNumberOfEnemies() { return _numberOfEnemies; }


}
