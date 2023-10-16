using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImageSwitcher : MonoBehaviour
{
    public Image[] images; // 4장의 이미지를 저장할 배열
    private int currentIndex = 0; // 현재 이미지의 인덱스

    private void Start()
    {
        // 초기 이미지만 활성화, 나머지 이미지 비활성화
        for (int i = 1; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(false);
        }

    }

    private void Update()
    {
        if(currentIndex == 4)
        {
            SceneManager.LoadScene("MainGame");
           
        }
        
    }

    public void OnImageClick()
    {
        Debug.Log("전환");
        // 현재 이미지를 비활성화
        images[currentIndex].gameObject.SetActive(false);

        // 다음 이미지로 전환
        currentIndex = (currentIndex + 1) % images.Length;

        // 다음 이미지를 활성화
        images[currentIndex].gameObject.SetActive(true);
       
    }
}
