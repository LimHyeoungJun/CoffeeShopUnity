using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public GameObject cam1pos;
    public GameObject cam2pos;
    private Vector3 StartMousePosition;
    private Vector3 EndMousePosition;
    public float minSwipeDistance = 500f;
    float maxAngle = 30f;

    private void Awake()
    {
        gameObject.GetComponent<CameraMove>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartMousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            EndMousePosition = Input.mousePosition;
            Swipe();
        }
        if (GameManager.instance.MaterialButtonShow)
        {
            UIManager.instance.ActiveMaterialButton(true);
        }
        else if (GameManager.instance.MaterialButtonShow)
        {
            UIManager.instance.ActiveMaterialButton(false);
        }
    }
    private void Swipe()
    {
        Vector3 direction = EndMousePosition - StartMousePosition;

        if (direction.magnitude < minSwipeDistance)
        {
            return;
        }
        float angleHorizontal = Mathf.Abs(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        float angleVertical = Mathf.Abs(Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg);
        if (angleHorizontal > maxAngle && angleHorizontal < 90f - maxAngle)
        {
            return;
        }
        if (angleVertical > maxAngle && angleVertical < 90f - maxAngle)
        {
            return;
        }

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                GameManager.instance.OnCupCollider = true;
                CamMove1();
                Debug.Log("left");
            }
            else
            {
                GameManager.instance.OnCupCollider = false;
                CamMove2();
                Debug.Log("right");
            }
        }
    }
   

    public void CamMove1()
    {
        gameObject.transform.position = cam1pos.transform.position;
        gameObject.transform.rotation = cam1pos.transform.rotation;
        UIManager.instance.button2On();
        GameManager.instance.OnCupCollider = true;
        UIManager.instance.ActiveMaterialButton(false);
        GameManager.instance.MaterialButtonShow = false;
        UIManager.instance.CupInSideWhat.SetActive(false);
    }

    public void CamMove2()
    {
        gameObject.transform.position = cam2pos.transform.position;
        gameObject.transform.rotation = cam2pos.transform.rotation;
        UIManager.instance.button1On();
        if (DayContorller.instance.CurrentDay >= 4)
        {
            UIManager.instance.ActiveMaterialButton(true);
            GameManager.instance.MaterialButtonShow = true;
        }
        GameManager.instance.OnCupCollider = false;
        UIManager.instance.CupInSideWhat.SetActive(true);
    }

}
