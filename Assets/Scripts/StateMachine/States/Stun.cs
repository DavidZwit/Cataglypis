using UnityEngine;
using System.Collections;

public class Stun : State {

    public void Enter(GameObject obj, Animation amin)
    {

    }

    public bool Reason()
    {
        return false;
    }

    public void Act()
    {

    }

    public StatesEnum Leave()
    {
        return StatesEnum.idle;
    }
}
