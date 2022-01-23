using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    void Start()
    {
    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Player controller = other.GetComponent<Player>();
        Score.scoreValue += 1;
        Destroy(gameObject);
    }
}
