using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImageSwitcher : MonoBehaviour
{
    public Image[] images; // 4장의 이미지를 저장할 배열
    private int currentIndex = 0; // 현재 이미지의 인덱스
    public Image Loading;

    public AudioSource bgm;
    public AudioClip bgmClip;

    private void Start()
    {
        // 초기 이미지만 활성화, 나머지 이미지 비활성화
        for (int i = 1; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(false);
        }
        bgm.clip = bgmClip;
        bgm.volume = 0.5f;
        bgm.loop = true;
        bgm.Play();
        //Screen.SetResolution(720, 1280, FullScreenMode.FullScreenWindow);

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
        if (currentIndex == 4)
        {
            StartCoroutine(LoadYourAsyncScene());
        }
    }

    private IEnumerator LoadYourAsyncScene()
    {
        // 로딩 UI 등을 활성화
        // 예: loadingPanel.SetActive(true);
        Loading.gameObject.SetActive(true);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainGame");

        // 로딩이 완료될 때까지 대기
        while (!asyncLoad.isDone)
        {
            // 여기서 로딩 UI를 업데이트할 수 있습니다.
            // 예: loadingBar.value = asyncLoad.progress;
            yield return null;
        }
    }
}
