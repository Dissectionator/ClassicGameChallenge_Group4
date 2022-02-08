using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int rangex1 = 0;
    public int rangex2 = 0;
    public int rangey1 = 0;
    public int rangey2 = 0;
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
    GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(rangex1,rangex2), Random.Range(rangey1, rangey2), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
}

void update(){

}
    void OnTriggerEnter2D(Collider2D other)
    {
        SpawnerHP -= 5;
       if (gameObject.tag == "Spatula" && SpawnerHP >= 0)
        {
            Destroy(gameObject);
        }
    }
}

