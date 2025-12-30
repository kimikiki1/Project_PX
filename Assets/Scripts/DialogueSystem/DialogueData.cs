using UnityEngine;

[CreateAssetMenu(fileName = "NewConversation", menuName = "Dialogue/Conversation")]
public class DialogueData : ScriptableObject
{
    public DialogueLine[] conversation;

    [Header("Quest Trigger (Optional)")]
    public bool givesQuest;
    public string questItemName;
    public int questAmount;
    public string questDescription;
}