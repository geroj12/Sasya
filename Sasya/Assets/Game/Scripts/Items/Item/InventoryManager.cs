using System.Collections.Generic;
using UnityEngine;

namespace Purgatory
{
    public class InventoryManager : MonoBehaviour
    {
        WeaponHolderHook leftHook;
        WeaponItem leftItem;

        WeaponHolderHook rightHook;
        WeaponItem rightItem;

        Player controller;

        List<WeaponItem> rh_weapons = new List<WeaponItem>();
        List<WeaponItem> lh_weapons = new List<WeaponItem>();

        public void SwitchWeapon(bool isLeft)
        {
            WeaponItem result = (isLeft) ? leftItem : rightItem ;
            List<WeaponItem> l = (isLeft) ? lh_weapons : rh_weapons;
            if (result != null)
            {
                int index = l.IndexOf(result);
                index++;
                if (index > l.Count - 1)
                {
                    index = 0;
                }
                controller.LoadWeapon(l[index], isLeft);
            }
            else
            {
                controller.LoadWeapon(l[0], isLeft);
            }          
        }

        public void Init(PlayerProfile profile,Player c)
        {
            controller = c;
            #region Init Hooks
            WeaponHolderHook[] weaponHolderHooks = GetComponentsInChildren<WeaponHolderHook>();
            foreach (WeaponHolderHook hook in weaponHolderHooks)
            {
                if (hook.isLeftHook)
                {
                    leftHook = hook;
                }
                else
                {
                    rightHook = hook;
                }
            }
            #endregion
            //if (consumableItem != null)
            //    _currentConsumable = CreateConsumableHolder(consumableItem);
            UpdateReferencesFromProfile(profile);
        }

        void UpdateReferencesFromProfile(PlayerProfile profile)
        {
            ResourcesManager rm = Settings.resourcesManager;

            rh_weapons.Clear();
            lh_weapons.Clear();

            CreateItemsFromIds(profile.rightHand, ref rh_weapons, rm);
            CreateItemsFromIds(profile.leftHand, ref lh_weapons, rm);
            rh_weapons.Add(null);
            lh_weapons.Add(null);

            controller.LoadWeapon(rh_weapons[0], false);          
            controller.LoadWeapon(lh_weapons[0], true);
            
        }

        void CreateItemsFromIds(string[] ids,ref List<WeaponItem> t,ResourcesManager rm)
        {
            for (int i = 0; i < ids.Length; i++)
            {
                if (string.IsNullOrEmpty(ids[i]))
                    continue;

                Item item = rm.GetItem(ids[i]);

                if (item is WeaponItem)
                {
                    t.Add((WeaponItem)item);
                }
            }
        }    

        public WeaponHook LoadWeaponOnHook(WeaponItem weaponItem,bool isLeft)
        {
            if (isLeft)
            {
            
                leftItem = weaponItem;
                return leftHook.LoadWeaponModel(weaponItem);
                
                
            }
            else
            {
                rightItem = weaponItem;
                return rightHook.LoadWeaponModel(weaponItem);
                
            }
        }

        
    }

}
