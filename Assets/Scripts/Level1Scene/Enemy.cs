using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private Transform _target;
    private int _waypointsIndex = 0;

    void Start()
    {
        _target = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 _dir = _target.position - transform.position;
        transform.Translate(_dir.normalized * _speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if(_waypointsIndex >= Waypoints.points.Length -1)
        {
            Destroy(gameObject);
            return;
        }
        _waypointsIndex++;
        _target = Waypoints.points[_waypointsIndex];
    }
}
