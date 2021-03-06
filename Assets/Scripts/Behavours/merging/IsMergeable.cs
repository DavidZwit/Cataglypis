﻿using UnityEngine;
using System;

public class IsMergeable : MonoBehaviour {

    [SerializeField]
    public float size;

    public delegate void NewSize(float newSize);
    public NewSize UpdatedSize;

    /*
     * Still need to get the texture here
    */
    public Texture2D tex;
    [SerializeField]
    public GameObject mergeMesh; 
    [SerializeField]
    public texType type;

    public static Action<IsMergeable> OnMerge;
    public static Action<IsMergeable, GameObject> HitObject;

    public bool CanMerge { get; set; }

    void Awake()
    {
        try {
            tex = GetComponent<MeshRenderer>().material.mainTexture as Texture2D;
        } catch { }
    }

    void OnCollisionEnter2D (Collision2D coll)
    {
        PlayerMerge mergeScript = null;
        try { mergeScript = coll.gameObject.GetComponent<PlayerMerge>(); }
        catch { }

        if (mergeScript != null) {
            Merge();
            if (UpdatedSize != null) 
                UpdatedSize(size);
        }

        if (UpdatedSize != null)
            UpdatedSize(size);

        if (HitObject != null)
            IsMergeable.HitObject(this, coll.gameObject);
    }
    
    void Merge()
    {
        if (OnMerge != null)
            OnMerge(this);
    }

    public void DestroyMe ()
    {
        Destroy(this.gameObject);
    }
}
