using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    [SerializeField]
    private Transform rotationDest;

    public void Open()
    {
        StartCoroutine(Opening(rotationDest));
    }
    IEnumerator Opening( Transform destination)
    {
        Debug.Log("defg");

        while (transform.rotation != destination.rotation)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,destination.rotation, Time.deltaTime * 1f);
            yield return new WaitForFixedUpdate();
        }
    }
}
