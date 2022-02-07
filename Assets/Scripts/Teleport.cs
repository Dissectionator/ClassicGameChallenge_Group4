using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerTag"))
            thePlayer.transform.position = new Vector3(teleportTarget.transform.position.x, teleportTarget.transform.position.y, thePlayer.transform.position.z);
    }
}