using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBreak : MonoBehaviour
{
    public GameObject RockLayer;

    void OnMouseDown()
    {
        //IF gameobject is tagged CoinTiles, send 1 point to score script
        Destroy(gameObject);
    }
}
