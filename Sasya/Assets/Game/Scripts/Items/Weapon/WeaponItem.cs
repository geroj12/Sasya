using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Purgatory
{
    [CreateAssetMenu(menuName ="R2/Items/Weapon Item")]
    public class WeaponItem : Item
    {
        public GameObject modelPrefab;
        public string oneHanded_anim = "Empty";
        public string twoHanded_anim = "Two Handed";
        public ItemActionContainer[] itemActions;
        
        [System.NonSerialized]
        public WeaponHook weaponHook;

    }

}
