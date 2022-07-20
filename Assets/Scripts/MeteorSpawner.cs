using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject _meteorPrefab;
    public float spawnAngle = 50;

    public void GenerateMeteor()
    {
        Instantiate(_meteorPrefab, SpawnPosition(), _meteorPrefab.transform.rotation);
    }

    public Vector3 SpawnPosition()
    {
        float spawnPositionX = Random.Range(-spawnAngle, spawnAngle);
        float spawnPositionY = Random.Range(-spawnAngle, spawnAngle);
        float spawnPositionZ = Random.Range(-spawnAngle, spawnAngle);

        Vector3 generatedPosition = new Vector3(spawnPositionX, spawnPositionY, spawnPositionZ);

        return generatedPosition;
    }
}
