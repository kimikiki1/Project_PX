using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string characterName;      // The name displayed in the UI
    public Sprite characterPortrait;  // The A4 portrait for this specific speaker
    [TextArea(3, 10)]
    public string text;               // The actual dialogue text
}