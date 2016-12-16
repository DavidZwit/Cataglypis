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
        GetComponent<IsMergeable>().UpdatedSize += UpdateSize;
        UpdateSize(GetComponent<IsMergeable>().size);
    }
    void OnDisable ()
    {
        GetComponent<IsMergeable>().UpdatedSize -= UpdateSize;
    }

    public void UpdateSize(float size)
    {
        float curentScale = size*sizeMultiplier;
        gameObject.transform.localScale = new Vector3(.3f+curentScale, .3f+curentScale, .3f+curentScale);
    }
}
