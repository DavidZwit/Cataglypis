using UnityEngine;
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

    void Awake()
    {
<<<<<<< HEAD:Assets/Scripts/Behavours/IsMergeable.cs
        if(GetComponent<MeshRenderer>())
            tex = GetComponent<MeshRenderer>().material.mainTexture as Texture2D;
        //myMesh = GetComponent<MeshFilter>().mesh;
=======
        try {
            tex = GetComponent<MeshRenderer>().material.mainTexture as Texture2D;
        } catch { }
>>>>>>> 0338a62af52ffacac2550274bed7f6d0fc34e3c5:Assets/Scripts/Behavours/merging/IsMergeable.cs
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
        if(OnMerge!=null)
            OnMerge(this);
    }

    public void DestroyMe ()
    {
        Destroy(this.gameObject);
    }
}
