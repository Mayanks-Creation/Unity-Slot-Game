using UnityEngine;
using System.Collections;

public class ReelController : MonoBehaviour
{
    public float speed = 2000f;
    public bool isSpinning = false;

    private RectTransform rectTransform;
    private float symbolHeight = 100f; // match your symbol size

    private Coroutine stopRoutine;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (isSpinning)
        {
            Spin();
        }
    }

    void Spin()
    {
        rectTransform.anchoredPosition -= new Vector2(0, speed * Time.deltaTime);

        if (rectTransform.anchoredPosition.y <= -symbolHeight)
        {
            rectTransform.anchoredPosition += new Vector2(0, symbolHeight);

            Transform first = transform.GetChild(0);
            first.SetAsLastSibling();
        }
    }

    public void StartSpin()
    {
        isSpinning = true;
    }

    public void StopSpin()
    {
        isSpinning = false;

        if (stopRoutine != null)
            StopCoroutine(stopRoutine);

        stopRoutine = StartCoroutine(SnapToGrid());
    }

    IEnumerator SnapToGrid()
    {
        float currentY = rectTransform.anchoredPosition.y;
        float targetY = Mathf.Round(currentY / symbolHeight) * symbolHeight;

        float duration = 0.2f;
        float time = 0f;

        Vector2 startPos = rectTransform.anchoredPosition;
        Vector2 endPos = new Vector2(startPos.x, targetY);

        while (time < duration)
        {
            time += Time.deltaTime;
            rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, time / duration);
            yield return null;
        }

        rectTransform.anchoredPosition = endPos;
    }
}