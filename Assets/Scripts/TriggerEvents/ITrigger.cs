using UnityEngine;
using UnityEngine.EventSystems;

public interface ITrigger : IEventSystemHandler
{
    void Triggered(GameObject target);
    void UnTriggered(GameObject target);
    void FailingTrigger(GameObject target);
}
