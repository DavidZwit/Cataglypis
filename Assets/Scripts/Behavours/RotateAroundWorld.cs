using UnityEngine;
using System.Collections;

public class RotateAroundWorld : MonoBehaviour {

    private Rigidbody2D rb;

    [SerializeField]
    private float speed = 5f;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        transform.Rotate(rb.velocity.y *speed *Time.timeScale, -rb.velocity.x*speed * Time.timeScale,0,Space.World);
    }
}
