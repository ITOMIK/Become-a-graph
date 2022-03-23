using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile : MonoBehaviour
{
    public bool _onScreen=false;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    public void OnBecameVisible()
    {
        _onScreen = true;
    }
    
    public void OnBecameInvisible()
    {
        _onScreen = false;
    }

}
