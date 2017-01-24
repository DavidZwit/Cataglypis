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
        yield return new WaitForSeconds(2f);
        StartCoroutine(dialogueManager.WritingDialogue(DialogueData.dialogueLines1));
        Vector3 playerStartposiiton = player.transform.position;
        while (player.transform.position.y < playerStartposiiton.y +.4f)
            yield return new WaitForFixedUpdate();
        StartCoroutine(dialogueManager.WritingDialogue(DialogueData.dialogueLines2));
        while(dialogueManager.InDialogue)
            yield return new WaitForFixedUpdate();
        player.GetComponent<DisplaySize>().enabled = woolBall.GetComponent<DisplaySize>().enabled= true;
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
            StartCoroutine(AfterFailingTreeMerge());
        }
        else
        {

        }
    }
    IEnumerator AfterFailingTreeMerge()
    {
        StartCoroutine(dialogueManager.WritingDialogue(DialogueData.dialogueLines3));
        while (player.size < 0.3)
            yield return new WaitForFixedUpdate();
        yield return new WaitForSeconds(1);
        lightning.Strike(2);
        StartCoroutine(dialogueManager.WritingDialogue(DialogueData.dialogueLines4));
        while (dialogueManager.InDialogue)
            yield return new WaitForFixedUpdate();
        lightning.Strike(2);
        Instantiate(appleBall);
        while (player.size < 1)
            yield return new WaitForFixedUpdate();
        StartCoroutine(dialogueManager.WritingDialogue(DialogueData.dialogueLines5));
        while(!tutorialFinish)
            yield return new WaitForFixedUpdate();
        transition.FadeToBlack();
        yield return new WaitForSeconds(2f);
        SceneLoader.LoadNextScene();
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        tutorialFinish = true;
    }
}
