using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Purgatory
{
    public interface ILockable
    {
        bool IsAlive();
        Transform GetLockOnTarget(Transform from);
    }

    public interface IDamageble
    {
        void OnDamage(ActionContainer action);
    }

    public interface IInteractable
    {
        void OnInteract(InputManager inp);

        InteractionType GetInteractionType();
    }

    public interface IHaveAction
    {
        ActionContainer GetActionContainer();
    }

    public interface IParryable
    {
        void OnParried(Vector3 dir);
        Transform getTransform();
        void GetParried(Vector3 origin, Vector3 direction);
        bool canBeParried();
        bool canBeBackstabbed();
        void GetBackstabbed(Vector3 origin, Vector3 direction);
    }
}
