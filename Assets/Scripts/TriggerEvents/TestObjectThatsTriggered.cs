using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class TestObjectThatsTriggered : MonoBehaviour, ITrigger {
    public void Triggered(GameObject target)
    {
        Debug.Log("I am triggered!");
    }
    public void UnTriggered(GameObject target)
    {
        Debug.Log("I am UN-triggered!");
    }
}
