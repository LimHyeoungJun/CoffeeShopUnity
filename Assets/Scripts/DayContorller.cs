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

    public int CurrentDay { get; set; } = 1;
    public int guestCount { get; set; } = 0;

    
}
