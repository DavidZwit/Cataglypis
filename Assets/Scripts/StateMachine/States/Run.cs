using UnityEngine;
using System.Collections;

namespace bullStates
{
    public class Run : State {

        GameObject self;
        GameObject target;
<<<<<<< HEAD
        IsMergeable playerMerge;
        float speed;
        float coolDown;
        float currCooldown;

        public Run(GameObject _self, GameObject _target, float _speed, float _coolDown)
        {
            self = _self;
            target = _target;
            speed = _speed;
            coolDown = _coolDown;


=======
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
>>>>>>> 0338a62af52ffacac2550274bed7f6d0fc34e3c5
        }

        public void Enter(GameObject obj, Animation amin)
        {
<<<<<<< HEAD
            self = obj;
            currCooldown = coolDown;
            playerMerge = self.GetComponent<IsMergeable>();
=======
            stopRunning = false;
            self = obj;
            IsMergeable.HitObject += StopRunning;

            rb.AddForce((target.transform.position - self.transform.position).normalized * speed);

>>>>>>> 0338a62af52ffacac2550274bed7f6d0fc34e3c5
        }

        public bool Reason()
        {
<<<<<<< HEAD
            Collider2D collision = Physics2D.OverlapCircle(self.transform.position, 1);
            if (collision.gameObject == target) {
                return false;
            } else if (currCooldown <= 0)
                return false;
=======
            if (stopRunning == true) {
                return false;
            }
>>>>>>> 0338a62af52ffacac2550274bed7f6d0fc34e3c5
            return true;
        }

        public void Act()
<<<<<<< HEAD
        { 
            currCooldown -= Time.deltaTime;

            self.transform.LookAt(target.transform.position);
            self.transform.Translate(self.transform.forward * speed);
=======
        {

>>>>>>> 0338a62af52ffacac2550274bed7f6d0fc34e3c5
        }

        public StatesEnum Leave()
        {
<<<<<<< HEAD
            if (/*hit something)*/false)
                return StatesEnum.retreat;
            else return StatesEnum.wander;
=======
            IsMergeable.HitObject += StopRunning;
            return StatesEnum.wander;
>>>>>>> 0338a62af52ffacac2550274bed7f6d0fc34e3c5
        }
    }
}
