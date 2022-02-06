using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    
   void OnTriggerEnter2D(Collider2D other)
    {
        Player1 controller = other.GetComponent<Player1>();

        if (controller != null)
        {
            SceneManager.LoadScene(3);
            transform.position = new Vector3(-15.5f, -2.5f, 0.0f);
        }
    }
}
