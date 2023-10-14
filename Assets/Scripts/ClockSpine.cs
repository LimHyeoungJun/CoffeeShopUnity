using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ClockSpine : MonoBehaviour
{

    public float speed = 4f;
    private float timer;
    public GameObject Clock;
    private Vector3 rot;
    private Quaternion startRot;
    private void Start()
    {
        startRot = Clock.transform.rotation;
    }


    void Update()
    {
        int sum = GameManager.instance.PlayerMoney;
        if (timer >= 90f && sum - 10000 > 0) //255f
        {
            GameManager.instance.IsTimeToGo = false;
            Clock.transform.rotation = startRot;
            UIManager.instance.Ending();
            DayContorller.instance.CurrentDay += 1;
            GameManager.instance.SaveingMoney = GameManager.instance.PlayerMoney;
            timer = 0;

        }
        else if(timer >= 90f && sum - 10000 <= 0)
        {
            GameManager.instance.IsTimeToGo = false;
            UIManager.instance.Die();
            Clock.transform.rotation = startRot;
            timer = 0;
        }
        if(GameManager.instance.TimerDead)
        {
            DieSoTimeStop();
        }
        if(GameManager.instance.StarPoint == 0 || GameManager.instance.PlayerMoney <= 0)
        {
            GameManager.instance.IsTimeToGo = false;
            UIManager.instance.Die();
            Clock.transform.rotation = startRot;
            timer = 0;
        }
        if(GameManager.instance.IsTimeToGo)
        {
            timer += Time.deltaTime;
            //Debug.Log(timer);
            rot = new Vector3(0f, (speed * Time.deltaTime), 0f);
            Clock.transform.Rotate(rot);
        }
        
    }
    public void DieSoTimeStop()
    {
        GameManager.instance.IsTimeToGo = false;
        UIManager.instance.Die();
        Clock.transform.rotation = startRot;
        timer = 0;
        GameManager.instance.TimerDead = false;
    }
}
