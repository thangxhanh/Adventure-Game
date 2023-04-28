using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private AudioSource finishSource;
    // Start is called before the first frame update
    void Start()
    {
        finishSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player") {
            finishSource.Play();
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        
    }
}
