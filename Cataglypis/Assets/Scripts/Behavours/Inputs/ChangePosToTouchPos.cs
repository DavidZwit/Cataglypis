using UnityEngine;
using System.Collections;

public class ChangePosToTouchPos : MonoBehaviour {

    Camera camera;
    void Awake()
    {
        camera = Camera.main;
    }

    void Update()
    {
        Vector2 touchPos = camera.ScreenToWorldPoint(Input.GetTouch(0).position);
        gameObject.transform.position = touchPos;
    }
}
