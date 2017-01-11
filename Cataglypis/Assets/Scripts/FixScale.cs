using UnityEngine;
using System.Collections;

public class FixScale : MonoBehaviour {
    Vector3 scale;
    Transform parenTransform;
    void Awake()
    {
        scale = transform.localScale;
    }

    void Start()
    {
        parenTransform = transform.parent.transform;
    }
    void LateUpdate()
    {
        Vector3 curentScale = new Vector3(scale.x / parenTransform.localScale.x, scale.y / parenTransform.localScale.y, scale.z / parenTransform.localScale.z);
        transform.localScale = curentScale;
    }
}
