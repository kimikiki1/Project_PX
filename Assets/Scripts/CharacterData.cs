using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character Data")]
public class CharacterData : ScriptableObject
{
    public int characterID;           // Unique ID
    public string characterName;      // Name
    public string description;        // Lore / info
    public Sprite portrait;           // Portrait image
    public GameObject characterPrefab; // Prefab for spawning
}
