using UnityEngine;

public class AnimBehavior : StateMachineBehaviour
{
    private float timer;
    public float minTime;
    public float maxTime;

    [SerializeField] private string[] transitionName;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            for (int i = 0; i < transitionName.Length; i++)
            {
                animator.SetTrigger(transitionName[i]);
            }
            
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
