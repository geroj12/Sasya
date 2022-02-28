using UnityEngine;

public class TriggerSphere : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 1.0f);
    }
}
