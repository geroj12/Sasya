using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public bool isFiring;

    public BulletController bullet;
    public float damage;
    public float bulletSpeed;
    public float timetodeath;
    public string weaponType;
    public int projectile_amount;
    public float spread;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;
    public AudioSource shot_sound;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isFiring) {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                shot_sound.Play();

                for (int i = 0; i < projectile_amount;i++) {
                    BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
                    newBullet.transform.rotation *= Quaternion.Euler(0,spread/2 - Random.Range(0, spread),0); 
                    newBullet.speed = bulletSpeed;
                    newBullet.timetodeath = timetodeath;
                    newBullet.damage = damage;
                }

            }
        }
        else
        {
            if (shotCounter >= 0) {
                shotCounter -= Time.deltaTime;
            }
        }
        
    }
}
