using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject dialogueBox;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image portraitImage;
    public GameObject spacePrompt; // Optional: Drag a "Press Space" icon here

    [Header("Settings")]
    public float typingSpeed = 0.04f;

    private Queue<DialogueLine> lines;
    private bool isTyping = false;
    private string currentFullText;
    private DialogueData currentDialogueData;

    // Safety flag to prevent the 'K' interact key from skipping the first line
    private bool canAdvance = false;

    void Awake()
    {
        lines = new Queue<DialogueLine>();
        if (dialogueBox != null) dialogueBox.SetActive(false);
        if (spacePrompt != null) spacePrompt.SetActive(false);
    }

    public void StartDialogue(DialogueData dialogue)
    {
        currentDialogueData = dialogue;
        TogglePlayerMovement(false);
        dialogueBox.SetActive(true);

        // Reset the safety flag so the initial 'K' press isn't counted
        canAdvance = false;

        lines.Clear();
        foreach (DialogueLine line in dialogue.conversation)
        {
            lines.Enqueue(line);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.text = currentFullText;
            isTyping = false;
            if (spacePrompt != null) spacePrompt.SetActive(true);
            return;
        }

        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        if (spacePrompt != null) spacePrompt.SetActive(false);
        DialogueLine currentLine = lines.Dequeue();

        nameText.text = currentLine.characterName;
        portraitImage.sprite = currentLine.characterPortrait;
        currentFullText = currentLine.text;

        StartCoroutine(TypeSentence(currentFullText));
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
        if (spacePrompt != null) spacePrompt.SetActive(true);
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        if (spacePrompt != null) spacePrompt.SetActive(false);

        if (currentDialogueData != null && currentDialogueData.givesQuest)
        {
            LevelGoal goal = Object.FindFirstObjectByType<LevelGoal>();
            if (goal != null)
            {
                goal.SetNewObjective(
                    currentDialogueData.questItemName,
                    currentDialogueData.questAmount,
                    currentDialogueData.questDescription
                );
            }
        }

        TogglePlayerMovement(true);
    }

    private void TogglePlayerMovement(bool canMove)
    {
        PlayerMovement player = Object.FindFirstObjectByType<PlayerMovement>();
        if (player != null)
        {
            player.isLockedByDialogue = !canMove;
        }
    }

    void Update()
    {
        if (!dialogueBox.activeSelf) return;

        // Ensure the player has released the 'K' or 'Space' key at least once 
        // before we allow them to click through the dialogue.
        if (!canAdvance)
        {
            if (!Input.GetKey(KeyCode.K) && !Input.GetKey(KeyCode.Space))
            {
                canAdvance = true;
            }
            return;
        }

        // Only listen for Space key to advance
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
        }
    }
}