using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance
    {
        get
        {
            if(m_instance == null)
            {
                m_instance = FindObjectOfType<UIManager>();
            }
            return m_instance;
        }
    }

    private static UIManager m_instance;

    public GameObject button1;
    public GameObject button2;

    public void button1On()
    {
        button1.SetActive(true);
        button2.SetActive(false);
    }
    public void button2On()
    {
        button1.SetActive(false);
        button2.SetActive(true);
    }

}
