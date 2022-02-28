using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody shotTemplate;

public void Shoot (float angle)
    {
        var direction = Quaternion.Euler(0, angle , 0) * Vector3.right;
        var newShot = Instantiate(shotTemplate, transform.position, Quaternion.identity);
        newShot.AddForce(direction * 100);
    }

    private void Start()
    {
        StartCoroutine(shootcircles());
    }
    void shootcircle ()
    {
        for (int i = 0; i <360; i+=15)
        {
            Shoot(i);
        }
    }
    void shootRandom ()
    {
        for (int i = 0; i <10; i++)
        {
            Shoot(UnityEngine.Random.Range(0 , 360));
        }
    }
    IEnumerator shootcircles ()
    {
        while (true)
        {
            shootcircle();
           yield return new WaitForSeconds(1.0f); 
            shootRandom();
           yield return new WaitForSeconds(1.5f);
        }
    }

}
