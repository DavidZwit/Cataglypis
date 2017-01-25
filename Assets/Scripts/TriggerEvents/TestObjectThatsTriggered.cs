using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class TestObjectThatsTriggered : MonoBehaviour, ITrigger {

    private TextMesh mesh;
    [SerializeField]
    private Door door;
    [SerializeField]
    private DialogueManager dialogueManager;
    private bool finished = false;
    void Start()
    {
        mesh = GetComponent<TextMesh>();
        mesh.text = "Not enough mass";
    }
    public void Triggered(GameObject target)
    {
        if(!finished)
        {
            finished = true;
        }
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
