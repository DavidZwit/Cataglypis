using UnityEngine;
using System.Collections;

namespace bullStates
{
    public class Charge : State {

        GameObject self;
        GameObject target;
        float chargeTime;
        float currChargeTime;

        public Charge (GameObject _target, float _chargeTime)
        {
            target = _target;
            chargeTime = _chargeTime;
        }

        public void Enter(GameObject obj, Animation amin)
        {
            self = obj;
            currChargeTime = chargeTime;
        }

        public bool Reason()
        {
            if (chargeTime <= 0)
                return false;
            return true;
        }

        public void Act()
        {
            chargeTime -= Time.deltaTime;
            self.transform.LookAt(target.transform.position);
            //play charge animation
        }

        public StatesEnum Leave()
        {
            return StatesEnum.intaract;
        }
    }

}
