using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Purgatory
{
    //Base class for actions
    public abstract class StateAction 
    {
        public abstract bool Execute();  //if we want to interrupt the state use "bool" no force exit will be used
    }

}
