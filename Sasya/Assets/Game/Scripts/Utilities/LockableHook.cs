using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Purgatory
{
    public class LockableHook : MonoBehaviour, ILockable
    {
        public Transform GetLockOnTarget(Transform from)
        {
            return transform;
        }

        public bool IsAlive()
        {
            return true;
        }
    }
}
