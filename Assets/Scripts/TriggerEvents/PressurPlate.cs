using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class PressurPlate : MonoBehaviour {

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private int minWeight;
    [SerializeField]
    private int maxWeight;

    private PlayerMerge mergeScript;
    [SerializeField]
    private TextMesh weightString;

    
    void OnTriggerEnter2D(Collider2D coll)
    {
        mergeScript = coll.GetComponent<PlayerMerge>();
        if (mergeScript != null)
        {
            if (mergeScript.size >= minWeight && mergeScript.size <= maxWeight)
            {
                Debug.Log("defg");
                ExecuteEvents.Execute<ITrigger>(target, null, (x, y) => x.Triggered(target));
            }
            else
                ExecuteEvents.Execute<ITrigger>(target, null, (x, y) => x.FailingTrigger(target));
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (mergeScript != null)
            ExecuteEvents.Execute<ITrigger>(target, null, (x, y) => x.UnTriggered(target));
    }
    public int MinWeight{
        set {
            minWeight = value;
            weightString.text = value+"g";
        }
    }
}
