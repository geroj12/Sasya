using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Purgatory
{
    public class State
    {
        bool forceExit;
        List<StateAction> fixedUpdateActions; //less problems if actions are included in fixed update
        List<StateAction> updateActions;    
        List<StateAction> lateUpdateActions;

        public delegate void OnEnter();
        public OnEnter onEnter;

        public State(List<StateAction> fixedUpdateActions, List<StateAction> updateActions, List<StateAction> lateUpdateActions)
        {
            this.fixedUpdateActions = fixedUpdateActions;
            this.updateActions = updateActions;
            this.lateUpdateActions = lateUpdateActions;
        }

        //all ticks basically do the same 
        public void FixedTick()
        {
            ExecuteListOfActions(fixedUpdateActions);
        }

        public void Tick()
        {
            ExecuteListOfActions(updateActions);
        }

        public void LateTick()
        {
            ExecuteListOfActions(lateUpdateActions);
            forceExit = false;
            
        }

        //pass a list of state actions
        void ExecuteListOfActions(List<StateAction> l)
        {
            for (int i = 0; i < l.Count; i++)
            {
                if (forceExit)   //before u run the next iteration of actions, check if it is forceExit and return 0, do nothing
                    return;
              forceExit = l[i].Execute();
            }
        }
    }
}
