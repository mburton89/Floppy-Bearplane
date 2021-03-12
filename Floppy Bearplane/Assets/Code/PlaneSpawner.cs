using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    [SerializeField] List<SimplePlane> _planePrefabs;
    [SerializeField] float _minY;
    [SerializeField] float _maxY;
    [SerializeField] float _xSpawnPos;

    [SerializeField] float _distanceBetweenSpawns;
    private float _prevX;
    private float _currentX;

    void Start()
    {
        _currentX = transform.position.x;
        _prevX = _currentX;
    }

    void Update()
    {
        _currentX = transform.position.x;
        if (_currentX - _prevX >= _distanceBetweenSpawns)
        {
            SpawnPlane();
            _prevX = _currentX;
        }

        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }

    void SpawnPlane()
    {
        Vector3 spawnPos = new Vector3(_xSpawnPos + _currentX, Random.Range(_minY, _maxY), 0);
        SimplePlane plane = Instantiate(_planePrefabs[Random.Range(0, _planePrefabs.Count)], spawnPos, transform.rotation, null) as SimplePlane;
    }
}
