using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    public void OnClickStart()
    {
        SaveDataManager.instance.ReSetData();
        Debug.Log("������ ����");
        SceneManager.LoadScene("StartStory");
    }
    public void OnClickReStart()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void OnClickExit()
    {
        Application.Quit();
    }
}
