using UnityEngine;
using System.Collections;

namespace bullStates
{
    public class Stun : State {

        GameObject self;
        float stunTime;
        float currStunTime;

        public Stun (float _stunTime)
        {
            stunTime = _stunTime;
        }

        public void Enter(GameObject obj, Animation amin)
        {
            self = obj;
            currStunTime = stunTime;
        }

        public bool Reason()
        {
            if (currStunTime <= 0)
                return false;
            else return true;
        }

        public void Act()
        {
            stunTime -= Time.deltaTime;
            //play stunn animation
        }

        public StatesEnum Leave()
        {
            return StatesEnum.idle;
        }
    }

}
