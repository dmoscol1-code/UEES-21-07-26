using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;   

public class PlayerController : MonoBehaviour
{
    public float playerJumpForce = 20f;
    public float playerSpeed = 5f;
    public Sprite[] mySprites;
    private int index = 0;

    private Rigidbody2D myrigidbody2d;
    private SpriteRenderer mySpriteRenderer;
    // private GameObject Bullet;
    // private GameManager myGameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       myrigidbody2d = GetComponent<Rigidbody2D>();
       mySpriteRenderer = GetComponent<SpriteRenderer>(); // Para cambiar el sprite del jugador.
       StartCoroutine(WalkCoRutine());
       // myGameManager = GameObject.FindObjectOfType<GameManager>(); 
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
        }
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            // Instantiate(Bullet, transform.position, Quaternion.identity);
        }
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
