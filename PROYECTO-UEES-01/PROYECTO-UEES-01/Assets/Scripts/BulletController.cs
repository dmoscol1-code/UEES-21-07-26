using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D myrigidbody2D;
    public float bulletSpeed = 10f;
    public GameManager myGameManager;  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        myGameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        myrigidbody2D.linearVelocity = new Vector2(bulletSpeed, myrigidbody2D.linearVelocity.y);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ItemGood"))
        {
            // 
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("ItemBad"))
        {
            myGameManager.AddScore();
            Destroy(collision.gameObject);
        }
    }
}
