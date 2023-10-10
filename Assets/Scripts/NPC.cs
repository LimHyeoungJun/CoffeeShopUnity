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
    private string NPCOder = null;//주문메뉴
    private string NPCLine = null;//주문 대사
    private float timer = 0;//기다림의 시간
    private int cost = 0;//가격
    private int number = 0;//수량
    private int drinkcount = 0;

    //TestCode
    private Dictionary<string,List<Data>> oder = new Dictionary<string, List<Data>>();

    private void Awake()
    {
        oder["espresso"] = new List<Data>() { new Data("에스프레소 ", 1500) };
        oder["ice_espresso"] = new List<Data>() { new Data("차가운 에스프레소 ", 1500) };
        oder["americano"] = new List<Data>() { new Data("아메리카노 ", 1500) };
        oder["ice_americano"] = new List<Data>() { new Data("아이스 아메리카노 ", 2000) };
       
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
            GameManager.instance.IsGiveDrink = false;
        }
        timer -= Time.deltaTime;
        UIManager.instance.TimerUpdate(timer);
        if(timer < 0)
        {
            Debug.Log("손님 삐져서 나감");
            OnFlase();
            StartCoroutine(TestCode());
        }

        if(drinkcount >= number)//여러개 주문받는거 염두해 두고 만들었음
        {
            OnComplet();
        }
        
    }
    private void CheckDrink(string drink)
    {
        if(NPCOder.Equals(drink))
        {
            Debug.Log(drink + "제대로 완성");
            /////////////////////////

            ++drinkcount;

            //주문받음 음료가 제대로 나오면 할 행동
            DayContorller.instance.guestCount += 1;
            Debug.Log(DayContorller.instance.guestCount);

            //int mon = GameManager.instance.PlayerMoney += description[description.Count - 1].price;
            //UIManager.instance.MoneyUpdate(mon);

            UIManager.instance.MoneyUpdate(GameManager.instance.PlayerMoney += cost);
            /////////////////////////
            GameManager.instance.IsGiveDrink = false;
        }
        else if(!NPCOder.Equals(drink))
        {
          
            Debug.Log("EZ");
            GameManager.instance.StarPoint -= 1;
            //OnFlase();
            //StartCoroutine(TestCode());
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

    public void Setup(string menu, GameObject start,GameObject end, string line,float time,int cost,int num)
    {
        //this.menu = menu;
        NPCOder = menu;
        NPCLine = line;
        timer = time;
        this.cost = cost;
        number = num;
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
        SetDialogue(NPCLine + " ");
    }
}
