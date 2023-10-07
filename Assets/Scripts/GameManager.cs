using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
            }
            return m_instance;
        }
    }

    private static GameManager m_instance;

    public bool IsComplet { get; set; }
    public string Coffee { get; set; }
    public string MadeInMeDrink {  get; set; }
    public bool IsGiveDrink {  get; set; }
    public int PlayerMoney { get; set; } = 10000;//�÷��̾� ������
    public int StarPoint { get; set; } = 0;//���� ���� �ڼ��� ������ ����
    public bool OnCupCollider { get; set; }

    //TestCode
    public int guestCount { get; set; } = 0;
   

    public SpawnCup cup;


    public void SpawnCup() 
    {
        cup.SpawnCoffee(Coffee);
        Debug.Log(Coffee);
    }
}
