using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Camera2D : MonoBehaviour
{
    public Transform targetPlayer;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(targetPlayer.position.x +6f,0,-10);   
    }
}
