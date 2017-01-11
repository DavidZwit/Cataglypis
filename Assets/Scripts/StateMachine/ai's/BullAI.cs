using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullAI : MonoBehaviour {

    StateMachine myBehaviour;
    [SerializeField]
    GameObject target;

	void Start()
    {
        myBehaviour = new StateMachine(gameObject, StatesEnum.wander);

        myBehaviour.AddState(StatesEnum.intaract, new bullStates.Run(gameObject, target, .02f, 2));
        myBehaviour.AddState(StatesEnum.alert, new bullStates.Charge(target, 3));
        myBehaviour.AddState(StatesEnum.wander, new bullStates.Wander(target, 2f, 3));
        myBehaviour.AddState(StatesEnum.retreat, new bullStates.Stun(20));

        myBehaviour.Start();
    }

    void FixedUpdate ()
    {
        if (myBehaviour != null)
        {
            myBehaviour.UpdateState();

        }
    }
}
