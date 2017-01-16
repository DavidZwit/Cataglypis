using UnityEngine;
using System.Collections;

namespace bullStates
{
    public class Run : State {

        GameObject self;
        GameObject target;
        FollowObject followScript;
        Rigidbody2D rb;
        float speed;

        bool stopRunning = false;

        void StopRunning(IsMergeable mergeScript, GameObject hitObject)
        {
            if (mergeScript.gameObject.tag == "Bull") {
                stopRunning = true;
            }
        }

        public Run(GameObject _self, GameObject _target, FollowObject _followScript, Rigidbody2D _rb, float _speed)
        {
            self = _self;
            target = _target;
            speed = _speed;
            followScript = _followScript;
            rb = _rb;
        }

        public void Enter(GameObject obj, Animation amin)
        {
            stopRunning = false;
            self = obj;
            IsMergeable.HitObject += StopRunning;

            rb.AddForce((target.transform.position - self.transform.position).normalized * speed);

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
            return StatesEnum.wander;
        }
    }
}
