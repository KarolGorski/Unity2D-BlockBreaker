using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    private Ball ball;

    float xMousePositionInBLocks;
    Vector3 paddlePos;
    bool automatic=false;
    // Use this for initialization
    void Start () {
        paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        ball = FindObjectOfType<Ball>();
    }
	
	// Update is called once per frame
	void Update () {

            if (Input.GetKeyDown("a") )
                automatic = !automatic;

        if (!automatic)
            MoveWithMouse();
        else
            MoveAutomaticly();
	}

    void MoveWithMouse()
    {
        xMousePositionInBLocks = Input.mousePosition.x / Screen.width * 16;

        //Debug.Log(xMousePositionInBLocks); // relative x position in game blocks

        paddlePos.x = Mathf.Clamp(xMousePositionInBLocks, 0.5f, 15.5f);
        this.transform.position = paddlePos;
    }
    void MoveAutomaticly()
    {
        paddlePos.x = ball.transform.position.x; //+ Random.Range(-0.5f, 0.5f);
        this.transform.position = paddlePos;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        ball.GetComponent<SpriteRenderer>().color = new Color32(0xFF, 0x5A, 0x00, 0xFF);

    }
}
