using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour {

    public int startHealth;
    public int currentHealth;


    public float flashLength;
    private float flashCounter;

    private Renderer rend;
    private Color storedColor;
    private PlayerController playerController;
    public AudioSource audioClip;
    public AudioSource audioClip1;

    private bool gameOver;
    private bool restart;

    public Text restartText;
    public Text gameOverText;

    // Use this for initialization
    void Start () {

        gameOver = false;
        restart = true;
        restartText.text = "";
        gameOverText.text = "";

        currentHealth = startHealth;      
        rend = GetComponent<Renderer>();
        storedColor = rend.material.GetColor("_Color");

	}
	
	// Update is called once per frame
	void Update () {
        


        if (currentHealth <= 0)
        {
            //Destroy(gameObject);           

            GameOver();
            
            if (gameOver)
            {
                Debug.Log("test");
                restartText.text = "Press 'R' for Restart";
                restart = true;
                
               
            }
        }

        

        

        if (flashCounter > 0)
            {
            flashCounter -= Time.deltaTime;
            if(flashCounter <= 0)
            {
               rend.material.SetColor("_Color", storedColor);
            }
           
        }

        

    }

    

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
        gameObject.SetActive(false);
        audioClip.Play();

    }

    public void HurtPlayerScript(int damageAmount)
    {
        currentHealth -= damageAmount;
        flashCounter = flashLength;
        
        rend.material.SetColor("_Color", Color.red);
        audioClip1.Play();
    }
}
