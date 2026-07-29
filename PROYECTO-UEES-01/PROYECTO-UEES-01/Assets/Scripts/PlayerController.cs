using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;  

public class PlayerController : MonoBehaviour
{
    public float playerJumpForce = 20f;
    public float playerSpeed = 5f;
    public Sprite[] mySprites;
    private int index = 0;

    public AudioClip jumpSound;      // Arrastra el clip de audio desde el Inspector
    private AudioSource myAudioSource;

    private Rigidbody2D myrigidbody2d;
    private SpriteRenderer mySpriteRenderer;
    public GameObject Bullet;
    private GameManager myGameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       myrigidbody2d = GetComponent<Rigidbody2D>();
       mySpriteRenderer = GetComponent<SpriteRenderer>(); // Para cambiar el sprite del jugador.
       StartCoroutine(WalkCoRutine());
       myGameManager = GameObject.FindObjectOfType<GameManager>(); 
    }

    // Update is called once per frame
    
    void Update()
    {
        // Movimiento constante
        myrigidbody2d.linearVelocity =
            new Vector2(playerSpeed, myrigidbody2d.linearVelocity.y);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myrigidbody2d.linearVelocity =
                new Vector2(playerSpeed, playerJumpForce);
            
            if (myAudioSource != null && jumpSound != null)
            {
                myAudioSource.PlayOneShot(jumpSound);
            }
        }
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ItemGood"))
        {
            Destroy(collision.gameObject);
            myGameManager.AddScore();
        }
        else if (collision.CompareTag("ItemBad"))
        {
            Destroy(collision.gameObject);
            PlayerDeath();
        }
        else if (collision.CompareTag("DeathZone"))
        {
            PlayerDeath();
        }
    }
    void PlayerDeath()
    {
        SceneManager.LoadScene("GameScene");
    }
    IEnumerator WalkCoRutine()
    {
        yield return new WaitForSeconds(0.1f);
        mySpriteRenderer.sprite = mySprites[index];
        index++;
        if (index == 3)
        {
            index = 0;
        }
        StartCoroutine(WalkCoRutine());
    }
}
