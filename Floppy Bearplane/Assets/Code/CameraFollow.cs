using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private float _initialZ;

    private void Awake()
    {
        _initialZ = transform.position.z;
    }

    void Update()
    {
        if (_target.transform.position.x >= transform.position.x)
        {
            transform.position = new Vector3(_target.transform.position.x, 0, _initialZ);
        }
    }
}
