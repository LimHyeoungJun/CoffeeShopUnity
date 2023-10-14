using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*

public class ImageTranstition : MonoBehaviour
{
 public Image initialImage;     // 처음 이미지
    public Image replacementImage; // 교체될 이미지
    public float delayTime = 2.0f; // 2초 후에 교체
    private bool hasTransitioned = false;

    void Start()
    {
        replacementImage.enabled = false; // 처음에는 교체될 이미지를 비활성화

        // delayTime (2초) 후에 Transition 함수 실행
        Invoke("Transition", delayTime);
    }

    void Transition()
    {
        if (!hasTransitioned)
        {
            initialImage.CrossFadeAlpha(0, 1, false); // 처음 이미지를 1초 동안 투명하게 만듭니다.
            replacementImage.enabled = true;          // 교체될 이미지 활성화
            hasTransitioned = true;                  // 이미 한 번 교체했음을 표시
        }
    }
}

*/
