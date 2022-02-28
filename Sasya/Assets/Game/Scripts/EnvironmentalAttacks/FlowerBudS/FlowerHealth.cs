using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerHealth : MonoBehaviour
{
    public float damage = 5;
    public float maxHealth = 15;
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    void GetDamage()
    {
        currentHealth -= damage;
    }
    void DestroyFlower()
    {
        Destroy(this.gameObject);
    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
            DestroyFlower();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player_Bullet"))
        {
            GetDamage();
        }
    }
}
