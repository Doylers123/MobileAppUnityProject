using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GunController : MonoBehaviour {

    public bool isFiring;

    public BulletController bullet;
    public float bulletSpeed;

    public float timeBetweenShots;
    private float shotCount;

    public Transform firePoint;

    public Text score;
    private int count;


    // Use this for initialization
    void Start () {
     
    }

    // Update is called once per frame
    void Update() {
        if (isFiring)
        {
            shotCount -= Time.deltaTime;
            if (shotCount <= 0)
            {
                shotCount = timeBetweenShots;
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
                newBullet.speed = bulletSpeed;
            }
        } else {
            shotCount = 0;
        }
     }
}