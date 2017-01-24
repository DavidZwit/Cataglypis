using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

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
        if (Input.GetMouseButton(0) != true) return;

        Vector2 mouseWorldPos = camera.ScreenToWorldPoint(Input.mousePosition);



        gameObject.transform.position = (Vector3) mouseWorldPos;


        if (Input.GetMouseButtonDown(0) == true && tapParticle != null)
                Instantiate(tapParticle, mouseWorldPos, Quaternion.identity);

    }
}
