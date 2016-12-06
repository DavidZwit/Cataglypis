﻿using UnityEngine;
using System.Collections;

public class ChangeToPlayerSize : MonoBehaviour {

    [SerializeField]
    float sizeMultiplier = 1;

	void OnEnable()
    {
        PlayerMerge.IMerged += ChangeSize;
    }

    void OnDisable ()
    {
        PlayerMerge.IMerged -= ChangeSize;
    }

    void ChangeSize(float size)
    {
        gameObject.transform.localScale = new Vector3(size, size, 0) * sizeMultiplier;
    }
}