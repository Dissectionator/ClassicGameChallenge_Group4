using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player1 : MonoBehaviour
{
    public static float speed = 3.0f;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public static int HPr = 500;
    public static float HP = HPr;
    public static int maxHealth = 500;
    public static int atk = 0;
    public static int spd = 0;
    public static int def = 0;
    Animator animator;
    AudioSource audioSource;
    public int keyValue = 0;
    public Text keyText;
    public int potionAmount = 0;
    public Text potionText;
    
    public GameObject projectilePrefab;

    Vector2 lookDirection = new Vector2(1, 0);
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
         keyText.text = "" + keyValue.ToString();
         potionText.text = "" + potionAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (Input.GetKey(KeyCode.C) && GameObject.FindGameObjectsWithTag("Spatula").Length < 1)
        {
            speed = 0.0f;
            Launch();
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            speed = 3.0f;
        }

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

    keyText.text = "" + keyValue.ToString();
    potionText.text = "" + potionAmount.ToString();

     animator.SetFloat("Move X", lookDirection.x);
     animator.SetFloat("Move Y", lookDirection.y);
     animator.SetFloat("Speed", move.magnitude);


 if (HP <= 0)
        {
            speed = 0.0f;
               
        }
    }
   
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;


       rigidbody2d.MovePosition(position);
    

        if (Input.GetKey("escape"))
        {

            Application.Quit();

        }
    }
    
    public void ChangeHealth(int amount)
    {
        HP = Mathf.Clamp(HP + amount, 0, maxHealth);


    }
    

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
   
    private List<Key.KeyType> keyList;
    

private void Awake() {
    keyList = new List<Key.KeyType>();
}

public void AddKey(Key.KeyType keyType) {
    keyList.Add(keyType);
}
public void RemoveKey(Key.KeyType keyType) {
    keyList.Remove(keyType);
}

public bool ContainsKey(Key.KeyType keyType) {
    return keyList.Contains(keyType);
}


    private void OnTriggerEnter2D(Collider2D collider) {
    Key key = collider.GetComponent<Key>();
    if (key != null) {
        keyValue += 1;
        keyText.text = "" + keyValue.ToString();
        ScoreScript.score += 100;
        AddKey(key.GetKeyType());
        Destroy(key.gameObject);
    }

KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
if (keyDoor != null) {
    if (ContainsKey(keyDoor.GetKeyType())) {
        keyValue -= 1;
        RemoveKey(keyDoor.GetKeyType());
        keyDoor.OpenDoor();
        ScoreScript.score += 150;
        
    }
}
}
}


