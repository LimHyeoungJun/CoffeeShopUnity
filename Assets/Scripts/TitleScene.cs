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

    //betaCode
    public GameObject ReStartButton;

    private void Awake()
    {
        bgm.clip = bgmClip;
        bgm.volume = 0.5f;
        bgm.loop = true;
        bgm.Play();
        Screen.SetResolution(720, 1280, FullScreenMode.FullScreenWindow);
        //BetaCode������ִ� �����Ͱ� �ִٸ� ��ư ǥ�� ���ٸ� ��ư ����
        if(PlayerPrefs.HasKey("Day")|| PlayerPrefs.HasKey("Money"))
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
        Debug.Log("������ ����");
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
        // �ε� UI ���� Ȱ��ȭ
        // ��: loadingPanel.SetActive(true);
        Loading.gameObject.SetActive(true);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainGame");

        // �ε��� �Ϸ�� ������ ���
        while (!asyncLoad.isDone)
        {
            // ���⼭ �ε� UI�� ������Ʈ�� �� �ֽ��ϴ�.
            // ��: loadingBar.value = asyncLoad.progress;
            yield return null;
        }
    }
}
