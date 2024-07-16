using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    
    public CanvasGroup canvasGroup;
    public Image backgroundImage;
    public RectTransform window;
    public float animationTime = 0.35f;
    public float backgroundAlpha = 0.5f;

    private UnityAction onClose;

    public void Show()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(window);
        StartCoroutine(PopupAnimation(true));
    }
    
    public void Hide()
    {
        StartCoroutine(PopupAnimation(false));
    }
    
    protected IEnumerator PopupAnimation(bool show)
    {
        if (show)
        {
            SetBackgroundAlpha(0f);
            window.localScale = Vector3.zero;
            canvasGroup.alpha = 1f;
        }
        canvasGroup.blocksRaycasts = false;
        for (float t = 0f; t < animationTime; t += Time.deltaTime)
        {
            float nt = t / animationTime;
            if (!show)
                nt = 1f - nt;
            float easeValue = EaseFunctions.OutBack(nt);
            window.localScale = Vector3.LerpUnclamped(Vector3.zero, Vector3.one, easeValue);
            SetBackgroundAlpha(Mathf.Lerp(0f, backgroundAlpha, nt));
            yield return null;
        }
        window.localScale = show ? Vector3.one : Vector3.zero;
        SetBackgroundAlpha(show ? backgroundAlpha : 0f);
        if (show)
            canvasGroup.blocksRaycasts = true;
        else
            canvasGroup.alpha = 0f;
    }

    private void SetBackgroundAlpha(float a)
    {
        Color c = backgroundImage.color;
        c.a = a;
        backgroundImage.color = c;
    }

    public void Clear()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.blocksRaycasts = false;
    }
    
}
