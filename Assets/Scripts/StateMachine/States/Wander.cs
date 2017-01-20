using UnityEngine;
using System.Collections;

namespace bullStates
{
    public class Wander : State {

        GameObject self;
        GameObject target;

        float angryCooldown;
        float currAngryCooldown;
        float angryRange;
    

        public Wander (GameObject _target, float _angryRange, float _angryCooldown)
        {
            target = _target;
            angryRange = _angryRange;
            angryCooldown = _angryCooldown;
        }

        public void Enter(GameObject obj, Animation amin)
        {
            self = obj;
            currAngryCooldown = angryCooldown;
        }

        public bool Reason()
        {
            if (Vector2.Distance(self.transform.position, target.transform.position) < angryRange && currAngryCooldown < 0)
                return false;
            else return true;
        }

        public void Act()
        {
            currAngryCooldown -= Time.deltaTime;
            //idel animation
        }

        public StatesEnum Leave()
        {
            return StatesEnum.alert;
        }
    }

}
