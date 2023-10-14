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

    public TextMeshProUGUI Day;
    public TextMeshProUGUI thisDayMoney;
    public TextMeshProUGUI currentMaterialMoney;
    public TextMeshProUGUI MyMoney;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject star4;
    public GameObject star5;

    public GameObject DieImage;
    public TextMeshProUGUI DieText;

    public CamMoveButton mainCam;

    private void Start()
    {
        obj.SetActive(false);
        DieImage.SetActive(false);
    }
    private void Update()
    {
        Day.text = DayContorller.instance.CurrentDay.ToString();
        thisDayMoney.text = GameManager.instance.ThisDayMoney.ToString();
        currentMaterialMoney.text = GameManager.instance.CurrentDayMaterialCost.ToString();
        MyMoney.text = GameManager.instance.PlayerMoney.ToString();

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
        uint thistime = (uint)time;
        TimerText.text = $"{thistime}";
    }
    public void MoneyUpdate(int money)
    {
        MoneyText.text = $"{money}";
    }

    public void Ending()
    {
       
        StartCoroutine(FadeInOut());
        
    }

    IEnumerator FadeInOut()
    {
        // 페이드 인
        GameManager.instance.PlayerMoney -= 10000;
        obj.SetActive(true);
        //GameManager.instance.PlayerMoney -= GameManager.instance.CurrentDayMaterialCost;
        for (float i = 0; i <= 1; i += Time.deltaTime * 0.5f) // 0.5f는 페이드 속도입니다. 조정 가능
        {
            //fadeImage.color = new Color(0, 0, 0, i);
            fadeImage.color = new Color(255, 255, 255, i);
            yield return null;
        }
        yield return new WaitForSecondsRealtime(2f); // 1초 동안 화면을 유지합니다. 조정 가능

        // 페이드 아웃
        for (float i = 1; i >= 0; i -= Time.deltaTime * 0.5f) // 0.5f는 페이드 속도입니다. 조정 가능
        {
            fadeImage.color = new Color(255, 255, 255, i);
            yield return null;
        }
        obj.SetActive(false);
        GameManager.instance.IsTimeToGo = true;
        
        GameManager.instance.ThisDayMoney = 0;
        GameManager.instance.CurrentDayMaterialCost = 0;
        mainCam.OnClickOder();
        //canRestart = true;
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
    public void StarSetUp()
    {
        switch(GameManager.instance.StarPoint)
        {
            case 0:
                star1.SetActive(false);
                break;
            case 1:
                star2.SetActive(false);
                break;
            case 2:
                star3.SetActive(false);
                break;
            case 3:
                star4.SetActive(false);
                break;
            case 4:
                star5.SetActive(false);
                break;
            case 5:
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
                star4.SetActive(true);
                star5.SetActive(true);
                break;
        }
    }
    
    public void Die()
    {
        StartCoroutine(DieFade());
    }
  
    IEnumerator DieFade()
    {
        DieImage.SetActive(true);
        for (float i = 0; i <= 1; i += Time.deltaTime * 0.5f)
        {
            DieText.color = new Color(255, 0, 0, i);
            yield return null;
        }
        yield return new WaitForSecondsRealtime(2f);
        DieImage.SetActive(false);
        GameManager.instance.IsTimeToGo = true;
        GameManager.instance.StarPoint = GameManager.instance.MaxStarPoint;
        StarSetUp();
        MoneyUpdate(GameManager.instance.PlayerMoney = GameManager.instance.SaveingMoney);
        mainCam.OnClickOder();
    }
}


