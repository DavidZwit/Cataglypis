using UnityEngine;
using System;

public class PlayerMerge : IsMergeable {

    public static Action<IsMergeable> IMerged;
    public static Action<IsMergeable> IFailedToMerge;
    public static Action<int>ChangeHealth;
    [SerializeField]
    private float minSize = .1f;
    [SerializeField]
    private float maxSize = 2;


    void OnEnable()
    {
        IsMergeable.OnMerge += MergeHappend;
    }

    void OnDisable()
    {
        IsMergeable.OnMerge -= MergeHappend;
    }

    void MergeHappend(IsMergeable mergeScript)
    {
        float otherSize = mergeScript.size;
        Texture2D otherTexture = mergeScript.tex;

        if (size >= otherSize) {
            if (size < maxSize) {
                size += otherSize;
                if (IMerged != null)
                    IMerged(mergeScript);
                if (mergeScript.gameObject.tag == "HealthPack")
                    ChangeHealth(1);
            }
            mergeScript.DestroyMe();
        }//grow(), merge and destroy other

        else if (size < otherSize && size > minSize) {
            if (IFailedToMerge != null)
            {
                ChangeHealth(-1);
                IFailedToMerge(this);
            }
                
        } //Break into two()

        if (UpdatedSize != null)
            UpdatedSize(size);
    }
}
