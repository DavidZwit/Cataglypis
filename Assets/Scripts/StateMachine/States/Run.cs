using UnityEngine;
using System.Collections;

namespace bullStates
{
    public class Run : State {

        GameObject self;
        GameObject target;
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


        }

        public void Enter(GameObject obj, Animation amin)
        {
            self = obj;
            currCooldown = coolDown;
            playerMerge = self.GetComponent<IsMergeable>();
        }

        public bool Reason()
        {
            Collider2D collision = Physics2D.OverlapCircle(self.transform.position, 1);
            if (collision.gameObject == target) {
                return false;
            } else if (currCooldown <= 0)
                return false;
            return true;
        }

        public void Act()
        { 
            currCooldown -= Time.deltaTime;

            self.transform.LookAt(target.transform.position);
            self.transform.Translate(self.transform.forward * speed);
        }

        public StatesEnum Leave()
        {
            if (/*hit something)*/false)
                return StatesEnum.retreat;
            else return StatesEnum.wander;
        }
    }
}
