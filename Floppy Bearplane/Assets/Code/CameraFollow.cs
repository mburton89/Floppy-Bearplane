using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;

    void Update()
    {
        if (_target.transform.position.x >= transform.position.x)
        {
            transform.position = new Vector3(_target.transform.position.x, 0, -10);
        }
    }
}
