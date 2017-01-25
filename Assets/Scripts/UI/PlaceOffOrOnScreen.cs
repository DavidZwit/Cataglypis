using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceOffOrOnScreen : MonoBehaviour
{
    [SerializeField] private bool startOffScreen = false;
    private Vector3 originalPosition;
    Vector3 offScreenPos = new Vector3(-100, -100, -20);

    void Awake()
    {
        originalPosition = transform.position;
    }

	void Start ()
	{
	    if (startOffScreen) transform.position = offScreenPos;
	}

    public void OffScreen(bool doThat)
    {
        if (doThat == true) transform.position = offScreenPos;
        else transform.position = originalPosition;
    }
}
