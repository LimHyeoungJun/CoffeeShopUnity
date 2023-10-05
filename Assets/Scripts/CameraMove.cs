using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public GameObject cam1pos;
    public GameObject cam2pos;

    private void Awake()
    {
        gameObject.GetComponent<CameraMove>();
    }

    public void CamMove1()
    {
        gameObject.transform.position = cam1pos.transform.position;
        gameObject.transform.rotation = cam1pos.transform.rotation;

    }

    public void CamMove2()
    {
        gameObject.transform.position = cam2pos.transform.position;
        gameObject.transform.rotation = cam2pos.transform.rotation;
    }

}
