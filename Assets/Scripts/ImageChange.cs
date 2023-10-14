using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImageChange : MonoBehaviour
{
    public CanvasGroup initialImageCanvasGroup; // 초기 이미지의 CanvasGroup
    public CanvasGroup replacementImageCanvasGroup; // 교체될 이미지의 CanvasGroup
    public float fadeDuration = 1.5f; // 페이드 인 및 아웃 지속 시간

    private float timer;
    private bool isFadingOut;
    private bool isFadingIn;

    void Start()
    {
        // 초기 이미지 보이게 설정
        initialImageCanvasGroup.alpha = 1;
        replacementImageCanvasGroup.alpha = 0;

        // 1.5초 후에 페이드 아웃과 페이드 인 시작
        Invoke("StartFadeOutAndIn", 4.0f);
    }

    void Update()
    {
        if (isFadingOut)
        {
            timer += Time.deltaTime;
            float alpha = 1 - (timer / fadeDuration);
            initialImageCanvasGroup.alpha = Mathf.Clamp01(alpha);

            if (timer >= fadeDuration)
            {
                isFadingOut = false;
                initialImageCanvasGroup.alpha = 0;
            }
        }

        if (isFadingIn)
        {
            timer += Time.deltaTime;
            float alpha = timer / fadeDuration;
            replacementImageCanvasGroup.alpha = Mathf.Clamp01(alpha);

            if (timer >= fadeDuration)
            {
                isFadingIn = false;
                replacementImageCanvasGroup.alpha = 1;
            }
        }
    }

    void StartFadeOutAndIn()
    {
        isFadingOut = true;
        isFadingIn = true;
        timer = 0;
    }
}
