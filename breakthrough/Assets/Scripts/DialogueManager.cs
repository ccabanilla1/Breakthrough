using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText; // Reference to the dialogue text box
    public float textDelay = 1f; // Delay before text appears

    void Start()
    {
        StartCoroutine(ShowDialogue()); // Start the dialogue sequence
    }

    IEnumerator ShowDialogue()
    {
        yield return new WaitForSeconds(textDelay); // Wait before showing dialogue
        dialogueText.text = "Where am I?"; // Display the text
    }
}

