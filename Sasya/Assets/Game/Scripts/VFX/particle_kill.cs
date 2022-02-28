using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle_kill : MonoBehaviour
{
    [SerializeField]
    private float timetokill;

    private float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= timetokill) {
            Destroy(this.gameObject);
        }
    }
}
