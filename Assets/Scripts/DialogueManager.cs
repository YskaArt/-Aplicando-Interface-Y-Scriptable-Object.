using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private string dialogueLine;

    public void ShowDialogue()
    {
        if (dialogueText != null)
            dialogueText.text = dialogueLine;
    }

    public void ClearDialogue()
    {
        if (dialogueText != null)
            dialogueText.text = "";
    }
}
