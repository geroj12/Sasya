using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public Rigidbody shotTemplate;

    public void Shoot(float angle)
    {
        var direction = Quaternion.Euler(0, angle, 0) * Vector3.right;
        var newShot = Instantiate(shotTemplate, transform.position, Quaternion.identity);
        newShot.AddForce(direction * 500);
    }
    IEnumerator RunPatterns ()
    {
        var patterns = GetComponentsInChildren<IPattern>();
        while (true)
        {
            foreach (var pattern in patterns)
            {
                pattern.perform(this);
                yield return new WaitForSeconds(pattern.delay);
            }
        }
    }
    private void OnEnable()
    {
        StartCoroutine(RunPatterns());
    }

    private void OnDisable()
    {
        StopCoroutine(RunPatterns());
    }
   
}
