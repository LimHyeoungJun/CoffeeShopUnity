using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScene : MonoBehaviour
{
    public AudioSource ss;
    public AudioClip clip;
    public Image Loading;
    public AudioSource bgm;
    public AudioClip bgmClip;

    public GameObject Credit;

    //betaCode
    public GameObject ReStartButton;

    private void Awake()
    {
        bgm.clip = bgmClip;
        bgm.volume = 0.5f;
        bgm.loop = true;
        bgm.Play();
        //Screen.SetResolution(720, 1280, FullScreenMode.FullScreenWindow);
        //BetaCode저장되있는 데이터가 있다면 버튼 표기 없다면 버튼 숨김
        if (PlayerPrefs.HasKey("Day") || PlayerPrefs.HasKey("Money"))
        {
            ReStartButton.SetActive(true);
        }
        else
        {
            ReStartButton.SetActive(false);
        }
    }
    public void OnClickStart()
    {
        SaveDataManager.instance.ReSetData();
        Debug.Log("데이터 삭제");
        playSound();
        SceneManager.LoadScene("StartStory");
    }
    public void OnClickReStart()
    {
        playSound();
        //SceneManager.LoadScene("MainGame");
        StartCoroutine(LoadYourAsyncScene());
    }
    public void OnClickExit()
    {
        playSound();
        Application.Quit();
    }
    private void playSound()
    {
        ss.clip = clip;
        ss.Play();
    }
    private IEnumerator LoadYourAsyncScene()
    {
        // 로딩 UI 등을 활성화
        // 예: loadingPanel.SetActive(true);
        Loading.gameObject.SetActive(true);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainGame");


        while (!asyncLoad.isDone)
        {

            yield return null;
        }
    }
    public void OnClickOpenCredit()
    {
        Credit.gameObject.SetActive(true);
    }
    public void OnClickCloseCredit()
    {
        Credit.gameObject.SetActive(false);
    }
}
