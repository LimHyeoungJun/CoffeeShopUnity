using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MaterialData
{
    public GameObject materialObject;
    public int activeDay;
}

public class MaterialController : MonoBehaviour
{
    public static MaterialController instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<MaterialController>();
            }
            return m_instance;
        }
    }

    private static MaterialController m_instance;


    public List<MaterialData> materials;

    public GameObject Under;
    public GameObject Under2;
    public GameObject Under3;

    public GameObject Uper;
    public GameObject Uper2;
    public GameObject Uper3;
    public GameObject Uper4;

    public int UperCount { get; set; } = 1;
    public int maxUperCount { get; set; }
    public int UnderCount { get; set; } = 1;
    public int maxUnderCount { get; set; }

    private void Update()
    {


        switch(UperCount)
        {
            case 1:
                Uper.SetActive(true);
                Uper2.SetActive(false);
                Uper3.SetActive(false);
                Uper4.SetActive(false);
                break;
            case 2:
                Uper.SetActive(false);
                Uper2.SetActive(true);
                Uper3.SetActive(false);
                Uper4.SetActive(false);
                break;
            case 3:
                Uper.SetActive(false);
                Uper2.SetActive(false);
                Uper3.SetActive(true);
                Uper4.SetActive(false);
                break;
            case 4:
                Uper.SetActive(false);
                Uper2.SetActive(false);
                Uper3.SetActive(false);
                Uper4.SetActive(true);
                break;
        }
        switch (UnderCount)
        {
            case 1:
                Under.SetActive(true);
                Under2.SetActive(false);
                Under3.SetActive(false);
                break;
            case 2:
                Under.SetActive(false);
                Under2.SetActive(true);
                Under3.SetActive(false);
                break;
            case 3:
                Under.SetActive(false);
                Under2.SetActive(false);
                Under3.SetActive(true);
                break;
        }

    }

    public void MaterialSetUp()
    {
        int currentDay = DayContorller.instance.CurrentDay;

        foreach (var material in materials)
        {
            if (currentDay >= material.activeDay)
            {
                material.materialObject.SetActive(true);
            }
            else
            {
                material.materialObject.SetActive(false);
            }
        }
    }



}