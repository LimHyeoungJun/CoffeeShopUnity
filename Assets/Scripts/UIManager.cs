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

    public GameObject mainbutton;
    public GameObject firstscreenButton;
    public GameObject complitButton;

    public void button1On()
    {
        mainbutton.SetActive(true);
        firstscreenButton.SetActive(false);
        complitButton.SetActive(true);
    }
    public void button2On()
    {
        mainbutton.SetActive(false);
        firstscreenButton.SetActive(true);
        complitButton.SetActive(false);
    }

}
