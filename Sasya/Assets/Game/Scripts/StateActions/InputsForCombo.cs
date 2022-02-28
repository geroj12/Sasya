using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Purgatory
{
    public class InputsForCombo : StateAction
    {
        bool Rb, Rt, Lb, Lt, isAttacking;

        PlayerStateManager states;
        public InputsForCombo(PlayerStateManager playerStates)
        {
            states = playerStates;
        }
        public override bool Execute()
        {
            states.horizontal = Input.GetAxis("Horizontal");
            states.vertical = Input.GetAxis("Vertical");

            if (states.canDoCombo == false)
                return false;

            Rb = Input.GetButton("RB");
            Rt = Input.GetButton("RT");
            Lb = Input.GetButton("LB");
            Lt = Input.GetButton("LT");

            AttackInputs attackInput = AttackInputs.none;

            if (Rb || Rt || Lb || Lt)
            {
                Debug.Log("theres combo input");
                isAttacking = true;

                if (Rb)
                {
                    attackInput = AttackInputs.rb;
                }
                if (Rt)
                {
                    attackInput = AttackInputs.rt;
                }
                if (Lb)
                {
                    attackInput = AttackInputs.lb;
                }
                if (Lt)
                {
                    attackInput = AttackInputs.lt;
                }
            }

            if (attackInput != AttackInputs.none)
            {
                isAttacking = false;
            }

            return false;
        }
    }
}
