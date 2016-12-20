using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class TestObjectThatsTriggered : MonoBehaviour, ITrigger {

    private TextMesh mesh;
    void Start()
    {
        mesh = GetComponent<TextMesh>();
        mesh.text = "Not enough mass";

    }
    public void Triggered(GameObject target)
    {
        mesh.text = "You've won! Yay!";

    }
    public void UnTriggered(GameObject target)
    {
        //
        mesh.text = "Not enough mass";
    }
}
