using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPattern : StateMachineBehaviour
{
    private float timer;
    public float minTime;
    public float maxTime;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            animator.SetTrigger("homing");
            animator.SetTrigger("360Undestroyable");
            animator.SetTrigger("360Combo");
            animator.SetTrigger("ThreeLines");
            animator.SetTrigger("360Destroyable");
            animator.SetTrigger("FlowerBuds");

        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    
}
