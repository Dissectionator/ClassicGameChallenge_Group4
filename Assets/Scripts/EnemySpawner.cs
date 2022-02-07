using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int SpawnerHP = 10;
[SerializeField]
private GameObject mousePrefab;

[SerializeField]
private float mouseInterval = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(mouseInterval, mousePrefab));
    }

private IEnumerator spawnEnemy(float interval, GameObject enemy)
{
    yield return new WaitForSeconds(interval);
    GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-4f,-5f), Random.Range(-4f, -5f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
}


    public void TakeDamage(int damage)
    {
        SpawnerHP -= damage;
        if (SpawnerHP <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
