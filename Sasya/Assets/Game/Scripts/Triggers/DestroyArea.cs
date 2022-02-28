using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        ProcessCollision(collision.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ProcessCollision(collision.gameObject);
    }

    void ProcessCollision(GameObject collider)
    {
        if (collider.CompareTag("Enemy_Bullet") || collider.CompareTag("Player_Bullet") || collider.CompareTag("Enemy_Bullet_ND"))
        {
            Destroy(collider.gameObject);
        }
    }

}
