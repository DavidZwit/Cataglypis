﻿using UnityEngine;
using System.Collections;

public class ChangePosToMouse : MonoBehaviour {

    Camera camera;

    [SerializeField]
    private GameObject tapParticle;

    void Awake()
    {
        camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) == true)
        {
            Vector2 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            gameObject.transform.position = mousePos;
        }
        if(Input.GetMouseButtonDown(0) == true)
            Instantiate(tapParticle, transform.position, Quaternion.identity);
    }
}