using UnityEngine;
using System.Collections;
using System;


public class FollowObject : MonoBehaviour {

    [SerializeField]
    float stoppingPower = 10;

    [SerializeField]
    Vector3 offset = new Vector3();

    [SerializeField]
    GameObject target;

    public bool Follow = true;

    private Vector3 distance;

    private Rigidbody2D rb;

    private Func<int> ApplyTranslation;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start ()
    {


        if (rb != null) ApplyTranslation = () => {
            rb.velocity = distance;
            return 0;
        };
        else ApplyTranslation = () => {
            gameObject.transform.Translate(distance / stoppingPower);
            return 0;
        };
    }

	void FixedUpdate ()
    {

        if (Follow != true || target == null) return;
        distance = new Vector3(
                       target.transform.position.x - gameObject.transform.position.x,
                       target.transform.position.y - gameObject.transform.position.y,
                       0
                   ) + offset;

        ApplyTranslation();
    }

    public Vector3 Distance
    {
        get { return distance; }
    }
}
