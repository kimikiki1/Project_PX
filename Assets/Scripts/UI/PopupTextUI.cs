using UnityEngine;
using TMPro;

public class PopupTextUI : MonoBehaviour
{
    public static PopupTextUI instance;

    public TextMeshProUGUI popupPrefab;

    private void Awake()
    {
        instance = this;
    }

    public void ShowPopup(Vector3 worldPos, string text)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);

        var popup = Instantiate(popupPrefab, transform);
        popup.text = text;
        popup.transform.position = screenPos;

        Destroy(popup.gameObject, 1.0f);
    }
}
    