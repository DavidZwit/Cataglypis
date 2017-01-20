using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class TestObjectThatsTriggered : MonoBehaviour, ITrigger {

    private TextMesh mesh;
    [SerializeField]
    private Door door;
    void Start()
    {
        mesh = GetComponent<TextMesh>();
        mesh.text = "Not enough mass";
    }
    public void Triggered(GameObject target)
    {
        mesh.text = "You got it!";
        door.Open();
    }
    public void UnTriggered(GameObject target)
    {
        mesh.text = "";
    }
    public void FailingTrigger(GameObject target)
    {
        mesh.text = "Not enough mass";
    }
}
