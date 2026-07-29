using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class GarbageController : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
    
}
