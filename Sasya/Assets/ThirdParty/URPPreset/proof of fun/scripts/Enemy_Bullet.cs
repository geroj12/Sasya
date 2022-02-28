using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    public Vector3 velocity;
    public float speed;
    public float rotation;
    public float timetodeath;
    private float ttdcounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, rotation, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        ttdcounter += Time.deltaTime;
        if (ttdcounter >= timetodeath)
        {
            Destroy(gameObject);
        }
    }
}
