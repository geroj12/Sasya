using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPattern 
{
    void perform(Enemy2 enemy);
    float delay { get; }
}
