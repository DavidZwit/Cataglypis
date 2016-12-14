using UnityEngine;
using System.Collections;

public class BounceBack : MonoBehaviour {

    void OnEnable()
    {
        PlayerMerge.IFailedToMerge += SetPosition;
    }
    void OnDisable()
    {
        PlayerMerge.IFailedToMerge -= SetPosition;
    }
    public void SetPosition(IsMergeable mergeScript)
    {
        Vector3 mergepos = mergeScript.gameObject.transform.position;
        Vector3 distance = new Vector3(mergepos.x - transform.position.x, mergepos.y - transform.position.y, 0).normalized;
        transform.position = mergepos + distance;
    }
}
