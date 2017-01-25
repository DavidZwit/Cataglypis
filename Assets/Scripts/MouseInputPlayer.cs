using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputPlayer : MonoBehaviour
{
    private Camera camera;

    private EntityMovement pMovement;
    private Vector2 oldMousePos;

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
            mouseWorldPos = camera.ScreenToWorldPoint(Input.GetTouch(0).position);
        } catch{
            mouseWorldPos = camera.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0) == true)
        {
            float mouseDelta = Vector2.Distance(mouseWorldPos, oldMousePos);

            //if (mouseDelta > dashFlickSpeed && mouseDelta < dashFlickSpeed * 2) pMovement.Dash((Vector2)transform.position + (mouseWorldPos - oldMousePos), mouseDelta);
            //else if (mouseDelta < maxFingerMoveSpeed) pMovement.MoveTo(mouseWorldPos);
            pMovement.MoveTo(mouseWorldPos);
        }

        oldMousePos = mouseWorldPos;

    }
}
