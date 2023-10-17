using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanelController : MonoBehaviour
{
    public GameObject popupPanel; // 팝업 패널을 드래그 앤 드롭으로 연결

    public void OpenPopup()
    {
        popupPanel.SetActive(true); // 팝업 패널을 활성화
        SoundManager.instance.PlayClickButtonSound();
        Time.timeScale = 0f;
    }

    // 팝업 패널을 닫기 버튼으로 닫을 때 호출
    public void ClosePopup()
    {
        popupPanel.SetActive(false); // 팝업 패널을 비활성화
        Time.timeScale = 1f;
        SoundManager.instance.PlayClickButtonSound();

    }

}
