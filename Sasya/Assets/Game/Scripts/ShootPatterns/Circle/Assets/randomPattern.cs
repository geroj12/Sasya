using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomPattern : MonoBehaviour , IPattern
{
    public void perform(Enemy2 enemy)
    {
        for (int i = 0; i < 10; i++)
        {
            enemy.Shoot(UnityEngine.Random.Range(0, 360));
        }
    }
    public float delay { get { return 1.0f; } }
}
