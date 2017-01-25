using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour {

    [SerializeField]
    private Text dialogueText;
    [SerializeField]
    private Text characterText;
    [SerializeField]
    private Image leftCharacterImage;
    [SerializeField]
    private Image rightCharacterImage;
    [SerializeField]
    private GameObject UIObject;
    [SerializeField]
    private FollowObject playerObject;

    private bool isWriting = false;
    private bool inDialogue = false;
    private bool goToNextLine = false;

    void Update()
    {
        if (inDialogue)
        {
            if (Input.GetMouseButtonDown(0) == true)
            {
                if (isWriting)
                    isWriting = false;
                else
                    goToNextLine = true;
            }
        }
    }
    public void StartDialogue(DialogueStruct[] dialogue)
    {
        StartCoroutine(WritingDialogue(dialogue));
    }
    IEnumerator WritingDialogue(DialogueStruct[] dialogue)
    {
        UIObject.SetActive(true);
        playerObject.enabled = false;
        inDialogue = true;
        while(inDialogue)
        {
            for (int i = 0; i < dialogue.Length; i++)
            {
                leftCharacterImage.sprite = rightCharacterImage.sprite = Resources.Load<Sprite>("none");
                if (dialogue[i].allignmentRight)
                {
                    dialogueText.alignment = characterText.alignment = TextAnchor.UpperRight;
                    rightCharacterImage.sprite = Resources.Load<Sprite>(dialogue[i].art);
                }
                else
                {
                    dialogueText.alignment = characterText.alignment = TextAnchor.UpperLeft;
                    leftCharacterImage.sprite = Resources.Load<Sprite>(dialogue[i].art);
                }

                characterText.text = dialogue[i].name;
                StartCoroutine(WritingLine(dialogue[i].line));

                goToNextLine = false;
                while (!goToNextLine)
                    yield return new WaitForFixedUpdate();
            }
            inDialogue = false;
        }
        UIObject.SetActive(false);
        playerObject.enabled = true;
    }
    IEnumerator WritingLine(string line)
    {
        isWriting = true;
        dialogueText.text = "";
        
        for (int i = 0; i < line.Length; i++)
        {
            if(isWriting)
            {
                dialogueText.text += line[i];
                yield return new WaitForSeconds(0.01f);
            }
            else
            {
                dialogueText.text += line.Substring(i,line.Length-i);
                break;
            }
        }
        isWriting = false;
    }
    public bool InDialogue
    {
        get{ return inDialogue; }
    }
}
