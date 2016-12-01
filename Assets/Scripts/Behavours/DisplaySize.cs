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
        GameObject newGameobject = Instantiate(new GameObject());
        newGameobject.name = "Score";
        newGameobject.transform.parent = gameObject.transform;
        

        score = newGameobject.AddComponent<TextMesh>();

        score.characterSize = .01f;
        score.fontSize = 100;
        score.anchor = TextAnchor.LowerCenter;
        score.color = new Color(20, 20, 20);

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
