using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWorldEvents : MonoBehaviour {
    [SerializeField]
    private DialogueManager dialogueManager;
    [SerializeField]
    private PlayerMerge player;

    void Start () {
        StartCoroutine(Begin());
	}
	IEnumerator Begin()
    {
        yield return new WaitForSeconds(1f);
        dialogueManager.StartDialogue(DialogueData.mainWorld1);
    }
}
