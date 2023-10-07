using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Data
{
    public string str;
    public int price;

    public Data(string str, int price)  // 생성자 추가
    {
        this.str = str;
        this.price = price;
    }
}

public class NPC : LivingEntity
{
    private string menu;
    public GameObject startPoint;
    public GameObject endPoint;

    public float speed = 5f;
    private List<Data> description = null;
    private string NPCOder = null;
    private float timer = 30f;

    //TestCode
    private Dictionary<string,List<Data>> oder = new Dictionary<string, List<Data>>();

    private void Awake()
    {
        oder["espresso"] = new List<Data>() { new Data("원액 ", 1500) };
        oder["ice_espresso"] = new List<Data>() { new Data("차가운 원액 ", 1500) };
        oder["americano"] = new List<Data>() { new Data("커피에 물탄거 ", 1500) };
        oder["ice_americano"] = new List<Data>() { new Data("커피에 얼음물 탄거 ", 2000) };
        DayContorller.instance.guestCount += 1;
        Debug.Log(DayContorller.instance.guestCount);
    }

    private void Start()
    {
        StartCoroutine(MoveToEndPoint());
        GameManager.instance.IsGiveDrink = false;
        UIManager.instance.MoneyUpdate(GameManager.instance.PlayerMoney);
    }
    private void Update()
    {

        if (GameManager.instance.IsGiveDrink)
        {
            string drink = GameManager.instance.Coffee;
            CheckDrink(drink);
        }
        timer -= Time.deltaTime;
        UIManager.instance.TimerUpdate(timer);
        if(timer < 0)
        {
            Debug.Log("손님 삐져서 나감");
            OnFlase();
            StartCoroutine(TestCode());
        }

    }
    private void CheckDrink(string drink)
    {
        if(NPCOder.Equals(drink))
        {
            Debug.Log(drink + "제대로 완성");
            /////////////////////////
            OnComplet();

            //주문받음 음료가 제대로 나오면 할 행동

            int mon = GameManager.instance.PlayerMoney += description[description.Count - 1].price;
            UIManager.instance.MoneyUpdate(mon);
            
           
            /////////////////////////
            GameManager.instance.IsGiveDrink = false;
        }
        else
        {
          
            Debug.Log("EZ");
            OnFlase();
            StartCoroutine(TestCode());
        }
    }
    IEnumerator TestCode()
    {
        while (true) 
        {
            gameObject.transform.position += new Vector3(0,0.1f,0);
            yield return null;
        }
    }
    public void Setup(string menu, GameObject start,GameObject end)
    {
        //this.menu = menu;
        NPCOder = menu;
        if (oder.ContainsKey(menu))
        {
            oder.TryGetValue(menu, out description);
        }
        this.startPoint = start;
        this.endPoint = end;
    }
    public void SetDialogue(string dialogue)
    {
        UIManager.instance.StartTexting(dialogue);
        Debug.Log(dialogue);
    }
    public override void OnComplet()
    {
        base.OnComplet();
    }
    public override void OnFlase()
    {
        base.OnFlase();
    }
    IEnumerator MoveToEndPoint()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = endPoint.transform.position;
        float journeyLength = Vector3.Distance(startPos, endPos);
        float startTime = Time.time;

        float distanceCovered = 0;
        float fractionOfJourney = 0;

        while (fractionOfJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * speed;
            fractionOfJourney = distanceCovered / journeyLength;

            transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);
            yield return null;
        }

        Debug.Log("도착했습니다.");
        SetDialogue(description[0].str);
    }
}
