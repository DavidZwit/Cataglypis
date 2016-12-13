using UnityEngine;
using System.Collections;

public class ChangeToSize : MonoBehaviour {

    [SerializeField]
    float sizeMultiplier = 1;
    
    public float SizeMultiplier
    {
        get { return sizeMultiplier; }
        set { sizeMultiplier = value; }
    }

	void Awake ()
    {
        GetComponent<IsMergeable>().UpdatedSize += ChangeSize;
    }
    void OnDisable ()
    {
        GetComponent<IsMergeable>().UpdatedSize -= ChangeSize;
    }

    public void ChangeSize(float mergeSize)
    {

        gameObject.transform.localScale = new Vector3(mergeSize, mergeSize, mergeSize) * sizeMultiplier;
    }
}
