using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputPlayer : MonoBehaviour
{
    private Camera camera;

    private EntityMovementDash dashPMovement;
    private EntityMovement pMovement;
    private Vector2 oldMousePos;

    private Vector2 mouseDownPos;

    [SerializeField]
    private float dashFlickSpeed = .8f;

    [SerializeField] private bool useDash;

    [SerializeField] private float maxFingerMoveSpeed = .3f;

    void Awake()
    {
        camera = Camera.main;
        if (useDash)
            dashPMovement = GetComponent<EntityMovementDash>();
        else pMovement = GetComponent<EntityMovement>();
    }

    void OnEnable()
    {
        //PlayerMerge.IFailedToMerge += dashPMovement.PlayerMerged;
    }

    void OnDisable()
    {
        //PlayerMerge.IFailedToMerge -= dashPMovement.PlayerMerged;
    }

    void FixedUpdate()
    {
        Vector2 mouseWorldPos;
        try {
            mouseWorldPos =(Vector2) camera.ScreenToWorldPoint(Input.GetTouch(0).position);
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

            if (useDash == true)
            {
                if (mouseDelta > dashFlickSpeed && mouseDelta < dashFlickSpeed * 2)
                    dashPMovement.Dash((Vector2) transform.position + (mouseWorldPos - oldMousePos), mouseDelta);
                else if (mouseDelta < maxFingerMoveSpeed) dashPMovement.MoveTo(mouseWorldPos);
            } else {
                pMovement.MoveTo(mouseWorldPos);
            }
        }

        oldMousePos = mouseWorldPos;

    }
}
