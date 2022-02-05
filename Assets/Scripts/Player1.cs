using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
{
    public static float speed = 3.0f;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public static float HP = 100;
    public static int maxHealth = 100;
    public static int atk = 0;
    public static int spd = 0;
    public static int def = 0;
    private Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;
    Animator animator;
    public GameObject 
    projectilePrefab;
    

    Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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

        animator.SetFloat("Move X", lookDirection.x);
        animator.SetFloat("Move Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);


    }
  //  private void Awake() {
       // inventory = new Inventory();
        //uiInventory.SetInventory(inventory);


       // ItemWorld.SpawnItemWorld(new Vector3(5, 5), new ItemCount { itemType = ItemCount.ItemType.Key, amount = 1});
//ItemWorld.SpawnItemWorld(new Vector3(7, 7), new ItemCount { itemType = ItemCount.ItemType.Potion, amount = 1});
    //}

//private void OnTriggerEnter2D(Collider2D collider) {
    
       // ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
      //  if (itemWorld != null) {
            // Touching Item
          //  inventory.AddItem(itemWorld.GetItem());
          //  itemWorld.DestroySelf();
      //  }
//}
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

        if (HP == 0)
        {
            speed = 0.0f;
        }

    }
    

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

    }
}

