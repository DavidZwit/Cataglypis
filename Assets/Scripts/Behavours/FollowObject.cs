using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour {

    [SerializeField]
    float stoppingPower = 10;

    [SerializeField]
    GameObject target;

    public bool follow = true;

	void Update ()
    {
        if (follow == true)
        {
            Vector3 distance = new Vector3(
                target.transform.position.x - gameObject.transform.position.x,
                target.transform.position.y - gameObject.transform.position.y,
                0
             );

            gameObject.transform.position += distance / stoppingPower;
        }
    }
}
