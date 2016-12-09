using UnityEngine;
using System.Collections;

public class RotateAroundWorld : MonoBehaviour {

    private Rigidbody2D rb;
    private float speed = 5f;
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        transform.Rotate(rb.velocity.y *speed, -rb.velocity.x*speed,0,Space.World);
    }
}
