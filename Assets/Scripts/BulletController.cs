using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float speed;

    public float lifeTime;

    public int damage;

    public Text score;
    private int count;

    // Use this for initialization
    void Start () {
        count = 0;
        SetScore();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
            
        }

	}


    void SetScore()
    {
        score.text = "Score: " + count.ToString();
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealthManager>().hurtEnemy(damage);
            Destroy(gameObject);
            count = count + 1;
            SetScore();
        }
    }

}
