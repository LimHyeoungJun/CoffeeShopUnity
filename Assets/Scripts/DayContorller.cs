using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayContorller : MonoBehaviour
{

    public static DayContorller instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<DayContorller>();
            }
            return m_instance;
        }
    }

    private static DayContorller m_instance;

    public int guestCount { get; set; } = 0;

    void Update()
    {
        if(guestCount > 4) 
        {
            //여기 페이드인아웃UI
            UIManager.instance.Ending();
        }

    }
}
