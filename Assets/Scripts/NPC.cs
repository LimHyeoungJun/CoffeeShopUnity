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

    //TestCode
    private Dictionary<string,string> oder = new Dictionary<string,string>();

    private void Awake()
    {
        oder["espresso"] = "���� ";
        oder["ice_espresso"] = "������ ���� ";
        oder["americano"] = "Ŀ�ǿ� ��ź�� ";
        oder["ice_americano"] = "Ŀ�ǿ� ������ ź�� ";
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

    }
    private void CheckDrink(string drink)
    {
        if(NPCOder.Equals(drink))
        {
            Debug.Log(drink + "����� �ϼ�");
            /////////////////////////
            OnComplet();

            //�ֹ����� ���ᰡ ����� ������ �� �ൿ


            /////////////////////////
            GameManager.instance.IsGiveDrink = false;
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

        Debug.Log("�����߽��ϴ�.");
        SetDialogue(description);
    }
}
