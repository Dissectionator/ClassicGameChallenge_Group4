using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public int SpawnerHP = 10;
    [SerializeField]
    private GameObject mousePrefab;

    [SerializeField]
    private float mouseInterval = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemyZ(mouseInterval, mousePrefab));

    }

    private IEnumerator spawnEnemyZ(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(76f, 10f), Random.Range(76f, 10f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemyZ(interval, enemy));


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