using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    
    public Sprite[] hitSprites;
    public static int brickCount=0;
    public AudioClip crack;
    public GameObject smoke;
    private Ball ball;

    private bool isBreakable;

    private int timesHit;
    private LevelManager lm;

    // Use this for initialization
    void Start () {
        isBreakable = (this.tag == "Breakable");
        if (isBreakable) brickCount++;
        Debug.Log(brickCount);
        timesHit = 0;
        lm = GameObject.FindObjectOfType<LevelManager>();
        ball = GameObject.FindObjectOfType<Ball>();
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        ball.GetComponent<SpriteRenderer>().color = this.GetComponent<SpriteRenderer>().color;
        if(isBreakable) HandleHits();
        
    }

    void HandleHits()
    {
        Debug.Log("Collission detected!");
        timesHit++;
        int maxHits = hitSprites.Length + 1;

        if (timesHit >= maxHits)
        {
           
            brickCount--;
            
           Debug.Log(brickCount);
            PuffSmoke();
            Debug.Log("Yay yo destroyed" + this.ToString());
            AudioSource.PlayClipAtPoint(crack, transform.position, 0.3f);
            Destroy(gameObject);
            if (brickCount <= 0) SimulateWin();

        }
        else
        {
            LoadSprites();
        }

    }

    void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        smokePuff.GetComponent<ParticleSystem>().startColor = this.GetComponent<SpriteRenderer>().color;

    }

    void SimulateWin()
    {
        lm.LoadNextLevel();
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }
}
