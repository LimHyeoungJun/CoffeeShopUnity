using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NPC : LivingEntity
{
    private string menu;
    public GameObject startPoint;
    public GameObject endPoint;

    public float speed = 5f;
    private string description = null;
    private string NPCOder = null;
    private float timer;

    //TestCode
    private Dictionary<string,string> oder = new Dictionary<string,string>();

    private void Awake()
    {
        oder["espresso"] = "원액 ";
        oder["ice_espresso"] = "차가운 원액 ";
        oder["americano"] = "커피에 물탄거 ";
        oder["ice_americano"] = "커피에 얼음물 탄거 ";
    }

    private void Start()
    {
        StartCoroutine(MoveToEndPoint());
        GameManager.instance.IsGiveDrink = false;
    }
    private void Update()
    {

        if (GameManager.instance.IsGiveDrink)
        {
            string drink = GameManager.instance.Coffee;
            CheckDrink(drink);
        }
        timer += Time.deltaTime;
        if(timer > 30f)
        {
            if (GameManager.instance.StarPoint == null || GameManager.instance.StarPoint <= 0)
            {
                GameManager.instance.StarPoint = 0;
                Debug.Log(GameManager.instance.StarPoint);
            }
            else
            {
                GameManager.instance.StarPoint -= 1;
                Debug.Log(GameManager.instance.StarPoint);
            }
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
            if(GameManager.instance.StarPoint == null)
            {
                GameManager.instance.StarPoint = 0;
            }
            GameManager.instance.StarPoint += 1;
            Debug.Log(GameManager.instance.StarPoint);
            /////////////////////////
            GameManager.instance.IsGiveDrink = false;
        }
        else
        {
            //if (GameManager.instance.StarPoint == null || GameManager.instance.StarPoint <= 0)
            //{
            //    GameManager.instance.StarPoint = 0;
            //    Debug.Log(GameManager.instance.StarPoint);
            //}
            //else
            //{
                
                
            //    Debug.Log(GameManager.instance.StarPoint);
            //}

            GameManager.instance.StarPoint -= 1;
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
        SetDialogue(description);
    }
}
