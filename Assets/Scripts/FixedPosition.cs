using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPosition : MonoBehaviour {

    Vector3 position;
    void Awake()
    {
        position = transform.position;
    }
    void LateUpdate()
    {
        transform.position = position;
    }
    public Vector3 Position
    {
        set { position = value; }
    }
}
