using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class TutorialEvents : MonoBehaviour, ITrigger
{
    [SerializeField]
    private DialogueManager dialogueManager;
    [SerializeField]
    private CameraShake cameraShake;
    [SerializeField]
    private Lightning lightning;
    [SerializeField]
    private PlayerMerge player;
    [SerializeField]
    private GameObject appleBall;
    [SerializeField]
    private GameObject woolBall;
    private bool firstFail = false;
    private bool tutorialFinish = false;
    [SerializeField]
    private TransitionBetweenScenes transition;
    void Start()
    {
        StartCoroutine(Begin());
    }
    IEnumerator Begin()
    {
        Dificulty.level = 1;
        WaitForFixedUpdate update = new WaitForFixedUpdate();
        yield return new WaitForSeconds(2f);
        lightning.Strike(2);
        cameraShake.Shake();
        dialogueManager.StartDialogue(DialogueData.tutorial1);
        Vector3 playerStartposiiton = player.transform.position;
        while (player.transform.position.y < playerStartposiiton.y + 4f)
            yield return update;
        dialogueManager.StartDialogue(DialogueData.tutorial2);
        while(dialogueManager.InDialogue)
            yield return update;

        player.GetComponent<DisplaySize>().enabled = true;
        if (woolBall != null)
            woolBall.GetComponent<DisplaySize>().enabled = true;

        while (player.size < 20)
            yield return update;

        cameraShake.Shake();
        lightning.Strike(10);
        dialogueManager.StartDialogue(DialogueData.tutorial4);
        while (dialogueManager.InDialogue)
            yield return update;
        lightning.Strike(5);

        while (!tutorialFinish)
            yield return update;

        transition.FadeToBlack();
        yield return new WaitForSeconds(2f);
        SceneLoaderStatic.LoadNextScene();


    }
    public void Triggered(GameObject target)
    {
    }
    public void UnTriggered(GameObject target)
    {
    }
    public void FailingTrigger(GameObject target)
    {
        cameraShake.Shake();
        if (!firstFail)
        {
            firstFail = true;
            dialogueManager.StartDialogue(DialogueData.tutorial3);
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        tutorialFinish = true;
    }
}
