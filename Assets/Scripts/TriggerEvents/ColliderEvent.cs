using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class ColliderEvent : MonoBehaviour
{

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private int minWeight;
    [SerializeField]
    private int maxWeight;

    private PlayerMerge mergeScript;
    void OnCollisionEnter2D(Collision2D coll)
    {
        mergeScript = coll.gameObject.GetComponent<PlayerMerge>();
        if (mergeScript != null)
        {
            if (mergeScript.size >= minWeight && mergeScript.size <= maxWeight)
                ExecuteEvents.Execute<ITrigger>(target, null, (x, y) => x.Triggered(target));
            else
                ExecuteEvents.Execute<ITrigger>(target, null, (x, y) => x.FailingTrigger(target));
        }
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        if (mergeScript != null)
            ExecuteEvents.Execute<ITrigger>(target, null, (x, y) => x.UnTriggered(target));
    }
}
