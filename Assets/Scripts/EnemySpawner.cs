using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int SpawnerHP = 2;
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
    GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-4f,-4), Random.Range(-4, -4), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
}


    void OnCollisionEnter2D(Collision2D other)
    {
        Player1 player = other.gameObject.GetComponent<Player1>();

        if (GameObject.FindWithTag("Spatula"))
        {
            SpawnerHP -= 1;
            if (SpawnerHP <= 0)
            {
                ScoreScript.score += 100;
                Destroy(gameObject);
            }
        }

    }
}
