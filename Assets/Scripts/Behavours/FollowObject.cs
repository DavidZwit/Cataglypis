using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour {

    [SerializeField]
    float stoppingPower = 10;

    [SerializeField]
    Vector3 offset = new Vector3();

    [SerializeField]
    GameObject target;

    public bool follow = true;

    private Vector3 distance;
	void FixedUpdate ()
    {
        if (follow == true)
        {
            
            distance = new Vector3(
                target.transform.position.x - gameObject.transform.position.x,
                target.transform.position.y - gameObject.transform.position.y,
                0
             ) + offset;
            if(!GetComponent<Rigidbody2D>())
                gameObject.transform.Translate( distance / stoppingPower);
            else
            {
                GetComponent<Rigidbody2D>().velocity = distance;
            }
        }
    }

    public Vector3 Distance
    {
        get { return distance; }
    }
    
   
}
