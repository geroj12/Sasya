using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDefinition : MonoBehaviour
{
    [SerializeField]
    private float radius = 3;


    public bool IsInsideArea(Vector3 position) 
    {
        return (transform.position - position).magnitude <= radius;
    }
    public Vector3 MoveAlongAreaBorder(Vector3 movement, Vector3 position) {
        float movementAngle = 90 - Mathf.Atan2(movement.z,movement.x) * Mathf.Rad2Deg;
        float angleOfpositionOnArea = 90 - Mathf.Atan2(position.z, position.x) * Mathf.Rad2Deg;
        float distanceAsAngle = DistanceBetweenAngles(movementAngle,angleOfpositionOnArea);
        float movementDistance = movement.magnitude * distanceAsAngle/90;
        float circumference = 2 * Mathf.PI * radius;
        float movedAngleAlongCircumference = movementDistance/circumference * 360;
        float positionOnCircumferenceAsAngle = angleOfpositionOnArea + NearestDirectionToAngle(angleOfpositionOnArea,movementAngle) * movedAngleAlongCircumference;
        Vector3 positionOnCircumference = new Vector3(Mathf.Sin(positionOnCircumferenceAsAngle * Mathf.Deg2Rad),0,Mathf.Cos(positionOnCircumferenceAsAngle * Mathf.Deg2Rad)) * radius + transform.position;
        positionOnCircumference.y = position.y;
        Vector3 movementVector = positionOnCircumference - position;
        return movementVector;
        return new Vector3();
    }
    private float DistanceBetweenAngles(float angle1, float angle2)
    {
        float angleDistance = Mathf.Abs(GetAngleBetween0And360Range(angle1) - GetAngleBetween0And360Range(angle2));
        if (angleDistance > 180) angleDistance = 90 - Mathf.Abs(360 - angleDistance  - 180) % 90;

        Debug.Log(angleDistance);
        return angleDistance;
    }
   private float GetAngleBetween0And360Range(float angle)
    {
        while (angle < 0)
        {
            angle += 360;
        }

        angle = angle % 360;
        return angle;
    }
    public float NearestDirectionToAngle(float angle, float wantedAngle)
    {
        if (angle < wantedAngle)
        {
            return BoolToDirection(angle + 180 > wantedAngle);
        }
        else
        {
            return BoolToDirection(!(wantedAngle + 180 > angle));
        }
    }

    int BoolToDirection(bool statement)
    {
        if (statement)
        {
            return 1;
        }
        return -1;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
