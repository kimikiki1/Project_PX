using UnityEngine;
using TMPro;
using System.Collections;

public class PickupFeedback : MonoBehaviour
{
    public static PickupFeedback instance;

    public TMP_Text feedbackText;

    private void Awake()
    {
        instance = this;
        feedbackText.gameObject.SetActive(false);
    }

    public void Show(string message)
    {
        feedbackText.text = message;
        feedbackText.gameObject.SetActive(true);

        StopAllCoroutines();
        StartCoroutine(HideAfterTime());
    }

    IEnumerator HideAfterTime()
    {
        yield return new WaitForSeconds(1f);
        feedbackText.gameObject.SetActive(false);
    }
}
