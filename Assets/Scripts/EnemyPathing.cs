using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField]
    WaveConfig waveConfig;

    List<Transform> waypoints;

    [SerializeField]
    float _moveSpeed = 2f;

    int _wayPointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[_wayPointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_wayPointIndex <= waypoints.Count -1)
        {
            var targetPosition = waypoints[_wayPointIndex].transform.position;
            var moveThisFrame = _moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveThisFrame);

            if (transform.position == targetPosition)
            {
                _wayPointIndex++;
            }
        }

        else
        {
            Destroy(this.gameObject);
        }

        
    }
}
