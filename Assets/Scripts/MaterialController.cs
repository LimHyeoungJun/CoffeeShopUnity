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