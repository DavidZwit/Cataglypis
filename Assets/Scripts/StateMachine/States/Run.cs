using UnityEngine;
using System.Collections;

namespace bullStates
{
    public class Run : State {

        GameObject self;
        GameObject target;
        FollowObject followScript;
        float speed;

        bool stopRunning = false;

        void StopRunning(IsMergeable mergeScript, GameObject hitObject)
        {
            if (mergeScript.gameObject.tag == "Bull") {
                stopRunning = true;
            }
        }

        public Run(GameObject _self, GameObject _target, FollowObject _followScript, float _speed)
        {
            self = _self;
            target = _target;
            speed = _speed;
            followScript = _followScript;
        }

        public void Enter(GameObject obj, Animation amin)
        {
            stopRunning = false;
            self = obj;
            followScript.enabled = true;
            IsMergeable.HitObject += StopRunning;
        }
         
        public bool Reason()
        {
            if (stopRunning == true) {
                return false;
            }
            return true;
        }

        public void Act()
        { 
            
        }

        public StatesEnum Leave()
        {
            IsMergeable.HitObject += StopRunning;
            followScript.enabled = false;
            return StatesEnum.wander;
        }
    }
}
