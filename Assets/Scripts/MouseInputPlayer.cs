using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputPlayer : MonoBehaviour
{
    private Camera camera;

    private EntityMovement pMovement;
    private Vector2 oldMousePos;

    [SerializeField]
    private float dashFlickSpeed = 7;

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
        Vector2 mouseWorldPos = camera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0) == true)
        {

            float mouseDelta = Vector2.Distance(mouseWorldPos, oldMousePos);

            if (mouseDelta > dashFlickSpeed) pMovement.Dash(mouseWorldPos, mouseDelta);
            else pMovement.MoveTo(mouseWorldPos);
        }

        oldMousePos = mouseWorldPos;

    }
}
