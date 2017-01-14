using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDestroyedByBull : IsMergeable {

	void OnEnable()
    {
        IsMergeable.HitObject += MergeHit;
    }

    void OnDisable()
    {
        IsMergeable.HitObject -= MergeHit;
    }


    void MergeHit(IsMergeable hitObj, GameObject gotHitObject)
    {
        if (hitObj.gameObject.tag == "Bull" && gotHitObject.gameObject == gameObject)
        {
            //play particles and stuff
            DestroyMe();
        }
    }
}
