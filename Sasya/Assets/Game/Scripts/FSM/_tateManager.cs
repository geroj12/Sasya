using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Purgatory
{
    //we need to create a class which inherits from this abstract class, so we can use it
    public abstract class StateManager : MonoBehaviour
    {
        State currentState;
        Dictionary<string, State> allStates = new Dictionary<string, State>();  //optimized way of handling multiple data, string as a key cause states gonna be unique.

        [HideInInspector]
        public Transform mTransform;

        private void Start()  
        {
            mTransform = this.transform;
            Init();
        }

        public abstract void Init();  //so the statemanager can be properly initialized

        public void FixedTick()
        {
            if (currentState == null)  //if current state is null, do nothing, if not call FixedTick.
                return;

            currentState.FixedTick();

        }

        public void Tick()
        {
            if (currentState == null)
                return;

            currentState.Tick();

        }

        public void LateTick()
        {
            if (currentState == null)
                return;

            currentState.LateTick();

        }

        //
        public void ChangeState(string targetId)
        {
            if (currentState != null)
            {
                //Run on exit actions of currentState
            }

            State targetState = GetState(targetId);
            //run on enter actions, change state
            currentState = targetState;
            currentState.onEnter?.Invoke();  // if (currentState.onEnter !=null) currentState.onEnter.Invoke();
        }

        //so we can get back our state
        State GetState(string targetId)
        {
            allStates.TryGetValue(targetId, out State retVal);
            return retVal;
        }

        //if u add two state with same id,it will get a error
        protected void RegisterState(string stateId, State state)
        {
            allStates.Add(stateId, state);
        }
    }

}
