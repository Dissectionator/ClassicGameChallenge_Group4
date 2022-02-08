using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{

private Player1 playerone;

    void Start()
    {
        GameObject playeroneObject = GameObject.FindWithTag("PlayerTag");
        if(playeroneObject != null)
        {
            playerone = playeroneObject.GetComponent<Player1>();
        }
    }
  public void Back()
  {
      SceneManager.LoadScene("Menu");
      Player1.HP = Player1.maxHealth;
  }

}
