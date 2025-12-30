using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Conversation Phases")]
    public DialogueData questGiverDialogue; // Plays the first time
    public DialogueData inProgressDialogue; // Plays while player is hunting
    public DialogueData completedDialogue;  // Plays when items are collected

    [Header("References")]
    public DialogueManager manager;
    public GameObject promptUI;
    public KeyCode interactionKey = KeyCode.K;

    private bool isPlayerInRange = false;
    private bool hasStartedQuest = false;
    private bool hasFinishedQuest = false;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(interactionKey))
        {
            CheckQuestStatusAndTalk();
        }
    }

    void CheckQuestStatusAndTalk()
    {
        LevelGoal goal = Object.FindFirstObjectByType<LevelGoal>();
        PlayerInventory inv = Object.FindFirstObjectByType<PlayerInventory>();

        // PHASE 1: Start the Quest
        if (!hasStartedQuest)
        {
            manager.StartDialogue(questGiverDialogue);
            hasStartedQuest = true;
        }
        // PHASE 2: Check for Completion
        else if (hasStartedQuest && !hasFinishedQuest)
        {
            // Check if player has the required amount of the target item
            if (goal != null && inv != null && inv.GetItemCount(goal.targetItem) >= goal.neededAmount)
            {
                manager.StartDialogue(completedDialogue);
                hasFinishedQuest = true;

                // Tell the objective board to slide away now that NPC is happy
                goal.ClearObjective();
            }
            else
            {
                // Player doesn't have enough items yet
                manager.StartDialogue(inProgressDialogue);
            }
        }
        // PHASE 3: Quest is already done (Generic Thank You)
        else
        {
            manager.StartDialogue(completedDialogue);
        }

        if (promptUI != null) promptUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            if (promptUI != null) promptUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if (promptUI != null) promptUI.SetActive(false);
        }
    }
}