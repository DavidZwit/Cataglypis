using UnityEngine;
using System.Collections;

public class DisplaySize : MonoBehaviour {

    IsMergeable mergeScript;
    TextMesh score;

    void Awake()
    {
        mergeScript = GetComponent<IsMergeable>();
    }

    void Start()
    {
        CreateText();

        UpdateSize(mergeScript.size);
    }

    void CreateText()
    {
        GameObject labelObject = Instantiate(Resources.Load("Label", typeof(GameObject))) as GameObject;
        
        labelObject.transform.SetParent(gameObject.transform);
        labelObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        score = labelObject.transform.GetChild(0).GetComponent<TextMesh>();
    }

    void OnEnable()
    {
        mergeScript.UpdatedSize += UpdateSize;
    }

    void OnDisable()
    {
        mergeScript.UpdatedSize -= UpdateSize;
    }

    void UpdateSize (float size)
    {
        score.text = size.ToString();
        score.offsetZ = .1f;
    }
}