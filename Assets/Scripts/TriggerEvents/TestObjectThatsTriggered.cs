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
        //door.Open();
    }
    public void Triggered(GameObject target)
    {
        mesh.text = "";
        door.Open();
    }
    public void UnTriggered(GameObject target)
    {
        mesh.text = "Not enough mass";

    }
}
