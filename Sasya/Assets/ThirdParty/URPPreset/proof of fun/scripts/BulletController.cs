using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speed;
    public float damage;
    public float timetodeath;
    private float ttdcounter = 0 ;
    public Animator anim;
    public BoxCollider coll;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        //implement t2d counter
        ttdcounter += Time.deltaTime;
        if (ttdcounter >= timetodeath)
        {
            anim.SetTrigger("die");
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player_Bullet") {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
        else if (collision.gameObject.tag == "Wall")
        {
            anim.SetTrigger("die");
            coll.enabled = false;
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            anim.SetTrigger("die");
            collision.gameObject.GetComponent<BossController>().HurtBoss(damage);
            coll.enabled = false;
        }
        else if (collision.gameObject.tag == "Enemy_Bullet")
        {
            anim.SetTrigger("die");
            Destroy(collision.gameObject);
            coll.enabled = false;
        }
        else if (collision.gameObject.tag == "Enemy_Bullet_ND")
        {
            anim.SetTrigger("die");
            coll.enabled = false;
        }
    }

    void Destroy() {
        Destroy(gameObject);
    }
}
