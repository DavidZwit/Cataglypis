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
        
    }
}
