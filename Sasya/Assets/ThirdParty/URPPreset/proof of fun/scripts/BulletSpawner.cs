using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletResource;
    public GameObject bulletResourceND;
    public GameObject bulletResourceSpecial;
    public GameObject player;
    public float minRotation;
    public float maxRotation;
    public int numberofBullets;
    public bool isRandom;

    public float cooldown;
    float timer;
    public float special_fire_rate = 500;
    float special_timer;
    public float bulletSpeed;
    public Vector3 bulletVelocity;

    float[] rotations;

    // Start is called before the first frame update
    void Start()
    {
        timer = cooldown;
        rotations = new float[numberofBullets];
        if (!isRandom) {
            DistributeRotations();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0) {
            SpawnBullets();
            timer = cooldown;
        }
        timer -= Time.deltaTime;

        shoot_at_player();
    }
    public float[] RandomRotations() {
        for (int i = 0; i < numberofBullets; i++) {
            rotations[i] = Random.Range(minRotation, maxRotation);
        }
        return rotations;


    }

    public float[] DistributeRotations()
    {
        for (int i = 0; i < numberofBullets; i++) {
            var fraction = (float)i / (float)numberofBullets;
            var difference = maxRotation - minRotation;
            var fractionOfDifference = fraction * difference;
            rotations[i] = fractionOfDifference + minRotation;
        }
        foreach (var r in rotations) print(r);
        return rotations;
    }

    public GameObject[] SpawnBullets() {
        if (isRandom) {
            RandomRotations();
        }

        GameObject[] spawnedBullets = new GameObject[numberofBullets];
        for (int i = 0; i < numberofBullets; i++)
        {
            if (Random.value >= 0.5)
            {
                spawnedBullets[i] = Instantiate(bulletResource);
            }
            else spawnedBullets[i] = Instantiate(bulletResourceND);
            spawnedBullets[i].transform.position = new Vector3(0, 0, 0);
            var b = spawnedBullets[i].GetComponent<Enemy_Bullet>();
            b.rotation = rotations[i];
            b.speed = bulletSpeed;
            b.velocity = bulletVelocity;

        }
        return spawnedBullets;
    }

    public void shoot_at_player() {
        special_timer++;

        if (special_timer >= special_fire_rate) {
            GameObject specialBullet = new GameObject();
            specialBullet = Instantiate(bulletResourceSpecial);


            specialBullet.transform.LookAt(player.transform, Vector3.up);
            var b = specialBullet.GetComponent<Enemy_Bullet>();
            b.rotation = specialBullet.transform.rotation.eulerAngles.y;
            Debug.Log(specialBullet.transform.rotation.y);

            special_timer = 0;
            Debug.Log("Spawned");
        }
    
    }
}
