using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Purgatory
{
    [System.Serializable]
    public class ItemActionContainer
    {
        public string animName;
        public AttackInputs attackInput;
        public Item itemActual;
        public WeaponHook weaponHook;
    }
}
