using UnityEngine;
using System.Collections;

public class Splitting : MonoBehaviour {
    [SerializeField]
    private GameObject emptyBallObject;
    void Start()
    {

        PlayerMerge.IFailedToMerge = SplitInTwo;
    }

    public void SplitInTwo(GameObject playerObject)
    {
        GameObject clone = Instantiate(emptyBallObject, transform.position, Quaternion.identity) as GameObject;
    }
}
