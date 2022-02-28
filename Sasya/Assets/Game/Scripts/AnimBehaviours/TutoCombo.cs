using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoCombo : StateMachineBehaviour
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
            animator.SetTrigger("FlowerPattern");
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    
}
