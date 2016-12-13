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
        Debug.Log("bouncy balls");
        transform.Translate(mergeScript.gameObject.transform.position - transform.position*2);
        //transform.Translate(-mergeScript.gameObject.GetComponent<Rigidbody2D>().velocity.normalized);
    }
}
