using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInputPlayer : MonoBehaviour
{
    private Camera camera;

    private EntityMovement pMovement;
    private Vector2 oldMousePos;

    private Vector2 mouseDownPos;

    [SerializeField]
    private float dashFlickSpeed = .8f;


    [SerializeField] private float maxFingerMoveSpeed = .3f;

    void Awake()
    {
        camera = Camera.main;
        pMovement = GetComponent<EntityMovement>();
    }

    void OnEnable()
    {
        PlayerMerge.IFailedToMerge += pMovement.PlayerMerged;
    }

    void OnDisable()
    {
        PlayerMerge.IFailedToMerge -= pMovement.PlayerMerged;
    }

    void FixedUpdate()
    {
        Vector2 mouseWorldPos;
        try {
            mouseWorldPos = (Vector2) camera.ScreenToWorldPoint(Input.GetTouch(0).position);
        } catch {
            mouseWorldPos = (Vector2) camera.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonDown(0) == true)
        {
            mouseDownPos = mouseWorldPos;
        }

        if (Input.GetMouseButton(0) == true)
        {
            float mouseDelta = Vector2.Distance(mouseWorldPos, oldMousePos);

               pMovement.MoveTo(mouseWorldPos);
        }

        oldMousePos = mouseWorldPos;

    }

};
