using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSwipe : MonoBehaviour
{
    private Vector3 StartMousePosition;
    private Vector3 EndMousePosition;


    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            StartMousePosition = Input.mousePosition;
        }
        if(Input.GetMouseButtonUp(0)) 
        {
            EndMousePosition = Input.mousePosition;
            Swipe();
        }
    }
    private void Swipe()
    {
        Vector3 direction = EndMousePosition - StartMousePosition;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {

                // �������� �� �ѱ��
                Debug.Log("Flip page to the left");
            }
            else
            {
                
                // ���������� �� �ѱ��
                Debug.Log("Flip page to the right");
            }
        }
    }
}
