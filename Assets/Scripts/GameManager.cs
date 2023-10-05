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

    public bool isCom = false;
    public bool IsCom { get; set; }
    public string Coffee { get; set; }

    public SpawnCup cup;

    public void SpawnCup() 
    {
        cup.SpawnCoffee(Coffee);
    }
}
