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
        GameObject newGameobject = Instantiate(Resources.Load("Label", typeof(GameObject))) as GameObject;
        //GameObject newGameobject = new GameObject("Score");
        newGameobject.transform.SetParent(gameObject.transform);
        newGameobject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        score = newGameobject.transform.GetChild(0).GetComponent<TextMesh>();
        /*
        score = newGameobject.AddComponent<TextMesh>() as TextMesh;
        score.characterSize = .01f;
        score.fontSize = 100;
        score.anchor = TextAnchor.LowerCenter;
        score.color = new Color(20, 20, 20);
        score.offsetZ = -2f;
        */
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