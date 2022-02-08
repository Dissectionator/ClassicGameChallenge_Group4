using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerTag"))
            other.transform.position = new Vector3(teleportTarget.transform.position.x, teleportTarget.transform.position.y, other.transform.position.z);
    }
}