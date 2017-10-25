using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collission detected!");
        
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        Debug.Log("Trigger!");
        Brick.brickCount = 0;
        levelManager.Lose();
    }


}
