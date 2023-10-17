using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CamMoveButton : MonoBehaviour
{
    public Button Cooking;
    public Button Odering;
    public CameraMove mainCam;
    private bool isShowMaterialButton = false;
    private bool BGM;
    private bool SS;

    private void Update()
    {
        if(isShowMaterialButton)
        {
            UIManager.instance.ActiveMaterialButton(true);
        }
        else if(!isShowMaterialButton)
        {
            UIManager.instance.ActiveMaterialButton(false);
        }
    }

    public void OnClickCook()
    {
        mainCam.CamMove2();
        UIManager.instance.button1On();
        if (DayContorller.instance.CurrentDay >= 4)
        {
            UIManager.instance.ActiveMaterialButton(true);
            isShowMaterialButton = true;
        }
        GameManager.instance.OnCupCollider = false;
    }
    public void OnClickOder()
    {
        mainCam.CamMove1();
        UIManager.instance.button2On();
        GameManager.instance.OnCupCollider = true;
        UIManager.instance.ActiveMaterialButton(false);
        isShowMaterialButton = false;
    }
    public void onClickComplit()
    {
        GameManager.instance.IsComplet = true;
    }
    public void onClickUperRight()
    {
        if (MaterialController.instance.UperCount >= MaterialController.instance.maxUperCount)
        {
            MaterialController.instance.UperCount = MaterialController.instance.minUperCount;
        }
        else
        {
            MaterialController.instance.UperCount += 1;
        }
    }

    public void onClickUperLeft()
    {
        if (MaterialController.instance.UperCount <= MaterialController.instance.minUperCount)
        {
            MaterialController.instance.UperCount = MaterialController.instance.maxUperCount;
        }
        else
        {
            MaterialController.instance.UperCount -= 1;
        }
    }

    public void onClickDelete()
    {
        Debug.Log("Delete");
        GameManager.instance.IsDelete = true;
    }

    public void onClickUnderRight()
    {
        if (MaterialController.instance.UnderCount >= MaterialController.instance.maxUnderCount)
        {
            MaterialController.instance.UnderCount = MaterialController.instance.minUnderCount;
        }
        else
        {
            MaterialController.instance.UnderCount += 1;
        }
    }

    public void onClickUnderLeft()
    {
        if (MaterialController.instance.UnderCount <= MaterialController.instance.minUnderCount)
        {
            MaterialController.instance.UnderCount = MaterialController.instance.maxUnderCount;
        }
        else
        {
            MaterialController.instance.UnderCount -= 1;
        }
    }
    public void onClickCheckBoardCloase()
    {
        UIManager.instance.CheckMenuBoard.SetActive(false);
        SoundManager.instance.PlayClickButtonSound();

    }

    public void OnClickOpenInfo()
    {
        UIManager.instance.TutoInfo.SetActive(true);
        SoundManager.instance.PlayClickButtonSound();
        Time.timeScale = 0f;
    }
    public void OnClickCloseInfo()
    {
        UIManager.instance.TutoInfo.SetActive(false);
        SoundManager.instance.PlayClickButtonSound();

        Time.timeScale = 1f;
    }
    public void BGM_ONOFF()
    {
        // 상태를 반전시킴
        BGM = !BGM;

        if (BGM)
        {
            SoundManager.instance.AudioSourceBGM.volume = 0f;
        }
        else
        {
            SoundManager.instance.AudioSourceBGM.volume = 1f;
        }
    }
    public void SoundEffectOnOff()
    {
        // 상태를 반전시킴
        SS = !SS;

        if (SS)
        {
            SoundManager.instance.AudioSource.volume = 0f;
            SoundManager.instance.AudioSourceTalk.volume = 0f;
            SoundManager.instance.AudioSourceSonNimInOut.volume = 0f;
        }
        else
        {
            SoundManager.instance.AudioSource.volume = 1f;
            SoundManager.instance.AudioSourceTalk.volume = 1f;
            SoundManager.instance.AudioSourceSonNimInOut.volume = 1f;
        }
    }
    public void GoToTitle()
    {
        SceneManager.LoadScene("TitleScenes");
        Time.timeScale = 1f;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
