using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Purgatory
{
    public class PickableHook : MonoBehaviour,IInteractable
    {
        public Item targetItem;
        public InteractionType intType;

        void Start()
        {
            gameObject.layer = 0; //15
        }

        public void OnInteract(InputManager inp)
        {
            if (targetItem is WeaponItem)
            {
                inp.controller.LoadWeapon(targetItem, false);
            }
            
            gameObject.SetActive(false);
        }

        public InteractionType GetInteractionType()
        {
            return intType;
        }
    }
}

