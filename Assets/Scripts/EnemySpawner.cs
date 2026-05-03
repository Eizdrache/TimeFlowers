using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnInterval = 4f;
    public GameObject enemyPrefab;
    private float Timer = 0f;

    private void Update()
    {
        if (Timer <= spawnInterval)
        {
            Timer += Time.deltaTime;
        }
        else
        {
            Timer = 0f;
            Vector3 SpawnPos = new Vector3(Random.Range(-8f, 8f), Random.Range(-8f, 8f), 0f);
            Instantiate(enemyPrefab, SpawnPos, Quaternion.identity);
        }

    }
}
