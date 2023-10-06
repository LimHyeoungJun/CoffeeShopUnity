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
    public UnityEngine.UI.Text tx;
    public GameObject TextUI;

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

    public void StartTexting(string text)
    {
        TextUI.SetActive(true);
        StartCoroutine(Typing(text));
    }

    IEnumerator Typing(string text)
    {
        for (int i = 0; i < text.Length; i++) 
        {
            tx.text = text.Substring(0,i);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(3f);
        tx.text = null;
        TextUI.SetActive(false);
    }

}
