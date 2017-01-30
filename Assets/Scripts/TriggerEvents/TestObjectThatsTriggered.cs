using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class TestObjectThatsTriggered : MonoBehaviour, ITrigger {

    private TextMesh mesh;
    [SerializeField]
    private Door door;
    private bool finished = false;
    void Start()
    {
        mesh = GetComponent<TextMesh>();
    }
    public void Triggered(GameObject target)
    {
        if(!finished)
        {
            finished = true;
        }
        door.Open();
    }
    public void UnTriggered(GameObject target)
    {
        mesh.text = "";
    }
    public void FailingTrigger(GameObject target)
    {
    }
}
