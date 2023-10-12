using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public GameObject DeleteButton;
    public UnityEngine.UI.Text tx;
    public GameObject TextUI;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI MoneyText;

    public Image fadeImage; 
    private bool canRestart = false;
    public GameObject obj;

    public GameObject UnderRightButton;
    public GameObject UnderLeftButton;
    public GameObject UperRightButton;
    public GameObject UperLeftButton;

    public GameObject CheckMenuBoard;
    public Text MenuName;
    public Text Material1;
    public Text Material2;
    public Text Material3;
    public Text Material4;
    


    private void Start()
    {
        obj.SetActive(false);
    }
    private void Update()
    {
        if (canRestart && Input.GetMouseButtonDown(0)) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 현재 씬을 다시 로드
            obj.SetActive(false);
        }
    }

    public void button1On()
    {
        mainbutton.SetActive(true);
        firstscreenButton.SetActive(false);
        complitButton.SetActive(true);
        DeleteButton.SetActive(true);
    }
    public void button2On()
    {
        mainbutton.SetActive(false);
        firstscreenButton.SetActive(true);
        complitButton.SetActive(false);
        DeleteButton.SetActive(false);
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

    public void TimerUpdate(float time)
    {
        uint 얘는이름뭐로하지 = (uint)time;
        TimerText.text = $"00:{얘는이름뭐로하지}";
    }
    public void MoneyUpdate(int money)
    {
        MoneyText.text = $"$:{money}";
    }

    public void Ending()
    {
        StartCoroutine(FadeInOut());
        obj.SetActive(true);
    }

    IEnumerator FadeInOut()
    {
        // 페이드 인
        for (float i = 0; i <= 1; i += Time.deltaTime * 0.5f) // 0.5f는 페이드 속도입니다. 조정 가능
        {
            //fadeImage.color = new Color(0, 0, 0, i);
            fadeImage.color = new Color(255, 255, 255, i);
            yield return null;
        }
        canRestart = true;


    }
    public void ActiveMaterialButton(bool active)
    {
        UnderRightButton.SetActive(active);
        UnderLeftButton.SetActive(active);
        UperRightButton.SetActive(active);
        UperLeftButton.SetActive(active);
    }
    public void SetCheackBoardMenu(string menu, string material1 = " ",string material2 = " ", string material3 = " ", string material4 =" ")
    {
        MenuName.text = menu;
        Material1.text = material1;
        Material2.text = material2;
        Material3.text = material3;
        Material4.text = material4;
    }
  
}


