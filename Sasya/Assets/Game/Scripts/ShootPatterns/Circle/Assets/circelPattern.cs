using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circelPattern : MonoBehaviour , IPattern
{
    public int angleOffSet = 15;
    
  public void perform (Enemy2 enemy)
    {
        for (int i = 0; i < 360; i += angleOffSet)
        {
            enemy.Shoot(i);
        }
        _delay = Random.Range(0.5f, 2.0f);
    }
    public float _delay = 1.0f;
    public float delay { get { return _delay; } }
}
