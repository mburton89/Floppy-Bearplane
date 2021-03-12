using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustParticleSpawner : MonoBehaviour
{
    [SerializeField] Transform _particleSpawnPoint;
    [SerializeField] List<ThrustParticle> _thrustParticlePrefabs;
    [SerializeField] float _distanceBetweenParticles;
    public bool canSpawnParticles;

    [SerializeField] AudioSource audioSource;

    void Update()
    {
        if (canSpawnParticles)
        {
            SpawnThrustParticles();
            audioSource.volume = 1f;
        }
        else
        {
            audioSource.volume = 0;
        }
    }

    void SpawnThrustParticles()
    {
        ThrustParticle thrustParticlePrefab = _thrustParticlePrefabs[Random.Range(0, _thrustParticlePrefabs.Count)];
        float randomX = Random.Range(-_distanceBetweenParticles, _distanceBetweenParticles);
        float randomY = Random.Range(-_distanceBetweenParticles, _distanceBetweenParticles);
        Vector3 spawnPosition = new Vector3(_particleSpawnPoint.position.x + randomX, _particleSpawnPoint.position.y + randomY);
        Instantiate(thrustParticlePrefab, spawnPosition, transform.rotation);
    }

}
