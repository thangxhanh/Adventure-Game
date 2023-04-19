using System;
using System.Collections;
using System.Collections.Generic;
using Packages.Rider.Editor.UnitTesting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown("space")) {
            playerRb.velocity = new Vector3(0, 14, 0);
        }
    }
}
