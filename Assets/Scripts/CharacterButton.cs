using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
    public CharacterData characterData; // Assign in Inspector
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        CharacterSelectManager.Instance.SelectCharacter(characterData);
    }
}
