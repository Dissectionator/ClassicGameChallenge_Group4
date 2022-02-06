using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinishGame : MonoBehaviour
{ 
void OnTriggerEnter2D(Collider2D other)
    {
        Player1 controller = other.GetComponent<Player1>();

        if (controller != null)
        {
            SceneManager.LoadScene(4);
           
        }
    }
}
