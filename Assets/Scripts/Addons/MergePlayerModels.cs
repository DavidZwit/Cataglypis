using UnityEngine;
using System.Collections;

public class MergePlayerModels : MonoBehaviour {

	void OnEnable()
    {
        PlayerMerge.IMerged += PlayerMerged;
    }

    void OnDisable()
    {
        PlayerMerge.IMerged-= PlayerMerged;
    }

    void PlayerMerged(IsMergeable mergeScript)
    {
        if (mergeScript.mergeMesh != null)
        {

            GameObject mergeStuff = Instantiate(mergeScript.mergeMesh) as GameObject;

            mergeStuff.transform.rotation = Random.rotation;


            mergeStuff.transform.parent = gameObject.transform;
            mergeStuff.transform.position = Vector3.zero;

        }
    }

}
