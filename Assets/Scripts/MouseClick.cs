using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    public Transform clickPoint = null;

    public LayerMask layerMask;
    private Camera worldCam;
    private Transform oripos;

    private void Start()
    {
        worldCam = Camera.main;
        oripos = transform;

    }

    void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    Rotate();
        //}
        //if (Input.GetMouseButtonUp(0))
        //{
        //    clickPoint.position = oripos.position;
        //}
        Rotate();

    }
    private void Rotate()
    {
       
        Ray ray = worldCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f, layerMask))
        {
            Vector3 lookPoint = hitInfo.point;
            //lookPoint.y = transform.position.y;
            clickPoint.position = lookPoint;
        }
    }
}
