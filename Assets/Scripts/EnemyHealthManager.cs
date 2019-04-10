using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int health;
    public Text scoreText;
    public int scoreValue;
    private GameController gameController;

    private int currentHealth;

    public float flashLength;
    private float flashCounter;

    private Renderer rend;
    private Color storedColor;

    
    private int count;

    // Use this for initialization
    void Start () {
        currentHealth = health;

        rend = GetComponent<Renderer>();
        storedColor = rend.material.GetColor("_Color");

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

    }
	
	// Update is called once per frame
	void Update () {
		
        if(currentHealth <= 0)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
         
            gameController.AddScore(scoreValue);
        }
        if (flashCounter > 0)
        {
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                rend.material.SetColor("_Color", storedColor);
            }
        }

    }

    void SetScore ()
    {
        scoreText.text = "Score: " + count.ToString ();
    }

    public void hurtEnemy(int damage)
    {
        currentHealth -= damage;
        flashCounter = flashLength;

        rend.material.SetColor("_Color", Color.red);
    }
}
