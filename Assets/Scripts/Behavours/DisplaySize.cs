using UnityEngine;
using System.Collections;

public class DisplaySize : MonoBehaviour
{

    IsMergeable mergeScript;
    TextMesh score;

    [SerializeField]
    private bool randomNaming = true;
    [SerializeField]
    private float zOfset = 0f;
    [SerializeField]
    metricSize unitTerm = metricSize.unit;
    [SerializeField]
    private bool leftSide = false;


    string finalName;

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
        GameObject labelObject;
        if(leftSide)
            labelObject = Instantiate(Resources.Load("PlayerLabel", typeof(GameObject))) as GameObject;
        else
            labelObject = Instantiate(Resources.Load("Label", typeof(GameObject))) as GameObject;
        labelObject.transform.SetParent(gameObject.transform);
        labelObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + zOfset);

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

    void UpdateSize(float size)
    {
        if (randomNaming == true)
        {
            if (Dificulty.level >= 3)
                unitTerm = ConvertUnit.GetRandomMetricSize();
            else if (Dificulty.level == 2)
                unitTerm = ConvertUnit.GetPseudoRandomMetricSize();
        }
        score.text = ConvertUnit.GetConverted(size, unitTerm);
        score.offsetZ = .1f;
    }
}