using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public Animator effectanim;
    public Animator mainanim;
    public float health = 100;
    public float maxhealth = 100;
    public ParticleSystem ring;
    public BulletSpawner spawner;
    public BossActivation activation;
    public AudioSource quack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activation.activated == true || health != maxhealth) {
            mainanim.SetTrigger("activated");
            spawner.enabled = true;
        }
        if (health <= 0) {
            spawner.enabled = false;
            mainanim.SetTrigger("dead");
        }
    }

    public void HurtBoss(float damage) {
        health -= damage;
        effectanim.SetTrigger("hit");
        ring.Play();
        quack.Play();
        Debug.Log("Man...");
    }
}
