using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionHolder : MonoBehaviour
{
    private static int enemyValue = 10;

void OnTriggerEnter2D(Collider2D other)
    {
        Player1 controller = other.GetComponent<Player1>();

        if (controller != null)
        {
 foreach(GameObject go in GameObject.FindGameObjectsWithTag("Enemy")) {
            Destroy(go);
            Destroy(gameObject);
            ScoreScript.score += enemyValue * 10;  
 }
     }
 }
}
