using UnityEngine;
using System.Collections;

public class DisplaySize : MonoBehaviour {

    IsMergeable mergeScript;
    TextMesh score;

    [SerializeField]
    private bool randomNaming = true;
    [SerializeField]
    private int multiplicationfactor = 0;
    private string unitTerm = "g";
    [SerializeField]
    private float zOfset = 0f;
    void Awake()
    {
        mergeScript = GetComponent<IsMergeable>();
    }

    void Start()
    {
        if (randomNaming)
        {
            multiplicationfactor = Mathf.RoundToInt(-2 + Random.value * 1);
            GetUnitTerm();
        }
        CreateText();

        UpdateSize(mergeScript.size);
    }

    void CreateText()
    {
        GameObject labelObject = Instantiate(Resources.Load("Label", typeof(GameObject))) as GameObject;
        
        labelObject.transform.SetParent(gameObject.transform);
        labelObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+ zOfset);

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
        Debug.Log(size+"|"+ Mathf.Pow(10, multiplicationfactor));
        score.text = (Mathf.Round( size*Mathf.Pow(10, -multiplicationfactor) *100)/100).ToString()+unitTerm;
        score.offsetZ = .1f;
    }
    void GetUnitTerm()
    {
        switch (multiplicationfactor)
        {
            case -3:
                unitTerm = "mg";
                break;
            case -2:
                unitTerm = "cg";
                break;
            case -1:
                unitTerm = "dg";
                break;
            case 0:
                unitTerm = "g";
                break;
            case 1:
                unitTerm = "dag";
                break;
            case 2:
                unitTerm = "hg";
                break;
            case 3:
                unitTerm = "kg";
                break;
        }
    }
}