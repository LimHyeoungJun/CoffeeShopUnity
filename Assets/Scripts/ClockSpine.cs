using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ClockSpine : MonoBehaviour
{
    public float speed = 0.6f;
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
        if(timer >= 15f) //255f
        {
            GameManager.instance.IsTimeToGo = false;
            Clock.transform.rotation = startRot;
            UIManager.instance.Ending();
            DayContorller.instance.CurrentDay += 1;
            GameManager.instance.SaveingMoney = GameManager.instance.PlayerMoney;
            timer = 0;

        }
        if(GameManager.instance.StarPoint == 0)
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
}
