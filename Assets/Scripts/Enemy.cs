using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 2;
    public Transform player;
    private Player1 playerone;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float detectionRange;
    public bool closeEnough;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        GameObject playeroneObject = GameObject.FindWithTag("PlayerTag");
        if (playeroneObject != null)
        {
            playerone = playeroneObject.GetComponent<Player1>();
        }

        player = playerone.transform;
    }


    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) <= detectionRange)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
            closeEnough = true;
        }
        else closeEnough = false;
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    public void TakeDamage (int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }
    void Die ()
    {
        Destroy(gameObject);
    }
}