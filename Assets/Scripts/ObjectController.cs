using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public static ObjectController instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<ObjectController>();
            }
            return m_instance;
        }
    }
    private static ObjectController m_instance;

    public GameObject[] Cup = new GameObject[1];





}
