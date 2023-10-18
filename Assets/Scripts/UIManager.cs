using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public class CupInSideData
{
    [SerializeField]
    public Sprite CupInSideImage;
    [SerializeField]
    public string name;
}



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

    public TextMeshProUGUI minusMoney;
    public TextMeshProUGUI plusMoney;
    public TextMeshProUGUI D_Day;

    public Image sonnimIn;
    public Image SonnimOut;
    public GameObject TutoInfo;

    public List<CupInSideData> CupData = new List<CupInSideData>();
    public GameObject CupInSideWhat;
    public Image CupInMaterial1;
    public Image CupInMaterial2;
    public Image CupInMaterial3;
    public Image CupInMaterial4;

    private void Start()
    {
        obj.SetActive(false);
        DieImage.SetActive(false);
        minusMoney.enabled = false;
        plusMoney.enabled = false;
    }
    //private void Update()
    //{
    //    Day.text = DayContorller.instance.CurrentDay.ToString();
    //    thisDayMoney.text = GameManager.instance.ThisDayMoney.ToString();
    //    currentMaterialMoney.text = GameManager.instance.CurrentDayMaterialCost.ToString();
    //    MyMoney.text = GameManager.instance.PlayerMoney.ToString();

    //}
    public void SetUpInfo()
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
            SoundManager.instance.PlayTalkingNPC();
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
    public void DayUpDate(int day)
    {

        D_Day.text = day.ToString();
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
        //yield return new WaitForSecondsRealtime(2f); // 1초 동안 화면을 유지합니다. 조정 가능
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        DayContorller.instance.CurrentDay += 1;
        SaveDataManager.instance.SaveData();
        SetUpInfo();
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
    public void AddMoney(int money)
    {
        var m = money.ToString();
       StartCoroutine(AM(m));
    }
    IEnumerator AM(string m)
    {
        plusMoney.text = "+" + m;
        plusMoney.enabled = true;
        for (float i = 1; i >= 0; i -= Time.deltaTime * 0.5f)
        {
            plusMoney.color = new Color(0, 255, 0, i);
            yield return null;
        }
        plusMoney.enabled = false;
    }
    public void AddMinusMoney(int money)
    {
        var m = money.ToString();
        StartCoroutine(AMM(m));
    }
    IEnumerator AMM(string m)
    {
        plusMoney.text = "-" + m;
        plusMoney.enabled = true;
        for (float i = 1; i >= 0; i -= Time.deltaTime * 0.5f)
        {
            plusMoney.color = new Color(255, 0, 0, i);
            yield return null;
        }
        plusMoney.enabled = false;
    }
    public void MinusMoney(int money) 
    {
        var m = money.ToString();
        StartCoroutine(MM(m));
    }
    IEnumerator MM(string m) 
    {
        minusMoney.text = "-" + m;
        minusMoney.enabled = true;
        for (float i = 1; i >= 0; i -= Time.deltaTime * 0.5f)
        {
            minusMoney.color = new Color(255, 0, 0, i);
            yield return null;
        }
        minusMoney.enabled = false;
    }
    public void SonNimIn()
    {
        StartCoroutine(IN());
    }
    IEnumerator IN()
    {
        sonnimIn.gameObject.SetActive(true);
        for (float i = 1; i >= 0; i -= Time.deltaTime * 0.5f)
        {
            sonnimIn.color = new Color(255, 255, 255, i);
            yield return null;
        }
        sonnimIn.gameObject.SetActive(false);
    }
    public void SonNimOut()
    {
        StartCoroutine (OUT());
    }
    IEnumerator OUT()
    {
        SonnimOut.gameObject.SetActive(true);
        for (float i = 1; i >= 0; i -= Time.deltaTime * 0.5f)
        {
            SonnimOut.color = new Color(255, 255, 255, i);
            yield return null;
        }
        SonnimOut.gameObject.SetActive(false);
    }

    public void DeleteCupInSideMaterial()
    {
        CupInMaterial1.sprite = null;
        CupInMaterial1.color = new Color(255, 255, 255, 0);

        CupInMaterial2.sprite = null;
        CupInMaterial2.color = new Color(255, 255, 255, 0);

        CupInMaterial3.sprite = null;
        CupInMaterial3.color = new Color(255, 255, 255, 0);

        CupInMaterial4.sprite = null;
        CupInMaterial4.color = new Color(255, 255, 255, 0);

    }

    public void SetCupInSideMaterial(int num, string name)
    {
        switch(num)
        {
            case 1:
                foreach(var c in CupData)
                {
                    if(c.name == name)
                    {
                        CupInMaterial1.sprite = c.CupInSideImage;
                        CupInMaterial1.color = new Color(255, 255, 255, 255);
                        break;
                    }
                }
                break;
            case 2:
                foreach (var c in CupData)
                {
                    if (c.name == name)
                    {
                        CupInMaterial2.sprite = c.CupInSideImage;
                        CupInMaterial2.color = new Color(255, 255, 255, 255);
                        break;
                    }
                }
                break;
            case 3:
                foreach (var c in CupData)
                {
                    if (c.name == name)
                    {
                        CupInMaterial3.sprite = c.CupInSideImage;
                        CupInMaterial3.color = new Color(255, 255, 255, 255);
                        break;
                    }
                }
                break;
            case 4:
                foreach (var c in CupData)
                {
                    if (c.name == name)
                    {
                        CupInMaterial4.sprite = c.CupInSideImage;
                        CupInMaterial4.color = new Color(255, 255, 255, 255);
                        break;
                    }
                }
                break;
            default:
                break;
        }


    }

}


