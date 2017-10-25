using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Paddle paddle;
    private bool started = false;
    private Vector3 paddleToBallVector;
    
   
    // Use this for initialization
    void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if(!started) this.transform.position = paddle.transform.position + paddleToBallVector;

        if (Input.GetMouseButtonDown(0) && !started)
        {
            Debug.Log("Mouse clicked");
            started = true;

            this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
        }
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        Debug.Log("LOL?");

        Vector2 tweak = new Vector2(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
       // Vector2 tweak2 = new Vector2(Random.Range(-0.2f, 0f), Random.Range(0f, 0.2f));
        if (started)
        {

            GetComponent<AudioSource>().Play();
            this.GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }
}
