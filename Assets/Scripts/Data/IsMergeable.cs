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
    public Texture tex; 

    public static Action<IsMergeable> OnMerge;

    void OnCollisionEnter2D (Collision2D coll)
    {
        PlayerMerge mergeScript = null;
        try { mergeScript = coll.gameObject.GetComponent<PlayerMerge>(); }
        catch { }

        if (mergeScript != null)
        {
            Merge();
            if (UpdatedSize != null) 
                UpdatedSize(size);
        }
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
