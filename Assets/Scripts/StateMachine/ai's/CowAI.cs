using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowAI : MonoBehaviour {
    [SerializeField]
    private Transform directionPointer;
    [SerializeField]
    private float walkRange = .5f;
    private Vector3 startPos;
	void Start () {
        startPos = gameObject.transform.position;
        StartCoroutine(goToNextDirection());
    }

    IEnumerator goToNextDirection()
    {
        directionPointer.GetComponent<FixedPosition>().Position = new Vector3(
            startPos.x - walkRange + Random.value * (2*walkRange),
            startPos.y - walkRange + Random.value * (2*walkRange),
            startPos.z);

        yield return new WaitForSeconds(1+Random.value*3);
        StartCoroutine(goToNextDirection());
    }
}
