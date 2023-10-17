using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanelController : MonoBehaviour
{
    public GameObject popupPanel; // �˾� �г��� �巡�� �� ������� ����

    public void OpenPopup()
    {
        popupPanel.SetActive(true); // �˾� �г��� Ȱ��ȭ
        SoundManager.instance.PlayClickButtonSound();
        Time.timeScale = 0f;
    }

    // �˾� �г��� �ݱ� ��ư���� ���� �� ȣ��
    public void ClosePopup()
    {
        popupPanel.SetActive(false); // �˾� �г��� ��Ȱ��ȭ
        Time.timeScale = 1f;
        SoundManager.instance.PlayClickButtonSound();

    }

}
