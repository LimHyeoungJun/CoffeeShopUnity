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
    public bool IsDelete { get; set; }
    public string Coffee { get; set; }
    public string MadeInMeDrink {  get; set; }
    public bool IsGiveDrink {  get; set; }
    public int PlayerMoney { get; set; } = 10000;//플레이어 소지금
    public int MaxStarPoint { get; set; } = 5;
    public int StarPoint { get; set; }
    public bool OnCupCollider { get; set; }
    public bool IsCanCupSpawn { get; set; } = true;
    
    public SpawnCup cup;

    public void SpawnCup() 
    {
        cup.SpawnCoffee(Coffee);
        //Debug.Log(Coffee);
    }
    public void SetStartPoint()
    {
        StarPoint = MaxStarPoint;
    }
}
