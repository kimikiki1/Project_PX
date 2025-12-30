using UnityEngine;
using TMPro;
using System.Collections;

public class PickupFeedbackUI : MonoBehaviour
{
    public static PickupFeedbackUI instance;

    [SerializeField] private TMP_Text feedbackText;

    void Awake()
    {
        instance = this;
        feedbackText.gameObject.SetActive(false);
    }

    public void ShowMessage(string msg)
    {
        feedbackText.text = msg;
        feedbackText.gameObject.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(HideAfterTime());
    }

    IEnumerator HideAfterTime()
    {
        yield return new WaitForSeconds(2f);
        feedbackText.gameObject.SetActive(false);
    }
}
