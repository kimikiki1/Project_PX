using UnityEngine;
using TMPro;
using System.Collections;

public class LevelGoal : MonoBehaviour
{
    [Header("UI Reference")]
    public TextMeshProUGUI objectiveText;
    public RectTransform objectivePanel;

    [Header("Slide Settings")]
    public Vector2 hiddenPosition = new Vector2(600, 0); // Far right
    public Vector2 visiblePosition = new Vector2(-20, 0); // Anchored right
    public float slideDuration = 0.5f;

    [Header("Current Goal Data")]
    public string targetItem = "None";
    public int neededAmount = 0;
    public string objectiveDescription = "";

    private PlayerInventory player;

    void Start()
    {
        // Force the panel to start off-screen
        if (objectivePanel != null)
            objectivePanel.anchoredPosition = hiddenPosition;

        UpdateObjectiveUI();
    }

    public void AssignPlayer(GameObject playerObj)
    {
        player = playerObj.GetComponent<PlayerInventory>();
    }

    // Called by DialogueManager at the end of a "givesQuest" dialogue
    public void SetNewObjective(string item, int amount, string description)
    {
        targetItem = item;
        neededAmount = amount;
        objectiveDescription = description;

        UpdateObjectiveUI();

        StopAllCoroutines();
        StartCoroutine(SlidePanel(visiblePosition));
    }

    // Called by DialogueTrigger when the NPC acknowledges the quest is done
    public void ClearObjective()
    {
        targetItem = "None";
        neededAmount = 0;
        objectiveDescription = "Quest Complete!";

        UpdateObjectiveUI();

        // Wait 1 second so player sees "Complete!" then slide away
        StopAllCoroutines();
        StartCoroutine(WaitThenSlide(1.5f, hiddenPosition));
    }

    IEnumerator WaitThenSlide(float delay, Vector2 target)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(SlidePanel(target));
    }

    IEnumerator SlidePanel(Vector2 targetPos)
    {
        float time = 0;
        Vector2 startPos = objectivePanel.anchoredPosition;

        while (time < slideDuration)
        {
            objectivePanel.anchoredPosition = Vector2.Lerp(startPos, targetPos, time / slideDuration);
            time += Time.deltaTime;
            yield return null;
        }
        objectivePanel.anchoredPosition = targetPos;
    }

    public void RefreshProgress()
    {
        UpdateObjectiveUI();
    }

    void UpdateObjectiveUI()
    {
        if (objectiveText != null)
        {
            objectiveText.text = $"Goal: {objectiveDescription}";

            // Show 0/5 etc. only if a quest is active
            if (targetItem != "None" && neededAmount > 0 && player != null)
            {
                objectiveText.text += $"\nProgress: {player.GetItemCount(targetItem)}/{neededAmount}";
            }
        }
    }

    void Update()
    {
        // Constantly check progress if a quest is active
        if (player != null && targetItem != "None")
        {
            UpdateObjectiveUI();

            if (player.GetItemCount(targetItem) >= neededAmount)
            {
                objectiveDescription = "Items Collected! Talk to NPC.";
            }
        }
    }
}