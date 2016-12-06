﻿using UnityEngine;
using System;

public class PlayerMerge : IsMergeable {

    public static Action<float> IMerged;
    public static Action IFailedToMerge;

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
        Texture otherTexture = mergeScript.tex;

        if (size >= otherSize) {
            size += otherSize;
            if (IMerged != null)
                IMerged(size);
            mergeScript.DestroyMe();
        }//grow(), merge and destroy other

        else if (size < otherSize)
            if (IFailedToMerge != null) {
                IFailedToMerge();
        } //Break into two()

        if (UpdatedSize != null)
            UpdatedSize(size);
    }
}