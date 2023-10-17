using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SaveDataManager
{
    private static SaveDataManager m_instance;
    public static SaveDataManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = new SaveDataManager();
            }
            return m_instance;
        }
    }
    
    private SaveDataManager() 
    {
        //DayContorller.instance.CurrentDay = 1;
        //GameManager.instance.PlayerMoney = 10000;
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("Day", DayContorller.instance.CurrentDay);
        PlayerPrefs.SetInt("Money", GameManager.instance.PlayerMoney);
        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey("Day") && PlayerPrefs.HasKey("Money"))
        {
            DayContorller.instance.CurrentDay = PlayerPrefs.GetInt("Day");
            GameManager.instance.PlayerMoney = PlayerPrefs.GetInt("Money");
        }
        else
        {
            // 처음 시작하는 경우, 기본값을 할당하고 저장
            DayContorller.instance.CurrentDay = 1;
            GameManager.instance.PlayerMoney = 10000;
            SaveData();
        }

    }
    public void ReSetData()
    {
        //if (!PlayerPrefs.HasKey("Day") || !PlayerPrefs.HasKey("Money"))
        //{
        //    SetDefaultData();
        //    SaveData();
        //}
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Day", 5);
        PlayerPrefs.SetInt("Money", 10000);
        PlayerPrefs.Save();
        Debug.Log("ReSetData called");
    }
    private void SetDefaultData()
    {
        DayContorller.instance.CurrentDay = 1;
        GameManager.instance.PlayerMoney = 10000;
    }
}
