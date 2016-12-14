using UnityEngine;
using System.Collections;

public class FixScale : MonoBehaviour {

    Vector3 scale;
    void Awake()
    {
        scale = transform.localScale;
    }
    void LateUpdate()
    {
        transform.localScale = scale;
    }
}
