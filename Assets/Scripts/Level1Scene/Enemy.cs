using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float _speed = 10f;

    private Transform _tarjet;
    private int _waypointsIndex = 0;

    void Start()
    {
        _tarjet = Waypoints._points[0];
    }

    void Update()
    {
        Vector3 _dir = _tarjet.position - transform.position;
        transform.Translate(_dir.normalized * _speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _tarjet.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if(_waypointsIndex >= Waypoints._points.Length -1)
        {
            Destroy(gameObject);
            return;
        }
        _waypointsIndex++;
        _tarjet = Waypoints._points[_waypointsIndex];
    }
}
