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
    void OnTriggerEnter2D(Collider2D coll)
    {
        mergeScript = coll.GetComponent<PlayerMerge>();
        if (mergeScript != null)
        {
            Debug.Log("trigger enter");
            if (mergeScript.size >= minWeight && mergeScript.size <= maxWeight)
            {
                ExecuteEvents.Execute<ITrigger>(target, null, (x, y) => x.Triggered(target));
            }
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (mergeScript != null)
            ExecuteEvents.Execute<ITrigger>(target, null, (x, y) => x.UnTriggered(target));
    }
}
